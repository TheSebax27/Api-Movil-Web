using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AppAlmacen.Entidades;

namespace AppAlmacen.Datos
{
    public class ClTipoUsuarioD
    {
        private ClConexion conexion = new ClConexion();

        public List<ClTipoUsuario> MtdListarTiposUsuario()
        {
            List<ClTipoUsuario> lista = new List<ClTipoUsuario>();
            try
            {
                SqlCommand cmd = new SqlCommand("spListarTiposUsuario", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClTipoUsuario tipo = new ClTipoUsuario
                    {
                        IdTipo = Convert.ToInt32(dr["IdTipo"]),
                        TipoUsuario = dr["tipoUsuario"].ToString()
                    };
                    lista.Add(tipo);
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
            return lista;
        }
    }
}