using Microsoft.AspNetCore.Builder;

namespace ArcadiaParties.API.CustomMiddlewares
{
    public static class DatabaseAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseDatabaseRoles(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseAuthorizationMiddleware>();
        }
    }
}
