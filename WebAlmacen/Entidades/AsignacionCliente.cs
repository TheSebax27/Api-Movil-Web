using System;

namespace AppAlmacen.Entidades
{
    public class ClAsignacionCliente
    {
        public int IdAsignacion { get; set; }
        public int IdVendedor { get; set; }
        public string NombreVendedor { get; set; }
        public int IdCliente { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaAsignacion { get; set; }
        public bool Visitado { get; set; }
        public DateTime? FechaVisita { get; set; }
    }
}