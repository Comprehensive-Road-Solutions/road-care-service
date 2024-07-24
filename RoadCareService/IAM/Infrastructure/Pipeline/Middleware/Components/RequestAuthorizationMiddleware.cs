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

            var tokenResult = tokenService.ValidateToken(token) ??
                throw new Exception("Invalid token!");

            dynamic? validation = null;

            if (tokenResult.Role == ECredentialRole
                .TRABAJADOR.ToString())
                validation = await workerCredentialQueryService.Handle
                    (new GetWorkerCredentialByWorkerIdAndCodeQuery
                    (tokenResult.Id, tokenResult.Code));

            else if (tokenResult.Role == ECredentialRole
                .CIUDADANO.ToString())
                validation = await citizenCredentialQueryService.Handle
                    (new GetCitizenCredentialByCitizenIdAndCodeQuery
                    (tokenResult.Id, tokenResult.Code));

            if (validation is null)
                throw new Exception("Invalid credentials!");

            if (validation.Result is true)
                context.Items["Credentials"] = tokenResult;

            else throw new Exception("Credentials not found!");

            await next(context);
        }
    }
}