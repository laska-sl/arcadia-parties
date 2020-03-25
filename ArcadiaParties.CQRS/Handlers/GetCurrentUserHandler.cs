using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, IEnumerable<string>>
    {
        private readonly IUserRepository _repo;

        public GetCurrentUserHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<string>> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUser(request.Principal.Identity.Name);
            return user.Roles;
        }
    }
}
