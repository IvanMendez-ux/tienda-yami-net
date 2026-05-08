using System;
using System.Collections.Generic;

namespace tienda_yami.Models;

public partial class ProductDetail
{
    public int Id { get; set; }

    public long? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? Precio { get; set; }

    public string? Descripcion { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual Product? IdProductoNavigation { get; set; }
}
