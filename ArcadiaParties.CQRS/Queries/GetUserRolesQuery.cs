using MediatR;
using System.Collections.Generic;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetUserRolesQuery : IRequest<IEnumerable<string>>
    {
        public GetUserRolesQuery(string userIdentity)
        {
            UserIdentity = userIdentity;
        }

        public string UserIdentity { get; }
    }
}
