using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Queries.Citizen;
using RoadCareService.IAM.Domain.Model.Queries.Worker;
using RoadCareService.IAM.Domain.Services.Citizen;
using RoadCareService.IAM.Domain.Services.Worker;
using RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Attributes;

namespace RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Components
{
    public class RequestAuthorizationMiddleware
        (RequestDelegate next)
    {
        public async Task InvokeAsync
            (HttpContext context,
            IWorkerQueryService workerQueryService,
            ICitizenQueryService citizenQueryService,
            ITokenService tokenService)
        {
            var allowAnonymous =
                context.Request.HttpContext
                .GetEndpoint()!.Metadata.Any(m =>
                m.GetType() == typeof
                (AllowAnonymousAttribute));

            if (allowAnonymous)
            {
                await next(context);

                return;
            }

            var token = context.Request.Headers["Authorization"]
            .FirstOrDefault()?.Split(" ").Last();

            if (string.IsNullOrEmpty(token))
                throw new Exception("Token not provided!");

            var result = tokenService.ValidateToken(token);

            if (result is null)
                throw new Exception("Invalid token!");

            bool isValidUser = false;

            if (result is WorkerCredential workerCredential)
            {
                isValidUser = await workerQueryService.Handle
                    (new GetWorkerByIdAndCodeQuery
                    (workerCredential.WorkersId,
                    workerCredential.Code));

                if (isValidUser)
                    context.Items["Credentials"] =
                        workerCredential;
            }
            else if (result is CitizenCredential citizenCredential)
            {
                isValidUser = await citizenQueryService.Handle
                    (new GetCitizenCredentialByIdAndCodeQuery
                    (citizenCredential.CitizensId,
                    citizenCredential.Code));

                if (isValidUser)
                    context.Items["Credentials"] =
                        citizenCredential;
            }

            if (!isValidUser)
                throw new Exception("Credentials not found!");

            await next(context);
        }
    }
}