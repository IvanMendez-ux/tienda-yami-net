using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tienda_yami.Models;
using Microsoft.EntityFrameworkCore;
using tienda_yami.Models.ProductosHome;
using System.Text.Json;

namespace tienda_yami.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(
        ILogger<HomeController> logger,
        AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var products = await (from a in _context.Products
                              join b in _context.ProductDetails on a.Id equals b.IdProducto
                              join c in _context.Images on a.Id equals c.IdProduct
                              join d in _context.Categories on a.IdCategory equals d.Id
                              where c.Orden == 1 && a.Existe == true
                              select new Productos
                              {
                                  Id = a.Id,
                                  Producto = a.Producto,
                                  Url = c.Url,
                                  Precio = b.Precio,
                                  Cantidad = b.Cantidad,
                                  Categoria = d.Nombre,
                                  CreatedAt = a.CreatedAt
                              })
         .OrderByDescending(x => x.CreatedAt)
         .Take(10)
         .ToListAsync();
        return View(products);
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
