using Microsoft.AspNetCore.Builder;

namespace ArcadiaParties.API.CustomMiddlewares
{
    public static class DatabaseAuthorizationMiddlewareExtensions
    {
        public static IApplicationBuilder UseDatabaseAuthorization(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<DatabaseAuthorizationMiddleware>();
        }
    }
}
