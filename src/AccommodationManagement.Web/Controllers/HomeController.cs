using System.Diagnostics;
using AccommodationManagement.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using AccommodationManagement.Web.Models;
using AccommodationManagement.Web.Services;

namespace AccommodationManagement.Web.Controllers;

public class HomeController : Controller
{
    private readonly IBffService _bffService;

    public HomeController(IBffService bffService)
    {
        _bffService = bffService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<IActionResult> Users()
    {
        var users = await _bffService.GetAllUsersAsync();
        return View(users);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
