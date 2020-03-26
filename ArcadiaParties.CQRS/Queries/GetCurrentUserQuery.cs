using System.Security.Principal;
using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetCurrentUserQuery : IRequest<UserDTO>
    {
        public GetCurrentUserQuery(IPrincipal principal)
        {
            Principal = principal;
        }

        public IPrincipal Principal { get; }
    }
}