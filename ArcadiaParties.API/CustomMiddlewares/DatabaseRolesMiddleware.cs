using ArcadiaParties.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArcadiaParties.API.CustomMiddlewares
{
    public class DatabaseRolesMiddleware
    {
        private readonly RequestDelegate _next;

        public DatabaseRolesMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMediator mediator)
        {
            var user = context.User;

            var getCurrentUserQuery = new GetCurrentUserQuery(user);
            var currentUserFromDB = await mediator.Send(getCurrentUserQuery);

            if (currentUserFromDB == null)
            {
                context.Response.StatusCode = 403;
                return;
            }

            var newIdentity = new ClaimsIdentity(
                    NegotiateDefaults.AuthenticationScheme,
                    ClaimTypes.Name,
                    ClaimTypes.Role);

            newIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Identity.Name));

            var query = new GetUserRolesQuery(user);
            var userRoles = await mediator.Send(query);

            foreach (var item in userRoles)
            {
                newIdentity.AddClaim(new Claim(ClaimTypes.Role, item));
            }

            context.User = new ClaimsPrincipal(newIdentity);
            context.User.AddIdentities(user.Identities);

            await _next(context);
        }
    }
}
