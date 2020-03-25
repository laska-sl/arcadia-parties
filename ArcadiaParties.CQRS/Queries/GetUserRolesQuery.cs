using MediatR;
using System.Collections.Generic;
using System.Security.Principal;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetUserRolesQuery : IRequest<IEnumerable<string>>
    {
        public GetUserRolesQuery(IPrincipal principal)
        {
            Principal = principal;
        }

        public IPrincipal Principal { get; }
    }
}
