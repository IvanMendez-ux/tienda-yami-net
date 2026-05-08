using System;
using System.Collections.Generic;

namespace tienda_yami.Models;

/// <summary>
/// mis productos
/// </summary>
public partial class Product
{
    public long Id { get; set; }

    public string? Producto { get; set; }

    public short? IdCategory { get; set; }

    public DateTime CreatedAt { get; set; }

    public bool? Existe { get; set; }

    public virtual Category? IdCategoryNavigation { get; set; }

    public virtual ICollection<Image> Images { get; set; } = new List<Image>();

    public virtual ICollection<ProductDetail> ProductDetails { get; set; } = new List<ProductDetail>();
}
