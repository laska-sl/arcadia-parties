using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;
using System.Collections.Generic;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetDatesOfDepartmentQuery : IRequest<IEnumerable<UsersOfDepartmentDTO>>
    {
        public int DepartmentId { get; }
        
        public GetDatesOfDepartmentQuery(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}