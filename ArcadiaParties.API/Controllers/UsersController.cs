using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public UsersController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [ProducesResponseType(typeof(IEnumerable<UserDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns all users"
        )]
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers(CancellationToken cancellationToken)
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query, cancellationToken);

            return Ok(users);
        }

        [ProducesResponseType(typeof(UserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns current authenticated user"
        )]
        [Authorize]
        [HttpGet]
        [Route("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser(CancellationToken cancellationToken)
        {
            var userQery = new GetCurrentUserQuery(User);
            var user = await _mediator.Send(userQery, cancellationToken);

            var assistantUserQuery = new GetAssistantUserQuery();
            var assistantUser = await _mediator.Send(assistantUserQuery, cancellationToken);

            var assistantEmployeeQuery = new GetAssistantEmployeeQuery(assistantUser.EmployeeId);
            var assistantEmployee = await _mediator.Send(assistantEmployeeQuery, cancellationToken);

            var assistantDepartmentQuery = new GetAssistantDepartmentQuery(assistantEmployee.DepartmentId);
            var assistantDepartment = await _mediator.Send(assistantDepartmentQuery, cancellationToken);

            var userToReturn = _mapper.Map<UserDTO>(assistantEmployee);
            userToReturn.Roles = user.Roles;
            userToReturn.Department = assistantDepartment;

            return Ok(userToReturn);
        }
    }
}