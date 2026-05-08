using System;
using System.Collections.Generic;

namespace tienda_yami.Models;

public partial class Visita
{
    public long Id { get; set; }

    public string Ip { get; set; } = null!;

    public DateTime? CreatedAt { get; set; }
}
