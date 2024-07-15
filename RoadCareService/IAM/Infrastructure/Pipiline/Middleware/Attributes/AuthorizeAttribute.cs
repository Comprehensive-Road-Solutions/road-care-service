using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RoadCareService.IAM.Domain.Model.Entities;

namespace RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute : Attribute, IAuthorizationFilter
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var allowAnonymous = context.ActionDescriptor.EndpointMetadata.OfType<AllowAnonymousAttribute>().Any();

            if (allowAnonymous)
            {
                Console.WriteLine("Skipping Authorization");

                return;
            }

            var workerCredential = (WorkerCredential?)context.HttpContext.Items["WorkerCredential"];
            var citizenCredential = (CitizenCredential?)context.HttpContext.Items["CitizenCredential"];

            if (workerCredential == null && citizenCredential == null)
                context.Result = new UnauthorizedResult();
        }
    }
}