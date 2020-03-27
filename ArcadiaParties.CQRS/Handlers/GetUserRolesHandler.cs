using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, IEnumerable<string>>
    {
        private readonly IUserRepository _repo;

        public GetUserRolesHandler(IUserRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<string>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            var user = await _repo.GetUser(request.Principal.Identity.Name);
            return user?.Roles;
        }
    }
}
