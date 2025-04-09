using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ApiAlmacen.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }
        public string? Documento { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Direccion { get; set; }
        public string? TelefonoFijo { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public string? Foto { get; set; }
        public string? Ubicacion { get; set; }
        public string? Estado { get; set; }
        public string? clave { get; set; }

        public int? IdTipo { get; set; }

        [ForeignKey("IdTipo")]
        [JsonIgnore]
        public TipoUsuario? tipoUsuario { get; set; }

        [InverseProperty("Vendedor")]
        [JsonIgnore]
        public ICollection<AsignacionCliente>? AsignacionesComoVendedor { get; set; }

        [InverseProperty("Cliente")]
        [JsonIgnore]
        public ICollection<AsignacionCliente>? AsignacionesComoCliente { get; set; }

    }

}
