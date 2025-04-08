using System;
using System.Collections.Generic;

namespace AppApiAlmacenn.Models;

public partial class Tipousuario
{
    public int IdTipo { get; set; }

    public string TipoUsuario { get; set; } = null!;

    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
