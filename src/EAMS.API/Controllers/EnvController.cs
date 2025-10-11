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

        [HttpGet("cpu")]
        public IActionResult StressCpu(int seconds = 30)
        {
            var endTime = DateTime.UtcNow.AddSeconds(seconds);
    
            // Jalankan CPU-bound task di background thread
            Parallel.For(0, Environment.ProcessorCount, i =>
            {
                while (DateTime.UtcNow < endTime)
                {
                    // Loop matematis sederhana
                    double x = Math.Sqrt(new Random().Next());
                }
            });
    
            return Ok($"CPU stress for {seconds} seconds started.");
        }
    }
}
