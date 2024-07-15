using RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Components;

namespace RoadCareService.IAM.Infrastructure.Pipiline.Middleware.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<RequestAuthorizationMiddleware>();
        }
    }
}