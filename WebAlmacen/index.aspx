<%@ Page Title="" Language="C#" MasterPageFile="~/Vista/Almacen.Master" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="AppAlmacen.index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <h1 class="display-4">Sistema de Gestión de Almacén</h1>
        <p class="lead">Administración de usuarios y asignación de clientes a vendedores.</p>
        <hr class="my-4"/>
        <p>Utilice las opciones del menú para gestionar los usuarios y asignaciones.</p>
    </div>

    <div class="row mt-4">
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Gestión de Usuarios</h5>
                    <p class="card-text">Registre, edite, elimine y visualice los usuarios del sistema.</p>
                    <a href="Vista/GestionUsuarios.aspx" class="btn btn-primary">Ir a Gestión de Usuarios</a>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Asignación de Clientes</h5>
                    <p class="card-text">Asigne clientes a vendedores y gestione las asignaciones actuales.</p>
                    <a href="Vista/AsignacionClientes.aspx" class="btn btn-primary">Ir a Asignación de Clientes</a>
                </div>
            </div>
        </div>
        <div class="col-md-4">
            <div class="card">
                <div class="card-body">
                    <h5 class="card-title">Clientes Visitados</h5>
                    <p class="card-text">Visualice qué clientes han sido visitados por los vendedores.</p>
                    <a href="Vista/ClientesVisitados.aspx" class="btn btn-primary">Ir a Clientes Visitados</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
