using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers;

public class ErrorController : Controller
{
    private readonly ILogger<ErrorController> _logger;

    public ErrorController(ILogger<ErrorController> logger)
    {
        _logger = logger;
    }
    
    public IActionResult Page404Error()
    {
        return View();
    }
    
    public IActionResult Page500Error()
    {
        return View();
    }
}