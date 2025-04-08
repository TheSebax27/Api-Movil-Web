<%@ Page Title="Clientes Visitados" Language="C#" MasterPageFile="~/Vista/Almacen.Master" AutoEventWireup="true" CodeBehind="ClientesVisitados.aspx.cs" Inherits="AppAlmacen.Vista.ClientesVisitados" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Registro de Clientes Visitados</h2>
    
    <div class="row">
        <div class="col-md-12">
            <div class="card">
                <div class="card-header">
                    <h4>Clientes Visitados</h4>
                </div>
                <div class="card-body">
                    <asp:GridView ID="gvClientesVisitados" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-bordered">
                        <Columns>
                            <asp:BoundField DataField="NombreVendedor" HeaderText="Vendedor" />
                            <asp:BoundField DataField="NombreCliente" HeaderText="Cliente" />
                            <asp:BoundField DataField="FechaAsignacion" HeaderText="Fecha Asignación" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:BoundField DataField="FechaVisita" HeaderText="Fecha Visita" DataFormatString="{0:dd/MM/yyyy}" />
                            <asp:TemplateField HeaderText="Estado">
                                <ItemTemplate>
                                    <span class="badge bg-success">Visitado</span>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>