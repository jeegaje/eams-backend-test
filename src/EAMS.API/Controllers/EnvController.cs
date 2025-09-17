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
            var envVars = Environment.GetEnvironmentVariables();
            var dict = new Dictionary<string, string?>();

            foreach (DictionaryEntry entry in envVars)
            {
                dict[entry.Key.ToString()!] = entry.Value?.ToString();
            }

            return Ok(dict);
        }
        
        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("hello world");
        }
    }
}
