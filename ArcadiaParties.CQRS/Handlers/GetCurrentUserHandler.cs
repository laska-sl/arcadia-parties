using System;
using System.Threading;
using System.Threading.Tasks;
using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using AutoMapper;
using MediatR;

namespace ArcadiaParties.CQRS.Handlers
{
    internal class GetCurrentUserHandler : IRequestHandler<GetCurrentUserQuery, UserDTO>
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public GetCurrentUserHandler(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;

        }
        public async Task<UserDTO> Handle(GetCurrentUserQuery request, CancellationToken cancellationToken)
        {
            var userRolesQuery = new GetUserRolesQuery(request.Principal);
            var userRoles = await _mediator.Send(userRolesQuery, cancellationToken);

            var assistantUserQuery = new GetAssistantUserQuery();
            var assistantUser = await _mediator.Send(assistantUserQuery, cancellationToken);

            var assistantEmployeeQuery = new GetAssistantEmployeeQuery(assistantUser.EmployeeId);
            var assistantEmployee = await _mediator.Send(assistantEmployeeQuery, cancellationToken);

            var assistantDepartmentQuery = new GetAssistantDepartmentQuery(assistantEmployee.DepartmentId);
            var assistantDepartment = await _mediator.Send(assistantDepartmentQuery, cancellationToken);

            var userToReturn = _mapper.Map<UserDTO>(assistantEmployee);
            userToReturn.Roles = userRoles;
            var departmentToReturn = _mapper.Map<DepartmentDTO>(assistantDepartment);
            userToReturn.Department = departmentToReturn;
            return userToReturn;
        }
    }
}