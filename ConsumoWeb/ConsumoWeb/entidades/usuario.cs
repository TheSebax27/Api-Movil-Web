using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsumoWeb.entidades
{
	public class usuario
{
        public int idUsuario { get; set; }
        public string documento { get; set; }
        public string nombres { get; set; }
        public string apellidos { get; set; }
        public string direccion  { get; set; }
        public string telefonoFijo { get; set; }
        public string celular { get; set; }
        public string email { get; set; }
        public string foto { get; set; }
        public string ubicacion { get; set; }
        public string estado { get; set; }
        public string clave { get; set; }
    }
}