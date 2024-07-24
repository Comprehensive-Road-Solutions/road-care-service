using RoadCareService.IAM.Application.Internal.OutboundServices;
using RoadCareService.IAM.Domain.Model.Queries.CitizenCredential;
using RoadCareService.IAM.Domain.Model.Queries.WorkerCredential;
using RoadCareService.IAM.Domain.Model.ValueObjects.Credential;
using RoadCareService.IAM.Domain.Services.CitizenCredential;
using RoadCareService.IAM.Domain.Services.WorkerCredential;
using RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Attributes;

namespace RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Components
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

            dynamic validation;

            if (result is null)
                throw new Exception("Invalid token!");

            bool user = false;

            if (result.Role == ECredentialRole
                .TRABAJADOR.ToString())
            {
                validation = await workerCredentialQueryService.Handle
                    (new GetWorkerCredentialByWorkerIdAndCodeQuery
                    (result.Id, result.Code));

                user = validation.Item2;

                if (user is true)
                    context.Items["Credentials"] = result;
            }
            else if (result.Role == ECredentialRole
                .TRABAJADOR.ToString())
            {
                validation = await citizenCredentialQueryService.Handle
                    (new GetCitizenCredentialByCitizenIdAndCodeQuery
                    (result.Id, result.Code));

                user = validation.Item2;

                if (user is true)
                    context.Items["Credentials"] = result;
            }

            if (user is false)
                throw new Exception("Credentials not found!");

            await next(context);
        }
    }
}