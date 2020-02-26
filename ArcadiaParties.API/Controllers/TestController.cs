using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ArcadiaParties.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult TestMethod()
        {
            return Ok(new
            {
                User.Identity.AuthenticationType,
                User.Identity.IsAuthenticated,
                User.Identity.Name
            });
        }
    }
}
