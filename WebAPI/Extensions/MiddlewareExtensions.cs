using ASPApp.WebAPI.Middleware;
namespace ASPApp.WebAPI.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomErrorMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<CustomErrorMiddleware>();
        }
    }
}
