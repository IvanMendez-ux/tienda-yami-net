using System;
using System.Collections.Generic;

namespace tienda_yami.Models;

public partial class Category
{
    public short Id { get; set; }

    public string? Nombre { get; set; }

    public DateTime CreatedAt { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
