using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;
using System.Collections.Generic;
using System.Security.Principal;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetCurrentUserQuery : IRequest<IEnumerable<string>>
    {
        public GetCurrentUserQuery(IPrincipal principal)
        {
            Principal = principal;
        }

        public IPrincipal Principal { get; }
    }
}
