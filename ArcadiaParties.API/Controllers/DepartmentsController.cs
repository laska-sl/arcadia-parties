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
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(typeof(IEnumerable<DepartmentDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns all departments"
        )]
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetDepartments(CancellationToken cancellationToken)
        {
            var query = new GetAllDepartmentsQuery();
            var departments = await _mediator.Send(query, cancellationToken);

            return Ok(departments);
        }
    }
}
