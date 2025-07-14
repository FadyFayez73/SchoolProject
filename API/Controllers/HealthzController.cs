using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthzController : ControllerBase
    {
        /// <summary>
        /// Health check endpoint
        /// </summary>
        /// <returns>Returns a simple OK response</returns>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Service is running");
        }
    }
}
