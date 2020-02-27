using Microsoft.AspNetCore.Builder;

namespace ArcadiaParties.API.CustomMiddlewares
{
    public static class DatabaseRolesMiddlewareExtensions
    {
        public static IApplicationBuilder UseCreateClaims(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseRolesMiddleware>();
        }
    }
}
