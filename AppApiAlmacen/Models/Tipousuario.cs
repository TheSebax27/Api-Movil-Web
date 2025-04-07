using System;
using System.Collections.Generic;

namespace AppApiAlmacen.Models;

public partial class Tipousuario
{
    public int IdTipo { get; set; }

    public string? TipoUsuario { get; set; }

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
