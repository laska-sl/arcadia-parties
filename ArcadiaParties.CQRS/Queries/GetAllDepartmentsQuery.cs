using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;
using System.Collections.Generic;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetAllDepartmentsQuery : IRequest<IEnumerable<DepartmentDTO>>
    {
    }
}
