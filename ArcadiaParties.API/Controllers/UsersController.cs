using ArcadiaParties.CQRS.Queries;
using ArcadiaParties.Data.Abstractions.DTOs;
using ArcadiaParties.Data.Abstractions.Repositories;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IAssistantTokenRepository _repo;
        private readonly IHttpClientFactory _clientFactory;

        public UsersController(IMediator mediator, IAssistantTokenRepository repo, IHttpClientFactory clientFactory)
        {
            _mediator = mediator;
            _repo = repo;
            _clientFactory = clientFactory;
        }

        [ProducesResponseType(typeof(IEnumerable<AssistantUserDTO>), StatusCodes.Status200OK)]
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

        [ProducesResponseType(typeof(AssistantUserDTO), StatusCodes.Status200OK)]
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
            var query = new GetCurrentUserQuery(User);
            var user = await _mediator.Send(query, cancellationToken);

            return Ok(user);
        }

        [ProducesResponseType(typeof(AssistantUserDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns current authenticated user"
        )]
        [Authorize]
        [HttpGet]
        [Route("GetUser")]
        public async Task<IActionResult> GetUserFromAssistant(CancellationToken cancellationToken)
        {
            var query = new GetAssistantUserQuery();
            var user = await _mediator.Send(query, cancellationToken);

            return Ok(user);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        [SwaggerOperation(
             Summary = "Returns detailed authenticated user"
        )]
        [Authorize]
        [HttpGet]
        [Route("GetDetailedUser")]
        public async Task<IActionResult> GetDetailedUserFromAssistant(CancellationToken cancellationToken)
        {
            var query = new GetAssistantEmployeeQuery();
            var user = await _mediator.Send(query, cancellationToken);

            return Ok(user);
        }
    }
}