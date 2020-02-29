using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;
using System.Security.Principal;

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
