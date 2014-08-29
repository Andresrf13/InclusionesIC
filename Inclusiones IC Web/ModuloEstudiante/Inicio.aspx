<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiantes.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="InclusionesIC_Proyecto.ModuloEstudiante.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div class="jumbotron">
            <div class="container-fluid">
                <h1>¡Inclusiones IC!
                </h1>
                <p>El sistema de inclusiones IC le permitirá dar seguimiento al proceso de inclusiones de la escuela de ingeniería en Computación. </p>
            </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="text-align: center">
                    <div class="btn-group-vertical">
                        <h2>Solicitar Inclusión</h2>
                        <asp:ImageButton runat="server" OnClick="Unnamed_Click" ID="ibtnSolicitar" ImageUrl="../Imagenes/registro.png" CssClass="img-responsive"></asp:ImageButton>
                    </div>


                </div>
                <div class="col-md-6" style="text-align: center">
                    <div class="btn-group-vertical">
                        <h2>Consultar Inclusiones</h2>
                        <asp:ImageButton runat="server" id="ibtnBuscar" ImageUrl="../Imagenes/Lupa.jpg" CssClass="img-responsive"></asp:ImageButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
