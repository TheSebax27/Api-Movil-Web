using System;
using System.Collections.Generic;
using AppAlmacen.Datos;
using AppAlmacen.Entidades;

namespace AppAlmacen.Logica
{
    public class ClUsuarioL
    {
        private ClUsuarioD usuarioD = new ClUsuarioD();

        public List<ClUsuario> MtdListarUsuarios()
        {
            return usuarioD.MtdListarUsuarios();
        }

        public ClUsuario MtdObtenerUsuarioPorId(int idUsuario)
        {
            return usuarioD.MtdObtenerUsuarioPorId(idUsuario);
        }

        public int MtdInsertarUsuario(ClUsuario usuario)
        {
            return usuarioD.MtdInsertarUsuario(usuario);
        }

        public bool MtdActualizarUsuario(ClUsuario usuario)
        {
            return usuarioD.MtdActualizarUsuario(usuario);
        }

        public bool MtdEliminarUsuario(int idUsuario)
        {
            return usuarioD.MtdEliminarUsuario(idUsuario);
        }

        public List<ClUsuario> MtdListarVendedores()
        {
            return usuarioD.MtdListarVendedores();
        }

        public List<ClUsuario> MtdListarClientesDisponibles()
        {
            return usuarioD.MtdListarClientesDisponibles();
        }
    }
}