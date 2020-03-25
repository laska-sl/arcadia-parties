using System.Security.Claims;
using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetCurrentUserQuery : IRequest<UserDTO>
    {
         public GetCurrentUserQuery(ClaimsPrincipal user)
        {
            User = user;
        }

        public ClaimsPrincipal User { get; }
    }
}