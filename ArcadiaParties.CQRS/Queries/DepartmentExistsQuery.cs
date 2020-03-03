using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class DepartmentExistsQuery : IRequest<bool>
    {
        public int DepartmentId { get; }

        public DepartmentExistsQuery(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
