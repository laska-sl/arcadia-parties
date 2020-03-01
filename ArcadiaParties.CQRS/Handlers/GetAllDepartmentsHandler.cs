using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;

namespace ArcadiaParties.CQRS.Handlers
{
    public class GetAllDepartmentsHandler : IRequestHandler<GetAllDepartmentsQuery, IEnumerable<DepartmentDTO>>
    {
        private readonly IDepartmentRepository _repo;

        public GetAllDepartmentsHandler(IDepartmentRepository repo)
        {
            _repo = repo;
        }

        public async Task<IEnumerable<DepartmentDTO>> Handle(GetAllDepartmentsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetDepartments();
        }
    }
}