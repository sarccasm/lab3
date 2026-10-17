using Microsoft.AspNetCore.Mvc;
using ProductsWithRouting.Services;
namespace ProductsWithRouting.Controllers;

[Route("users")]
public class UsersController : Controller
{
    private readonly Data _data;
    public UsersController(Data data) => _data = data;

    [HttpGet("index")]
    public IActionResult Index() => Unauthorized();

    [HttpPost("index")]
    [Consumes("application/x-www-form-urlencoded")]
    public IActionResult IndexPost([FromForm] string? parameter)
    {
        if (parameter != "df2323eoT") return Unauthorized();
        return View("Index", _data.Users());
    }
}
