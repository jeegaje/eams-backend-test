using EAMS.Domain.DTOs;
using EAMS.BFF.Services;
using Microsoft.AspNetCore.Mvc;

namespace EAMS.BFF.Controllers
{
    [ApiController]
    [Route("bff/[controller]")]
    public class UsersController(ICoreApiService coreApiService) : ControllerBase
    {
        private readonly ICoreApiService _coreApiService = coreApiService;

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _coreApiService.GetAllUsersAsync();

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