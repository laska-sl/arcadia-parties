using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    public class GetUserRolesHandler : IRequestHandler<GetUserRolesQuery, IEnumerable<string>>
    {
        private readonly IUserRepository _repo;

        public GetUserRolesHandler(IUserRepository repo)
        {
            _repo = repo;
        }
        public async Task<IEnumerable<string>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetUserRoles(request.Principal.Identity.Name);
        }
    }
}
