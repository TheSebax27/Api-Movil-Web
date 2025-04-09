using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ApiAlmacen.Models
{
    public class AsignacionCliente
    {
        [Key]
        public int IdAsignacion { get; set; }

        public int IdVendedor { get; set; }
        public int IdCliente { get; set; }

        public DateTime FechaAsignacion { get; set; }
        public bool Visitado { get; set; }
        public DateTime? FechaVisita { get; set; }

        [ForeignKey("IdVendedor")]
        [InverseProperty("AsignacionesComoVendedor")]
        [JsonIgnore]
        public Usuario? Vendedor { get; set; }

        [ForeignKey("IdCliente")]
        [InverseProperty("AsignacionesComoCliente")]
        [JsonIgnore]
        public Usuario? Cliente { get; set; }
    }
}
