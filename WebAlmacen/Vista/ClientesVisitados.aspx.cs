using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppAlmacen.Entidades;
using AppAlmacen.Logica;

namespace AppAlmacen.Vista
{
    public partial class ClientesVisitados : System.Web.UI.Page
    {
        private ClAsignacionClienteL asignacionL = new ClAsignacionClienteL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarClientesVisitados();
            }
        }

        private void CargarClientesVisitados()
        {
            List<ClAsignacionCliente> clientesVisitados = asignacionL.MtdListarClientesVisitados();
            gvClientesVisitados.DataSource = clientesVisitados;
            gvClientesVisitados.DataBind();
        }
    }
}