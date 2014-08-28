<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiantes.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div style="margin-right: auto; margin-left:auto;">
            <div class="row" >
                 <div class="col-md-4"></div>
                <div class="col-md-4" style="text-align: center;">
                    <h2 class="form-signin-heading">Por favor Inicie sesión</h2>
                    <input id="username" runat="server"  class="form-control" placeholder="Nombre de Usuario" required="" autofocus="" />
                    <input id="password" runat="server" type="password" class="form-control" placeholder="Password" required="" />
                    <asp:Button ID="btnIniciar" runat="server" CssClass="btn btn-lg btn-primary btn-block" Text="Iniciar Sesión" OnClick="btnIniciar_Click" />
                </div>                
                 <div class="col-md-4"></div>
               
            </div>             
        </div>
    </div>
</asp:Content>
