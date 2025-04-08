using System;
using System.Collections.Generic;

namespace AppApiAlmacenn.Models;

public partial class ClienteVendedor
{
    public int IdAsignacion { get; set; }

    public int IdCliente { get; set; }

    public int IdVendedor { get; set; }

    public DateTime? FechaAsignacion { get; set; }

    public virtual Usuario IdClienteNavigation { get; set; } = null!;

    public virtual Usuario IdVendedorNavigation { get; set; } = null!;
}
