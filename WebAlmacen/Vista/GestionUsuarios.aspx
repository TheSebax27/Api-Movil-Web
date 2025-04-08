<%@ Page Title="Gestión de Usuarios" Language="C#" MasterPageFile="~/Vista/Almacen.Master" AutoEventWireup="true" CodeBehind="GestionUsuarios.aspx.cs" Inherits="AppAlmacen.Vista.GestionUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmarEliminar(idUsuario) {
            Swal.fire({
                title: '¿Está seguro?',
                text: "¿Desea eliminar este usuario?",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sí, eliminar',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    document.getElementById('<%= hfEliminarUsuarioId.ClientID %>').value = idUsuario;
                    document.getElementById('<%= btnEliminarHidden.ClientID %>').click();
                }
            });
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Gestión de Usuarios</h2>
    
    <div class="row mb-4">
        <div class="col-md-12">
            <asp:Button ID="btnNuevo" runat="server" Text="Nuevo Usuario" CssClass="btn btn-primary" OnClick="btnNuevo_Click" />
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="pnlListado" runat="server">
                <asp:GridView ID="gvUsuarios" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" 
                    OnRowCommand="gvUsuarios_RowCommand" DataKeyNames="IdUsuario">
                    <Columns>
                        <asp:BoundField DataField="Documento" HeaderText="Documento" />
                        <asp:BoundField DataField="Nombres" HeaderText="Nombres" />
                        <asp:BoundField DataField="Apellidos" HeaderText="Apellidos" />
                        <asp:BoundField DataField="Email" HeaderText="Email" />
                        <asp:BoundField DataField="TipoUsuario" HeaderText="Tipo Usuario" />
                        <asp:TemplateField HeaderText="Estado">
                            <ItemTemplate>
                                <asp:Label ID="lblEstado" runat="server" Text='<%# Convert.ToBoolean(Eval("Estado")) ? "Activo" : "Inactivo" %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkEditar" runat="server" CommandName="Editar" CommandArgument='<%# Eval("IdUsuario") %>' CssClass="btn btn-sm btn-warning">
                                    <i class="bi bi-pencil"></i> Editar
                                </asp:LinkButton>
                                <asp:LinkButton ID="lnkEliminar" runat="server" CommandArgument='<%# Eval("IdUsuario") %>' 
                                    CssClass="btn btn-sm btn-danger" OnClientClick='<%# "return confirmarEliminar(" + Eval("IdUsuario") + ");" %>'>
                                    <i class="bi bi-trash"></i> Eliminar
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </asp:Panel>
            
            <asp:Panel ID="pnlFormulario" runat="server" Visible="false">
                <div class="card">
                    <div class="card-header">
                        <h4><asp:Literal ID="litTituloForm" runat="server"></asp:Literal></h4>
                    </div>
                    <div class="card-body">
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtDocumento" class="form-label">Documento:</label>
                                <asp:TextBox ID="txtDocumento" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="ddlTipoUsuario" class="form-label">Tipo de Usuario:</label>
                                <asp:DropDownList ID="ddlTipoUsuario" runat="server" CssClass="form-select" required="required"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtNombres" class="form-label">Nombres:</label>
                                <asp:TextBox ID="txtNombres" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtApellidos" class="form-label">Apellidos:</label>
                                <asp:TextBox ID="txtApellidos" runat="server" CssClass="form-control" required="required"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtDireccion" class="form-label">Dirección:</label>
                                <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtUbicacion" class="form-label">Ubicación:</label>
                                <asp:TextBox ID="txtUbicacion" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-4">
                                <label for="txtTelefonoFijo" class="form-label">Teléfono Fijo:</label>
                                <asp:TextBox ID="txtTelefonoFijo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtCelular" class="form-label">Celular:</label>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-4">
                                <label for="txtEmail" class="form-label">Email:</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <label for="txtFoto" class="form-label">URL de Foto:</label>
                                <asp:TextBox ID="txtFoto" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="txtClave" class="form-label">Clave:</label>
                                <asp:TextBox ID="txtClave" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row mb-3">
                            <div class="col-md-6">
                                <div class="form-check">
                                    <asp:CheckBox ID="chkEstado" runat="server" Checked="true" CssClass="form-check-input" />
                                    <label class="form-check-label" for="chkEstado">Usuario Activo</label>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer">
                        <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-primary" OnClick="btnGuardar_Click" />
                        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary" OnClick="btnCancelar_Click" />
                        <asp:HiddenField ID="hfIdUsuario" runat="server" Value="0" />
                    </div>
                </div>
            </asp:Panel>
            
            <asp:Button ID="btnEliminarHidden" runat="server" Style="display: none;" OnClick="btnEliminarHidden_Click" />
            <asp:HiddenField ID="hfEliminarUsuarioId" runat="server" />
        </div>
    </div>
</asp:Content>