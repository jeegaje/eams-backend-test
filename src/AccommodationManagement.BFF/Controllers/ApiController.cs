using AccommodationManagement.Domain.DTOs;
using AccommodationManagement.BFF.Services;
using Microsoft.AspNetCore.Mvc;

namespace AccommodationManagement.BFF.Controllers
{
    [Route("bff/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ICoreApiService _coreApiService;

        public ApiController(ICoreApiService coreApiService)
        {
            _coreApiService = coreApiService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
        {
            var users = await _coreApiService.GetUsersAsync();

            var frontendResponse = new
            {
                Data = users,
                Count = users.Count(),
                TimeStamp = DateTime.UtcNow
            };

            return Ok(frontendResponse);
        }
    }
}