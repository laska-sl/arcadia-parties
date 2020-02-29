using ArcadiaParties.CQRS.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
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

        [SwaggerOperation(
             Summary = "Returns all users"
        )]
        [Authorize(Roles = "Administrator")]
        [HttpGet]
        [Route("GetUsers")]
        public async Task<IActionResult> GetUsers()
        {
            var query = new GetAllUsersQuery();

            var users = _mediator.Send(query);

            return Ok(users);
        }

        [SwaggerOperation(
             Summary = "Returns current authenticated Windows user"
        )]
        [HttpGet]
        [Route("GetCurrentUser")]
        public async Task<IActionResult> GetCurrentUser()
        {
            var userIdentity = User.Identity.Name;
            var query = new GetCurrentUserQuery(userIdentity);

            var user = _mediator.Send(query);

            return Ok(user);
        }

    }
}
