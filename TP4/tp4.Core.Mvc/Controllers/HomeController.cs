using Microsoft.AspNetCore.Mvc;

namespace tp4.Core.Mvc.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}