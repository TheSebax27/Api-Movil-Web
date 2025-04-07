using System;
using System.Collections.Generic;

namespace AppApiAlmacen.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Nombres { get; set; }

    public string? Apellidos { get; set; }

    public string? Direccion { get; set; }

    public string? TelefonoFijo { get; set; }

    public string? Celular { get; set; }

    public string? Email { get; set; }

    public string? Foto { get; set; }

    public string? Ubicacion { get; set; }

    public string? Estado { get; set; }

    public string? Clave { get; set; }

    public int? IdTipousuario { get; set; }

    public virtual Tipousuario? IdTipousuarioNavigation { get; set; }
}
