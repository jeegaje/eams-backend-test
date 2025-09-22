using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace AMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetEnv()
        {
            return Ok("hello world");
        }
        
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("hello world Test");
        }
    }
}
