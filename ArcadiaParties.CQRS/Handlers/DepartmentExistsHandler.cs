using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class DepartmentExistsHandler : IRequestHandler<DepartmentExistsQuery, bool>
    {
        private readonly IDepartmentRepository _repo;

        public DepartmentExistsHandler(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(DepartmentExistsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.DepartmentExists(request.DepartmentId);
        }
    }
}