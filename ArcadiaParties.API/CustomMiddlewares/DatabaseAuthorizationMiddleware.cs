using ArcadiaParties.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArcadiaParties.API.CustomMiddlewares
{
    public class DatabaseAuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseAuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMediator mediator)
        {
            var user = context.User;

            if (!user.Identity.IsAuthenticated)
            {
                context.Response.StatusCode = 401;
                return;
            }

            var getCurrentUserQuery = new GetUserRolesQuery(user);
            var currentUserRolesFromDB = await mediator.Send(getCurrentUserQuery);

            if (currentUserRolesFromDB == null)
            {
                context.Response.StatusCode = 403;
                return;
            }

            var newIdentity = new ClaimsIdentity(
                user.Identity.AuthenticationType,
                ClaimTypes.Name,
                ClaimTypes.Role);

            newIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Identity.Name));
            
            foreach (var item in currentUserRolesFromDB)
            {
                newIdentity.AddClaim(new Claim(ClaimTypes.Role, item));
            }

            context.User = new ClaimsPrincipal(newIdentity);
            context.User.AddIdentities(user.Identities);

            await _next(context);
        }
    }
}
