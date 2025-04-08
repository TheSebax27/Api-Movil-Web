using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using AppAlmacen.Entidades;

namespace AppAlmacen.Datos
{
    public class ClUsuarioD
    {
        private ClConexion conexion = new ClConexion();

        public List<ClUsuario> MtdListarUsuarios()
        {
            List<ClUsuario> lista = new List<ClUsuario>();
            try
            {
                SqlCommand cmd = new SqlCommand("spListarUsuarios", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClUsuario usuario = new ClUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Documento = dr["Documento"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        TelefonoFijo = dr["TelefonoFijo"].ToString(),
                        Celular = dr["Celular"].ToString(),
                        Email = dr["Email"].ToString(),
                        Foto = dr["Foto"].ToString(),
                        Ubicacion = dr["Ubicacion"].ToString(),
                        Estado = dr["Estado"] != DBNull.Value && (dr["Estado"].ToString() == "1" || dr["Estado"].ToString().ToLower() == "true"),
                        Clave = dr["Clave"].ToString(),
                        IdTipo = Convert.ToInt32(dr["IdTipo"]),
                        TipoUsuario = dr["tipoUsuario"].ToString()
                    };
                    lista.Add(usuario);
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

        public ClUsuario MtdObtenerUsuarioPorId(int idUsuario)
        {
            ClUsuario usuario = null;
            try
            {
                SqlCommand cmd = new SqlCommand("spObtenerUsuarioPorId", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = new ClUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Documento = dr["Documento"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString(),
                        Direccion = dr["Direccion"].ToString(),
                        TelefonoFijo = dr["TelefonoFijo"].ToString(),
                        Celular = dr["Celular"].ToString(),
                        Email = dr["Email"].ToString(),
                        Foto = dr["Foto"].ToString(),
                        Ubicacion = dr["Ubicacion"].ToString(),
                        Estado = dr["Estado"] != DBNull.Value && (dr["Estado"].ToString() == "1" || dr["Estado"].ToString().ToLower() == "true"),
                        Clave = dr["Clave"].ToString(),
                        IdTipo = Convert.ToInt32(dr["IdTipo"]),
                        TipoUsuario = dr["tipoUsuario"].ToString()
                    };
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
            return usuario;
        }

        public int MtdInsertarUsuario(ClUsuario usuario)
        {
            int resultado = 0;
            try
            {
                SqlCommand cmd = new SqlCommand("spInsertarUsuario", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                cmd.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@TelefonoFijo", usuario.TelefonoFijo);
                cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Foto", usuario.Foto);
                cmd.Parameters.AddWithValue("@Ubicacion", usuario.Ubicacion);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@IdTipo", usuario.IdTipo);

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    resultado = Convert.ToInt32(dr["IdUsuario"]);
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
            return resultado;
        }

        public bool MtdActualizarUsuario(ClUsuario usuario)
        {
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand("spActualizarUsuario", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                cmd.Parameters.AddWithValue("@Documento", usuario.Documento);
                cmd.Parameters.AddWithValue("@Nombres", usuario.Nombres);
                cmd.Parameters.AddWithValue("@Apellidos", usuario.Apellidos);
                cmd.Parameters.AddWithValue("@Direccion", usuario.Direccion);
                cmd.Parameters.AddWithValue("@TelefonoFijo", usuario.TelefonoFijo);
                cmd.Parameters.AddWithValue("@Celular", usuario.Celular);
                cmd.Parameters.AddWithValue("@Email", usuario.Email);
                cmd.Parameters.AddWithValue("@Foto", usuario.Foto);
                cmd.Parameters.AddWithValue("@Ubicacion", usuario.Ubicacion);
                cmd.Parameters.AddWithValue("@Estado", usuario.Estado);
                cmd.Parameters.AddWithValue("@Clave", usuario.Clave);
                cmd.Parameters.AddWithValue("@IdTipo", usuario.IdTipo);

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

        public bool MtdEliminarUsuario(int idUsuario)
        {
            bool resultado = false;
            try
            {
                SqlCommand cmd = new SqlCommand("spEliminarUsuario", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdUsuario", idUsuario);

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

        public List<ClUsuario> MtdListarVendedores()
        {
            List<ClUsuario> lista = new List<ClUsuario>();
            try
            {
                SqlCommand cmd = new SqlCommand("spListarVendedores", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClUsuario vendedor = new ClUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Documento = dr["Documento"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString()
                    };
                    lista.Add(vendedor);
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

        public List<ClUsuario> MtdListarClientesDisponibles()
        {
            List<ClUsuario> lista = new List<ClUsuario>();
            try
            {
                SqlCommand cmd = new SqlCommand("spListarClientesDisponibles", conexion.MtdAbrirConexion());
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    ClUsuario cliente = new ClUsuario
                    {
                        IdUsuario = Convert.ToInt32(dr["IdUsuario"]),
                        Documento = dr["Documento"].ToString(),
                        Nombres = dr["Nombres"].ToString(),
                        Apellidos = dr["Apellidos"].ToString()
                    };
                    lista.Add(cliente);
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