using System;
using System.Collections.Generic;

namespace tienda_yami.Models.ProductosHome;

/// <summary>
/// mis productos
/// </summary>
public partial class Productos
{
    public long Id { get; set; }

    public string? Producto { get; set; }

     public string? Url { get; set; }

    public decimal? Precio { get; set; }

    public int? Cantidad { get; set; }

    public string? Categoria { get; set; }

    public DateTime CreatedAt { get; set; }
}
