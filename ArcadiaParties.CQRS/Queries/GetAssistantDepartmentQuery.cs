﻿using ArcadiaParties.Data.Abstractions.DTOs;
using MediatR;

namespace ArcadiaParties.CQRS.Queries
{
    public class GetAssistantDepartmentQuery : IRequest<AssistantDepartmentDTO>
    {
        public string DepartmentId { get; }

        public GetAssistantDepartmentQuery(string departmentId)
        {
            DepartmentId = departmentId;
        }
    }
}
