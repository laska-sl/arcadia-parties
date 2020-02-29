﻿using ArcadiaParties.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;

namespace ArcadiaParties.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {        
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [SwaggerOperation(
             Summary = "Returns all users"
        )]
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers(CancellationToken ct)
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query,ct);

            return Ok(users);
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [SwaggerOperation(
             Summary = "Returns current authenticated user"
        )]
        [HttpGet]
        [Route("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser(CancellationToken ct)
        {
            IPrincipal principal = HttpContext.User;
            var query = new GetCurrentUserQuery(principal);
            var user = await _mediator.Send(query, ct);

            return Ok(user);
        }
    }
}
