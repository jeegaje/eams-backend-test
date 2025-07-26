using AccommodationManagement.CoreAPI.Mappers;
using AccommodationManagement.Domain.DTOs;
using AccommodationManagement.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccommodationManagement.CoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : BaseController
    {
        private readonly IUserService _userService;
        private readonly ILogger<UsersController> _logger;

        public UsersController(
            IUserService userService,
            ILogger<UsersController> logger
        )
        {
            _userService = userService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();
            return CreateResponse(users.ToDto(), "Users retrieved successfully");
        }
    }
}