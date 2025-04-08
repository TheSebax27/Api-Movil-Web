using System;
using System.Collections.Generic;

namespace AppApiAlmacenn.Models;

public partial class Visita
{
    public int IdVisita { get; set; }

    public int IdVendedor { get; set; }

    public int IdCliente { get; set; }

    public DateTime? FechaVisita { get; set; }

    public string? Observaciones { get; set; }

    public virtual Usuario IdClienteNavigation { get; set; } = null!;

    public virtual Usuario IdVendedorNavigation { get; set; } = null!;
}
