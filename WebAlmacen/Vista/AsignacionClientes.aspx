<%@ Page Title="Asignación de Clientes" Language="C#" MasterPageFile="~/Vista/Almacen.Master" AutoEventWireup="true" CodeBehind="AsignacionClientes.aspx.cs" Inherits="AppAlmacen.Vista.AsignacionClientes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function confirmarEliminar(idAsignacion) {
            Swal.fire({
                title: '¿Está seguro?',
                text: "¿Desea eliminar esta asignación?",
                icon: 'warning',
                showCancelButton: true,
                confirmButtonColor: '#3085d6',
                cancelButtonColor: '#d33',
                confirmButtonText: 'Sí, eliminar',
                cancelButtonText: 'Cancelar'
            }).then((result) => {
                if (result.isConfirmed) {
                    document.getElementById('<%= hfEliminarAsignacionId.ClientID %>').value = idAsignacion;
                    __doPostBack('<%= btnEliminarHidden.UniqueID %>', '');
                }
            });
            return false;
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Asignación de Clientes a Vendedores</h2>
    
    <div class="row mb-4">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h4>Nueva Asignación</h4>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-5">
                            <label for="ddlVendedor" class="form-label">Vendedor:</label>
                            <asp:DropDownList ID="ddlVendedor" runat="server" CssClass="form-select" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-5">
                            <label for="ddlCliente" class="form-label">Cliente:</label>
                            <asp:DropDownList ID="ddlCliente" runat="server" CssClass="form-select" required="required">
                            </asp:DropDownList>
                        </div>
                        <div class="col-md-2 d-flex align-items-end">
                            <asp:Button ID="btnAsignar" runat="server" Text="Asignar Cliente" CssClass="btn btn-primary btn-block" OnClick="btnAsignar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h4>Clientes Asignados</h4>
                </div>
                <div class="card-body">
                    <asp:GridView ID="gvAsignaciones" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered" 
                        OnRowCommand="gvAsignaciones_RowCommand" DataKeyNames="IdAsignacion">
                        <Columns>
                            <asp:BoundField DataField="NombreVendedor" HeaderText="Vendedor" />
                            <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                            <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <asp:Label ID="lblEstado" runat="server" Text='<%# Convert.ToBoolean(Eval("Visitado")) ? "Visitado" : "Pendiente" %>'
                                        CssClass='<%# Convert.ToBoolean(Eval("Visitado")) ? "badge bg-success" : "badge bg-warning" %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:BoundField DataField="FechaVisita" HeaderText="Fecha Visita" DataFormatString="{0:dd/MM/yyyy}" NullDisplayText="--" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:LinkButton ID="lnkMarcarVisitado" runat="server" CommandName="MarcarVisitado" CommandArgument='<%# Eval("IdAsignacion") %>' 
                                        CssClass="btn btn-sm btn-success" Visible='<%# !Convert.ToBoolean(Eval("Visitado")) %>'>
                                        <i class="bi bi-check-circle"></i> Marcar como Visitado
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Eliminar" CommandArgument='<%# Eval("IdAsignacion") %>' 
                                        CssClass="btn btn-sm btn-danger" OnClientClick='<%# "return confirmarEliminar(" + Eval("IdAsignacion") + ");" %>'>
                                        <i class="bi bi-trash"></i> Eliminar
                                    </asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
    
    <asp:Button ID="btnEliminarHidden" runat="server" Style="display: none;" OnClick="btnEliminarHidden_Click" />
    <asp:HiddenField ID="hfEliminarAsignacionId" runat="server" />
</asp:Content>