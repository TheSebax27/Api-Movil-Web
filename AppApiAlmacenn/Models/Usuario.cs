using System;
using System.Collections.Generic;

namespace AppApiAlmacenn.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public int IdTipo { get; set; }

    public string Documento { get; set; } = null!;

    public string Nombres { get; set; } = null!;

    public string Apellidos { get; set; } = null!;

    public string? Direccion { get; set; }

    public string? TelefonoFijo { get; set; }

    public string? Celular { get; set; }

    public string? Email { get; set; }

    public string? Foto { get; set; }

    public string? Ubicacion { get; set; }

    public bool? Estado { get; set; }

    public string Clave { get; set; } = null!;

    public virtual ClienteVendedor? ClienteVendedorIdClienteNavigation { get; set; }

    public virtual ICollection<ClienteVendedor> ClienteVendedorIdVendedorNavigations { get; set; } = new List<ClienteVendedor>();

    public virtual Tipousuario IdTipoNavigation { get; set; } = null!;

    public virtual ICollection<Visita> VisitaIdClienteNavigations { get; set; } = new List<Visita>();

    public virtual ICollection<Visita> VisitaIdVendedorNavigations { get; set; } = new List<Visita>();
}
