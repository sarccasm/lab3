using Microsoft.AspNetCore.Mvc;
namespace ProductsWithRouting.Controllers;
public class HomeController : Controller
{
    public IActionResult Index() => RedirectToAction("Index", "Products");
    public IActionResult Error() => View();
}
