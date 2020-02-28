using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetCurrentUserQuery : IRequest<UserDTO>
    {
        public GetCurrentUserQuery(string identity)
        {
            Identity = identity;
        }

        public string Identity { get; }
    }
}
