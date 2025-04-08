using System;

namespace AppAlmacen.Entidades
{
    public class ClUsuario
    {
        public int IdUsuario { get; set; }
        public string Documento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string TelefonoFijo { get; set; }
        public string Celular { get; set; }
        public string Email { get; set; }
        public string Foto { get; set; }
        public string Ubicacion { get; set; }
        public bool Estado { get; set; }
        public string Clave { get; set; }
        public int IdTipo { get; set; }
        public string TipoUsuario { get; set; }

        public string NombreCompleto
        {
            get { return Nombres + " " + Apellidos; }
        }
    }
}