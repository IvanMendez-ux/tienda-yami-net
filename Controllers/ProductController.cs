using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using tienda_yami.Models;
using Microsoft.EntityFrameworkCore;
using tienda_yami.Models.ProductosHome;
using System.Text.Json;

namespace tienda_yami.Controllers;

public class ProductController : Controller
{
    private readonly ILogger<HomeController> _logger;
private readonly AppDbContext _context;

    public ProductController(
        ILogger<HomeController> logger,
        AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IActionResult> ProductById(int id)
    {
        var products = await (from a in _context.Products 
         join b in _context.ProductDetails on a.Id equals b.IdProducto
         join c in _context.Images on a.Id equals c.IdProduct
         join d in _context.Categories on a.IdCategory equals d.Id
         where a.Id == id && c.Orden == 1 
         select new ProductosDetail
         {
             Id = a.Id,
             Producto = a.Producto,
             Url = c.Url,
             Precio = b.Precio,
             Cantidad = b.Cantidad,
             Categoria = d.Nombre,
             Descripcion = b.Descripcion,
         }).SingleAsync();
        return View(products);
    }

    public async Task<IActionResult> ProductByCategorie(int id)
    {
        var products = await (from a in _context.Products 
         join b in _context.ProductDetails on a.Id equals b.IdProducto
         join c in _context.Images on a.Id equals c.IdProduct
         join d in _context.Categories on a.IdCategory equals d.Id
         where c.Orden == 1 && a.Existe == true && a.IdCategory == id
         select new Productos
         {
             Id = a.Id,
             Producto = a.Producto,
             Url = c.Url,
             Precio = b.Precio,
             Cantidad = b.Cantidad,
             Categoria = d.Nombre,
         }).ToListAsync();
        return View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
