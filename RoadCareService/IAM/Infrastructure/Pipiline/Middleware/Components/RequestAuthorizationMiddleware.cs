using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.Entities;
using RoadCareService.IAM.Domain.Model.Queries.CitizenCredential;
using RoadCareService.IAM.Domain.Model.Queries.WorkerCredential;
using RoadCareService.IAM.Domain.Services.CitizenCredential;
using RoadCareService.IAM.Domain.Services.WorkerCredential;
using RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Attributes;

namespace RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Components
{
    public class RequestAuthorizationMiddleware
        (RequestDelegate next)
    {
        public async Task InvokeAsync
            (HttpContext context,
            IWorkerCredentialQueryService workerCredentialQueryService,
            ICitizenCredentialQueryService citizenCredentialQueryService,
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

            string? user = null;

            if (result is WorkerCredential workerCredential)
            {
                user = await workerCredentialQueryService.Handle
                    (new GetWorkerCredentialByIdAndCodeQuery
                    (workerCredential.WorkersId,
                    workerCredential.Code));

                if (!string.IsNullOrEmpty(user))
                    context.Items["Credentials"] =
                        workerCredential;
            }
            else if (result is CitizenCredential citizenCredential)
            {
                user = await citizenCredentialQueryService.Handle
                    (new GetCitizenCredentialByIdAndCodeQuery
                    (citizenCredential.CitizensId,
                    citizenCredential.Code));

                if (!string.IsNullOrEmpty(user))
                    context.Items["Credentials"] =
                        citizenCredential;
            }

            if (!string.IsNullOrEmpty(user))
                throw new Exception("Credentials not found!");

            await next(context);
        }
    }
}