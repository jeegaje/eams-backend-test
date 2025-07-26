using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AccommodationManagement.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AccommodationManagement.CoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult CreateResponse<T>(T data, string? message = null){
            return Ok(new ApiResponse<T>
            {
                Success = true,
                Data = data,
                Message = message,
                StatusCode = StatusCodes.Status200OK
            });
        }

        protected IActionResult CreateErrorResponse(string message, int statusCode = 400){
            return StatusCode(statusCode, new ApiResponse<object>{
                Success = false,
                Message = message
            });
        }
    }
}