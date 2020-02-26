using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
