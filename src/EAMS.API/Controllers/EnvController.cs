using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EAMS.Domain.Entities;
using System.Linq;
using System.Threading.Tasks;

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

        // [HttpGet("accommodations/top5")]
        // public async Task<IActionResult> GetTop5Accommodations()
        // {
        //     // Fetching the top 5 accommodations ordered by Name or any other property you prefer
        //     var top5Accommodations = await _context.Accommodations
        //         .Where(a => !a.Inactive)  // Optional: Exclude inactive accommodations
        //         .OrderBy(a => a.Name)     // You can modify this to order by other criteria, e.g., Rating, Price
        //         .Take(5)
        //         .ToListAsync();

        //     if (top5Accommodations == null || !top5Accommodations.Any())
        //     {
        //         return NotFound("No accommodations found.");
        //     }

        //     return Ok(top5Accommodations);
        // }
    }
}
