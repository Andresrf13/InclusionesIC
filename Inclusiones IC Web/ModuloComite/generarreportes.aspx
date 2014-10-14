<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="generarreportes.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.generarreportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header" style="margin-left: 20px">
        <h1>Reportes <small>Admisión y Registro</small></h1>
    </div>            
    <div class="col-md-4" style="text-align: right;">
        <asp:Button ID="BtnGenerarReporteAdmin" runat="server" CssClass="btn btn-success btn-sm col-sm-6" Text="Generar reporte" OnClick="BtnGenerarReporteAdmin_Click" />                  
    </div>
</asp:Content>
