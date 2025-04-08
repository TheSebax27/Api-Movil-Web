using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppAlmacen.Entidades;
using AppAlmacen.Logica;

namespace AppAlmacen.Vista
{
    public partial class GestionUsuarios : System.Web.UI.Page
    {
        private ClUsuarioL usuarioL = new ClUsuarioL();
        private ClTipoUsuarioL tipoUsuarioL = new ClTipoUsuarioL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTiposUsuario();
                CargarUsuarios();
            }
        }

        private void CargarTiposUsuario()
        {
            List<ClTipoUsuario> tiposUsuario = tipoUsuarioL.MtdListarTiposUsuario();
            ddlTipoUsuario.DataSource = tiposUsuario;
            ddlTipoUsuario.DataTextField = "TipoUsuario";
            ddlTipoUsuario.DataValueField = "IdTipo";
            ddlTipoUsuario.DataBind();
        }

        private void CargarUsuarios()
        {
            List<ClUsuario> usuarios = usuarioL.MtdListarUsuarios();
            gvUsuarios.DataSource = usuarios;
            gvUsuarios.DataBind();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
            litTituloForm.Text = "Nuevo Usuario";
            pnlListado.Visible = false;
            pnlFormulario.Visible = true;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            pnlFormulario.Visible = false;
            pnlListado.Visible = true;
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                ClUsuario usuario = new ClUsuario
                {
                    Documento = txtDocumento.Text,
                    Nombres = txtNombres.Text,
                    Apellidos = txtApellidos.Text,
                    Direccion = txtDireccion.Text,
                    TelefonoFijo = txtTelefonoFijo.Text,
                    Celular = txtCelular.Text,
                    Email = txtEmail.Text,
                    Foto = txtFoto.Text,
                    Ubicacion = txtUbicacion.Text,
                    Estado = chkEstado.Checked,
                    Clave = txtClave.Text,
                    IdTipo = Convert.ToInt32(ddlTipoUsuario.SelectedValue)
                };

                bool resultado = false;
                int idUsuario = Convert.ToInt32(hfIdUsuario.Value);

                if (idUsuario == 0)
                {
                    idUsuario = usuarioL.MtdInsertarUsuario(usuario);
                    resultado = (idUsuario > 0);
                }
                else
                {
                    usuario.IdUsuario = idUsuario;
                    resultado = usuarioL.MtdActualizarUsuario(usuario);
                }

                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: '¡Éxito!', text: 'Usuario guardado correctamente.', icon: 'success'});", true);
                    pnlFormulario.Visible = false;
                    pnlListado.Visible = true;
                    CargarUsuarios();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Error', text: 'Error al guardar el usuario.', icon: 'error'});", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                    $"Swal.fire({{title: 'Error', text: 'Error: {ex.Message}', icon: 'error'}});", true);
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Editar")
            {
                int idUsuario = Convert.ToInt32(e.CommandArgument);
                CargarUsuarioParaEditar(idUsuario);
            }
        }

        private void CargarUsuarioParaEditar(int idUsuario)
        {
            ClUsuario usuario = usuarioL.MtdObtenerUsuarioPorId(idUsuario);
            if (usuario != null)
            {
                hfIdUsuario.Value = usuario.IdUsuario.ToString();
                txtDocumento.Text = usuario.Documento;
                txtNombres.Text = usuario.Nombres;
                txtApellidos.Text = usuario.Apellidos;
                txtDireccion.Text = usuario.Direccion;
                txtTelefonoFijo.Text = usuario.TelefonoFijo;
                txtCelular.Text = usuario.Celular;
                txtEmail.Text = usuario.Email;
                txtFoto.Text = usuario.Foto;
                txtUbicacion.Text = usuario.Ubicacion;
                chkEstado.Checked = usuario.Estado;
                txtClave.Attributes["value"] = usuario.Clave;
                ddlTipoUsuario.SelectedValue = usuario.IdTipo.ToString();

                litTituloForm.Text = "Editar Usuario";
                pnlListado.Visible = false;
                pnlFormulario.Visible = true;
            }
        }

        protected void btnEliminarHidden_Click(object sender, EventArgs e)
        {
            int idUsuario = Convert.ToInt32(hfEliminarUsuarioId.Value);
            EliminarUsuario(idUsuario);
        }

        private void EliminarUsuario(int idUsuario)
        {
            try
            {
                bool resultado = usuarioL.MtdEliminarUsuario(idUsuario);
                if (resultado)
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: '¡Éxito!', text: 'Usuario eliminado correctamente.', icon: 'success'});", true);
                    CargarUsuarios();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                        "Swal.fire({title: 'Error', text: 'Error al eliminar el usuario.', icon: 'error'});", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "sweetalert",
                    $"Swal.fire({{title: 'Error', text: 'Error: {ex.Message}', icon: 'error'}});", true);
            }
        }

        private void LimpiarFormulario()
        {
            hfIdUsuario.Value = "0";
            txtDocumento.Text = string.Empty;
            txtNombres.Text = string.Empty;
            txtApellidos.Text = string.Empty;
            txtDireccion.Text = string.Empty;
            txtTelefonoFijo.Text = string.Empty;
            txtCelular.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtFoto.Text = string.Empty;
            txtUbicacion.Text = string.Empty;
            chkEstado.Checked = true;
            txtClave.Text = string.Empty;
            if (ddlTipoUsuario.Items.Count > 0)
            {
                ddlTipoUsuario.SelectedIndex = 0;
            }
        }
    }
}