using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RoadCareService.IAM.Domain.Model.ValueObjects.Credential;

namespace RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class AuthorizeAttribute :
        Attribute, IAuthorizationFilter
    {
        private readonly string[] ListRoles;

        public AuthorizeAttribute
            (params string[] roles)
        {
            ListRoles = roles ?? Array.Empty<string>();
        }

        public void OnAuthorization
            (AuthorizationFilterContext context)
        {
            var allowAnonymous = context
                .ActionDescriptor
                .EndpointMetadata.OfType
                <AllowAnonymousAttribute>()
                .Any();

            if (allowAnonymous)
                return;

            var credential =
                context.HttpContext
                .Items["Credentials"]
                as dynamic;

            if (credential is null)
            {
                context.Result = new UnauthorizedResult();

                return;
            }

            var userRole = credential.Role != null ?
                ECredentialRole.TRABAJADOR.ToString() :
                ECredentialRole.CIUDADANO.ToString();

            if (ListRoles.Length > 0 && !HasRequiredRole(userRole))
            {
                context.Result = new ForbidResult();

                return;
            }
        }

        private bool HasRequiredRole
            (string role) => ListRoles
            .Contains(role);
    }
}