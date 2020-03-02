using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;
using System.Collections.Generic;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetUsersOfDepartmentQuery : IRequest<IEnumerable<UserForCalendarDTO>>
    {
        public int DepartmentId { get; }
        
        public GetUsersOfDepartmentQuery(int departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}