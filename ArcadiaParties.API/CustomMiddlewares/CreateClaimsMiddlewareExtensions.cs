using Microsoft.AspNetCore.Builder;

namespace ArcadiaParties.API.CustomMiddlewares
{
    public static class CreateClaimsMiddlewareExtensions
    {
        public static IApplicationBuilder UseCreateClaims(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CreateClaimsMiddleware>();
        }
    }
}
