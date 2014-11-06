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
        <div class="row">            
            <div class="col-sm-6 text-right">
                
            </div>
             <div class="col-sm-6 text-left">
                 
             </div>
        </div>
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="text-align: center">
                    <div class="btn-group-vertical">
                        <p id="TiempoPeriodo" Visible="False" class="form-control alert-info" runat="server">No se encuentra en periodo de Inclusiones</p>
                        <h2>Solicitar Inclusión</h2>
                        <asp:ImageButton runat="server" Enabled="False" OnClick="Unnamed_Click" ID="ibtnSolicitar" ImageUrl="../Imagenes/registro.png" CssClass="img-responsive"></asp:ImageButton>
                    </div>


                </div>
                <div class="col-md-6" style="text-align: center">
                    <div class="btn-group-vertical">
                        <p id="TiempoBusqueda" Visible="False" class="form-control alert-info" runat="server">No se encuentra en periodo de Consulta</p>
                        <h2>Consultar Inclusiones</h2>
                        <asp:ImageButton runat="server" Enabled="False" id="ibtnBuscar" OnClick="ibtnBuscar_Click" ImageUrl="../Imagenes/Lupa.jpg" CssClass="img-responsive"></asp:ImageButton>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
