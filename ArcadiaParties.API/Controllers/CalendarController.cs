using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
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
    public class CalendarController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CalendarController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(IEnumerable<UsersForCalendarDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns users of department"
        )]
        [Authorize]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsersOfDepartment(int id, CancellationToken cancellationToken)
        {
            var departmentExistsQuery = new DepartmentExistsQuery(id);
            var departmentExists = await _mediator.Send(departmentExistsQuery, cancellationToken);

            if (!departmentExists)
            {
                return NotFound();
            }

            var query = new GetDatesOfDepartmentQuery(id);
            var users = await _mediator.Send(query, cancellationToken);

            return Ok(users);
        }
    }
}