<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="PeriodoyFechas.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.PeriodoyFechas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header" style="margin-left:20px">
        <h1>Configuración <small>Periodos de recepciónes</small></h1>
    </div>
    <div class="row">
            <div class="col-lg-2"></div>
            <div class="col-md-3" style="margin-bottom:15px;">
                <asp:Label ID="Label1" runat="server" Text="Periodo:" class="col-sm-12 control-label"></asp:Label>                
                <asp:DropDownList ID="DropDownPeriod" runat="server" CssClass="form-control"></asp:DropDownList>
            </div>
            <div class="col-md-2" style="margin-top:20px;">
                <asp:Button ID="BtnNew" runat="server" Text="Crear nuevo periodo" CssClass="btn btn-primary btn-block" />
            </div>
            <div class="col-md-3" style="margin-bottom:15px;">
                <asp:Label ID="Label2" runat="server" Text="Periodo actual:" class="col-sm-12 control-label"></asp:Label>                
                <asp:Label ID="Label4" runat="server" Text="1-2014" class="col-sm-4" AccessKey></asp:Label>                                
            </div>                                        
        </div>
    <div class="jumbotron">
        <div class="container-fluid">
            <h4>Periodo recepción de Inclusiones</h4>
                            
       </div>        
        <div class="row"></div>
    <div class="container-fluid">
            <div class="row">
                <div class="col-lg-3"></div>
                <div class="col-md-4">
                    <asp:Label ID="Label5" runat="server" Text="Desde" class="col-sm-12 control-label"></asp:Label>                
                    <asp:Calendar ID="CalendarFrom" runat="server"></asp:Calendar>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label6" runat="server" Text="Hasta" class="col-sm-12 control-label"></asp:Label>                
                    <asp:Calendar ID="CalendarTo" runat="server"></asp:Calendar>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
        </div>
    <div class="jumbotron">
        <h4>Periodo de recepción de Consultas</h4>
        <div class="container-fluid">
            <div class="row">
                <div class="col-lg-3"></div>
                <div class="col-md-4">
                    <asp:Label ID="Label7" runat="server" Text="Desde" class="col-sm-12 control-label"></asp:Label>                
                    <asp:Calendar ID="Calendar1" runat="server"></asp:Calendar>
                </div>
                <div class="col-md-4">
                    <asp:Label ID="Label8" runat="server" Text="Hasta" class="col-sm-12 control-label"></asp:Label>                
                    <asp:Calendar ID="Calendar2" runat="server"></asp:Calendar>
                </div>
                <div class="col-lg-1"></div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-5"></div>
        <div class="col-lg-2" style="margin-bottom:15px;">
            <asp:Button ID="BtnSave" runat="server" Text="Guardar" CssClass="btn btn-primary btn-block"/>
        </div>        
    </div>
   
    



</asp:Content>