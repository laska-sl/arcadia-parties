using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data;
using MediatR;
using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ArcadiaParties.API.CustomMiddlewares
{
    public class CreateClaimsMiddleware
    {
        private readonly RequestDelegate _next;
        private IMediator _mediator;
        public CreateClaimsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IMediator mediator)
        {
            _mediator = mediator;

            var user = context.User;

            var newIdentity = new ClaimsIdentity(
                NegotiateDefaults.AuthenticationScheme,
                ClaimTypes.Name,
                ClaimTypes.Role);

            newIdentity.AddClaim(new Claim(ClaimTypes.Name, user.Identity.Name));

            var query = new GetUserRolesQuery(user.Identity.Name);
            var userRoles = await _mediator.Send(query);

            foreach (var item in userRoles)
            {
                newIdentity.AddClaim(new Claim(ClaimTypes.Role, item));
            }

            // Temp user roles
            //newIdentity.AddClaim(new Claim(ClaimTypes.Role, "User"));
            //newIdentity.AddClaim(new Claim(ClaimTypes.Role, "Reviewer"));
            //newIdentity.AddClaim(new Claim(ClaimTypes.Role, "Admin"));

            context.User = new ClaimsPrincipal(newIdentity);
            context.User.AddIdentities(user.Identities);

            await _next(context);
        }
    }
}
