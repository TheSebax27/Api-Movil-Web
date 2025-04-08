using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppAlmacen.Entidades;
using AppAlmacen.Logica;

namespace AppAlmacen.Vista
{
    public partial class AsignacionClientes : System.Web.UI.Page
    {
        private ClUsuarioL usuarioL = new ClUsuarioL();
        private ClAsignacionClienteL asignacionL = new ClAsignacionClienteL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarVendedores();
                CargarClientesDisponibles();
                CargarAsignaciones();
            }
        }

        private void CargarVendedores()
        {
            List<ClUsuario> vendedores = usuarioL.MtdListarVendedores();
            ddlVendedor.DataSource = vendedores;
            ddlVendedor.DataTextField = "NombreCompleto";
            ddlVendedor.DataValueField = "IdUsuario";
            ddlVendedor.DataBind();
            ddlVendedor.Items.Insert(0, new ListItem("-- Seleccione Vendedor --", ""));
        }

        private void CargarClientesDisponibles()
        {
            List<ClUsuario> clientes = usuarioL.MtdListarClientesDisponibles();
            ddlCliente.DataSource = clientes;
            ddlCliente.DataTextField = "NombreCompleto";
            ddlCliente.DataValueField = "IdUsuario";
            ddlCliente.DataBind();
            ddlCliente.Items.Insert(0, new ListItem("-- Seleccione Cliente --", ""));
        }

        private void CargarAsignaciones()
        {
            List<ClAsignacionCliente> asignaciones = asignacionL.MtdListarClientesAsignados();
            gvAsignaciones.DataSource = asignaciones;
            gvAsignaciones.DataBind();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(ddlVendedor.SelectedValue) || string.IsNullOrEmpty(ddlCliente.SelectedValue))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Atención', text: 'Debe seleccionar un vendedor y un cliente.', icon: 'warning'});", true);
                    return;
                }

                int idVendedor = Convert.ToInt32(ddlVendedor.SelectedValue);
                int idCliente = Convert.ToInt32(ddlCliente.SelectedValue);

                int resultado = asignacionL.MtdAsignarClienteVendedor(idVendedor, idCliente);

                if (resultado > 0)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: '¡Éxito!', text: 'Cliente asignado correctamente.', icon: 'success'});", true);
                    CargarClientesDisponibles();
                    CargarAsignaciones();
                }
                else if (resultado == -1)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Error', text: 'El cliente ya está asignado a un vendedor.', icon: 'error'});", true);
                }
                else if (resultado == -2)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Error', text: 'El usuario seleccionado no es un vendedor válido.', icon: 'error'});", true);
                }
                else if (resultado == -3)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Error', text: 'El usuario seleccionado no es un cliente válido.', icon: 'error'});", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Error', text: 'Error al asignar el cliente.', icon: 'error'});", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                    $"Swal.fire({{title: 'Error', text: 'Error: {ex.Message}', icon: 'error'}});", true);
            }
        }

        protected void gvAsignaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int idAsignacion = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "MarcarVisitado")
            {
                MarcarClienteVisitado(idAsignacion);
            }
            else if (e.CommandName == "Eliminar")
            {
                // Ahora manejamos la eliminación aquí también
                EliminarAsignacion(idAsignacion);
            }
        }

        // Mantenemos este método para el botón oculto
        protected void btnEliminarHidden_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(hfEliminarAsignacionId.Value))
            {
                int idAsignacion = Convert.ToInt32(hfEliminarAsignacionId.Value);
                EliminarAsignacion(idAsignacion);
            }
        }

        private void MarcarClienteVisitado(int idAsignacion)
        {
            try
            {
                bool resultado = asignacionL.MtdMarcarClienteVisitado(idAsignacion);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: '¡Éxito!', text: 'Cliente marcado como visitado correctamente.', icon: 'success'});", true);
                    CargarAsignaciones();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Error', text: 'Error al marcar cliente como visitado.', icon: 'error'});", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                    $"Swal.fire({{title: 'Error', text: 'Error: {ex.Message}', icon: 'error'}});", true);
            }
        }

        private void EliminarAsignacion(int idAsignacion)
        {
            try
            {
                bool resultado = asignacionL.MtdEliminarAsignacionCliente(idAsignacion);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: '¡Éxito!', text: 'Asignación eliminada correctamente.', icon: 'success'});", true);
                    CargarClientesDisponibles();
                    CargarAsignaciones();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Error', text: 'Error al eliminar la asignación.', icon: 'error'});", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                    $"Swal.fire({{title: 'Error', text: 'Error: {ex.Message}', icon: 'error'}});", true);
            }
        }
    }
}