using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AppAlmacen.Entidades;

namespace AppAlmacen.Datos
{
    public class ClAsignacionClienteD
    {
        private ClConexion conexion = new ClConexion();

        public int MtdAsignarClienteVendedor(int idVendedor, int idCliente)
        {
            int resultado = 0;
            SqlCommand cmd = null;
            SqlConnection conn = null;

            try
            {
                conn = conexion.MtdAbrirConexion();
                cmd = new SqlCommand("spAsignarClienteVendedor", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@IdVendedor", idVendedor);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                SqlParameter outputParam = new SqlParameter("@Resultado", SqlDbType.Int);
                outputParam.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(outputParam);

                cmd.ExecuteNonQuery();

                resultado = Convert.ToInt32(outputParam.Value);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (conn != null && conn.State == ConnectionState.Open)
                {
                    conexion.MtdCerrarConexion();
                }
            }

            return resultado;
        }



        public List<ClAsignacionCliente> MtdListarClientesAsignados(int? idVendedor = null)
        {
            List<ClAsignacionCliente> lista = new List<ClAsignacionCliente>();
            try
            {
                SqlCommand cmd = new SqlCommand("spListarClientesAsignados", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                if (idVendedor.HasValue)
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", idVendedor.Value);
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IdVendedor", DBNull.Value);
                }

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClAsignacionCliente asignacion = new ClAsignacionCliente
                    {
                        IdAsignacion = Convert.ToInt32(dr["IdAsignacion"]),
                        IdVendedor = Convert.ToInt32(dr["IdVendedor"]),
                        NombreVendedor = dr["NombreVendedor"].ToString(),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        NombreCliente = dr["NombreCliente"].ToString(),
                        FechaAsignacion = Convert.ToDateTime(dr["FechaAsignacion"]),
                        Visitado = Convert.ToBoolean(dr["Visitado"])
                    };

                    if (dr["FechaVisita"] != DBNull.Value)
                    {
                        asignacion.FechaVisita = Convert.ToDateTime(dr["FechaVisita"]);
                    }

                    lista.Add(asignacion);
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

        public List<ClAsignacionCliente> MtdListarClientesVisitados()
        {
            List<ClAsignacionCliente> lista = new List<ClAsignacionCliente>();
            try
            {
                SqlCommand cmd = new SqlCommand("spListarClientesVisitados", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClAsignacionCliente asignacion = new ClAsignacionCliente
                    {
                        IdAsignacion = Convert.ToInt32(dr["IdAsignacion"]),
                        IdVendedor = Convert.ToInt32(dr["IdVendedor"]),
                        NombreVendedor = dr["NombreVendedor"].ToString(),
                        IdCliente = Convert.ToInt32(dr["IdCliente"]),
                        NombreCliente = dr["NombreCliente"].ToString(),
                        FechaAsignacion = Convert.ToDateTime(dr["FechaAsignacion"]),
                        Visitado = Convert.ToBoolean(dr["Visitado"]),
                        FechaVisita = Convert.ToDateTime(dr["FechaVisita"])
                    };
                    lista.Add(asignacion);
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

        public bool MtdMarcarClienteVisitado(int idAsignacion)
        {
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand("spMarcarClienteVisitado", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAsignacion", idAsignacion);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = (filasAfectadas > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
            return resultado;
        }

        public bool MtdEliminarAsignacionCliente(int idAsignacion)
        {
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand("spEliminarAsignacionCliente", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdAsignacion", idAsignacion);

                int filasAfectadas = cmd.ExecuteNonQuery();
                resultado = (filasAfectadas > 0);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                conexion.MtdCerrarConexion();
            }
            return resultado;
        }
    }
}