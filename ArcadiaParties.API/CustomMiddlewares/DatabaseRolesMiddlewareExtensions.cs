using Microsoft.AspNetCore.Builder;

namespace ArcadiaParties.API.CustomMiddlewares
{
    public static class DatabaseRolesMiddlewareExtensions
    {
        public static IApplicationBuilder UseDatabaseRoles(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseRolesMiddleware>();
        }
    }
}
