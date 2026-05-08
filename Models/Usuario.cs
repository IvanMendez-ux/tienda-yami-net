using System;
using System.Collections.Generic;

namespace tienda_yami.Models;

public partial class Usuario
{
    public long Id { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public DateTime CreatedAt { get; set; }
}
