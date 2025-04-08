using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AppAlmacen.Datos
{
    public class ClConexion
    {
        SqlConnection conexion = null;
        public ClConexion()
        {
            conexion = new SqlConnection("Data Source=.;Initial Catalog=dbAlmacen;Integrated Security=True;");
        }
        public SqlConnection MtdAbrirConexion()
        {
            conexion.Open();
            return conexion;
        }

        public void MtdCerrarConexion()
        {
            conexion.Close();
        }
    }
}