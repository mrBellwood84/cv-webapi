using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AliveController : ControllerBase
    {
        [HttpGet]
        [AllowAnonymous]
        public IActionResult SendAliveMessage()
        {
            return Ok("Alive");
        }
    }
}
