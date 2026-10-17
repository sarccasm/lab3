using ProductsWithRouting.Models;
namespace ProductsWithRouting.Services;
public class Data
{
    private readonly object _gate = new();
    private readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 1299, Category = "Electronics", Description = "Lightweight laptop" },
        new Product { Id = 2, Name = "Headphones", Price = 149, Category = "Electronics", Description = "Wireless headphones" },
        new Product { Id = 3, Name = "Notebook", Price = 9, Category = "Stationery", Description = "A5 notebook" },
        new Product { Id = 4, Name = "Desk lamp", Price = 39, Category = "Home", Description = "LED desk lamp" }
    };
    private readonly List<User> _users = new()
    {
        new User { Id = 1, Name = "Anna", Email = "anna@example.com" },
        new User { Id = 2, Name = "Mark", Email = "mark@example.com" }
    };
    private static Product Copy(Product x) => new() { Id=x.Id, Name=x.Name, Price=x.Price, Description=x.Description, Category=x.Category };
    public List<Product> Products(string? search, string? category, decimal? minPrice, decimal? maxPrice)
    {
        lock (_gate)
        {
            IEnumerable<Product> q = _products;
            if (!string.IsNullOrWhiteSpace(search)) q = q.Where(x => x.Name.Contains(search, StringComparison.OrdinalIgnoreCase) || x.Description.Contains(search, StringComparison.OrdinalIgnoreCase));
            if (!string.IsNullOrWhiteSpace(category)) q = q.Where(x => x.Category.Equals(category, StringComparison.OrdinalIgnoreCase));
            if (minPrice.HasValue) q = q.Where(x => x.Price >= minPrice.Value);
            if (maxPrice.HasValue) q = q.Where(x => x.Price <= maxPrice.Value);
            return q.OrderBy(x => x.Id).Select(Copy).ToList();
        }
    }
    public Product? Find(int id) { lock (_gate) { var x = _products.FirstOrDefault(x => x.Id == id); return x == null ? null : Copy(x); } }
    public void Add(Product x) { lock (_gate) { x.Id = _products.Count == 0 ? 1 : _products.Max(p => p.Id) + 1; _products.Add(Copy(x)); } }
    public bool Update(Product x) { lock (_gate) { var i = _products.FindIndex(p => p.Id == x.Id); if (i < 0) return false; _products[i] = Copy(x); return true; } }
    public bool Delete(int id) { lock (_gate) { return _products.RemoveAll(p => p.Id == id) > 0; } }
    public List<User> Users() => _users.ToList();
}
