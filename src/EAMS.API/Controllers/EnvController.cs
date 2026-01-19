using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EAMS.Domain.Entities;
using EAMS.Infrastructure.Data;
using EAMS.API.DTOs;
using System.Linq;
using System.Threading.Tasks;

namespace AMS.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EnvController : ControllerBase
    {
        private readonly EamsDbContext _context;
        private readonly ILogger<EnvController> _logger;

        public EnvController(EamsDbContext context, ILogger<EnvController> logger)
        {
            _context = context;
            _logger = logger;
        }
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

        [HttpGet("accommodations/top5")]
        public async Task<IActionResult> GetTop5Accommodations()
        {
            // Fetching the top 5 accommodations ordered by Name or any other property you prefer
            var top5Accommodations = await _context.Accommodations
                .Where(a => !a.Inactive)
                .OrderBy(a => a.Name)
                .Take(5)
                .ToListAsync();

            if (top5Accommodations == null || !top5Accommodations.Any())
            {
                return NotFound("No accommodations found.");
            }

            // Map to DTO if available
            var result = top5Accommodations.Select(a => new AccommodationDto
            {
                Name = a.Name,
                Street = a.Street,
                Suburb = a.Suburb,
                Postcode = a.Postcode,
                State = a.State,
                Region = a.Region,
                Phone = a.Phone,
                Email = a.Email,
                Website = a.Website
            }).ToList();

            int id = 13;
            int userId = 11;
            int? organisationId = null;
            _logger.LogInformation(
                "[ANALYTICS] {@Analytics}",
                new {
                    action = "testingAccommodation",
                    accommodationId = id,
                    userId = userId,
                    organisationId = organisationId
                });

        _logger.LogInformation("{ \"action\": \"viewAccommodation\", \"accommodationId\": \"13\", \"userId\": \"11\", \"organisationId\": \"14\" }");
         _logger.LogInformation("{{ \"action\": \"{action}\", \"accommodationId\": \"{accommodationId}\", \"userId\": \"{userId}\", \"organisationId\": \"{organisationId}\" }}", "viewAccommodation", "13", "11", "14");
        _logger.LogInformation("{{ \"action\": \"editAccommodation\", \"accommodationId\": \"13\", \"userId\": \"11\", \"organisationId\": \"14\" }}");
            return Ok(result);
        }
    }
}
