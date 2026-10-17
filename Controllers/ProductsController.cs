using Microsoft.AspNetCore.Mvc;
using ProductsWithRouting.Models;
using ProductsWithRouting.Services;
namespace ProductsWithRouting.Controllers;

[Route("products")]
[Route("items")]
public class ProductsController : Controller
{
    private readonly Data _data;
    public ProductsController(Data data) => _data = data;

    [HttpGet("")]
    [HttpGet("index")]
    public IActionResult Index(string? search, string? category, decimal? minPrice, decimal? maxPrice)
    {
        ViewBag.Search = search;
        ViewBag.Category = category;
        ViewBag.MinPrice = minPrice;
        ViewBag.MaxPrice = maxPrice;
        return View(_data.Products(search, category, minPrice, maxPrice));
    }

    [HttpGet("{id:int}")]
    [HttpGet("details/{id:int}")]
    public IActionResult Details(int id)
    {
        var product = _data.Find(id);
        return product == null ? MissingProduct() : View(product);
    }

    [HttpGet("create")]
    [HttpGet("new")]
    public IActionResult Create() => View(new Product());

    [HttpPost("create")]
    [HttpPost("new")]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Product product)
    {
        if (!ModelState.IsValid) return View(product);
        _data.Add(product);
        TempData["Message"] = "Product created.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id:int}")]
    public IActionResult Edit(int id)
    {
        var product = _data.Find(id);
        return product == null ? MissingProduct() : View(product);
    }

    [HttpPost("edit/{id:int}")]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int id, Product product)
    {
        if (_data.Find(id) == null) return MissingProduct();
        product.Id = id;
        if (!ModelState.IsValid) return View(product);
        _data.Update(product);
        TempData["Message"] = "Product updated.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("delete/{id:int}")]
    public IActionResult Delete(int id)
    {
        var product = _data.Find(id);
        return product == null ? MissingProduct() : View(product);
    }

    [HttpPost("delete/{id:int}")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        if (!_data.Delete(id)) return MissingProduct();
        TempData["Message"] = "Product deleted.";
        return RedirectToAction(nameof(Index));
    }

    private IActionResult MissingProduct()
    {
        Response.StatusCode = 404;
        return View("ProductNotFound");
    }
}
