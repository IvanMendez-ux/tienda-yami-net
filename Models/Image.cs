using System;
using System.Collections.Generic;

namespace tienda_yami.Models;

public partial class Image
{
    public int Id { get; set; }

    public long? IdProduct { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Url { get; set; }

    public short? Orden { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
