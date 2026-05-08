using System;
using System.Collections.Generic;

namespace tienda_yami.Models;

public partial class Ubicacione
{
    public long Id { get; set; }

    public DateTime CreatedAt { get; set; }

    public string? Ip { get; set; }

    public string? Lat { get; set; }

    public string? Lng { get; set; }

    public string? Accuracy { get; set; }
}
