using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ArcadiaParties.API.Controllers
{
    //[Authorize(Roles = "User")]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IMediator _mediator;
        public TestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> TestMethod()
        {
            return Ok(
            //userRoles
            new
            {
                User.Identity.AuthenticationType,
                User.Identity.IsAuthenticated,
                User.Identity.Name
            }
            );
        }
    }
}
