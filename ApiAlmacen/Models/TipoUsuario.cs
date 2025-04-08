using System.ComponentModel.DataAnnotations;

namespace ApiAlmacen.Models
{
    public class TipoUsuario
    {
        [Key]
        public int IdTipo { get; set; }
        public string ? tipoUsuario { get; set; }
    }
}
