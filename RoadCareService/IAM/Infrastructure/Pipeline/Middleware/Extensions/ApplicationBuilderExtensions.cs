using RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Components;

namespace RoadCareService.IAM.Infrastructure.Pipeline.Middleware.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseRequestAuthorization
            (this IApplicationBuilder builder) =>
            builder.UseMiddleware
            <RequestAuthorizationMiddleware>();
    }
}