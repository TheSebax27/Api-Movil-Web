using System;
using System.Collections.Generic;
using AppAlmacen.Datos;
using AppAlmacen.Entidades;

namespace AppAlmacen.Logica
{
    public class ClTipoUsuarioL
    {
        private ClTipoUsuarioD tipoUsuarioD = new ClTipoUsuarioD();

        public List<ClTipoUsuario> MtdListarTiposUsuario()
        {
            return tipoUsuarioD.MtdListarTiposUsuario();
        }
    }
}