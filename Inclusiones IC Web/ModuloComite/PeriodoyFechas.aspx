<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="PeriodoyFechas.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.PeriodoyFechas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="page-header" style="margin-left: 20px">
        <h1>Configuración <small>Periodos de recepciónes</small></h1>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-md-8">
                </div>
                <div class="col-md-4" style="text-align: right;">
                    <asp:Label ID="Label2" runat="server" Text="Periodo actual:" CssClass="alert-link"></asp:Label>
                    <asp:Label ID="lblPeridoActual" runat="server" Text="1-2014" CssClass="alert alert-dismissable alert-link"></asp:Label>
                </div>
            </div>
            <div class="row" style="margin: 10px;">
                <div class="col-lg-1"></div>
                <div class="col-md-1" style="margin-bottom: 15px;">
                    <asp:Label ID="Label1" runat="server" Text="Periodo:" CssClass="col-sm-12 control-label"></asp:Label>
                </div>
                <div class="col-md-2">
                    <asp:DropDownList ID="drpPeriodo" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpPeriodo_SelectedIndexChanged"></asp:DropDownList>
                </div>
                <div class="col-md-2">
                    <asp:CheckBox ID="chkActivo" runat="server" CssClass="radio" Text="Período Actual" OnCheckedChanged="chkActivo_CheckedChanged" AutoPostBack="true" />
                </div>
                <div class="col-md-2">
                    <asp:Button ID="BtnNew" runat="server" Text="Crear nuevo período" CssClass="btn btn-primary btn-block" OnClick="BtnNew_Click" />
                </div>
                <div id="divcrearNuevo" runat="server" visible="false">
                    <div class="col-md-2">
                        <asp:Label ID="Label3" runat="server" Text="Nombre de nuevo período:"></asp:Label>
                    </div>
                    <div class="col-md-2">
                        <input class="form-control" id="txtnuevoPeriodo" runat="server" type="text" value="" />
                    </div>
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
                            <asp:Label ID="Label5" runat="server" Text="Desde" CssClass="col-sm-12 control-label"></asp:Label>
                            <asp:Calendar ID="calRecepcionDesde" runat="server"></asp:Calendar>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="Label6" runat="server" Text="Hasta" CssClass="col-sm-12 control-label"></asp:Label>
                            <asp:Calendar ID="calRecepcionHasta" runat="server"></asp:Calendar>
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
                            <asp:Label ID="Label7" runat="server" Text="Desde" CssClass="col-sm-12 control-label"></asp:Label>
                            <asp:Calendar ID="calConsultaDesde" runat="server"></asp:Calendar>
                        </div>
                        <div class="col-md-4">
                            <asp:Label ID="Label8" runat="server" Text="Hasta" CssClass="col-sm-12 control-label"></asp:Label>
                            <asp:Calendar ID="calConsultaHasta" runat="server"></asp:Calendar>
                        </div>
                        <div class="col-lg-1"></div>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-lg-5"></div>
                <div class="col-lg-2" style="margin-bottom: 15px;">
                    <asp:Button ID="BtnSave" runat="server" Text="Guardar" OnClick="BtnSave_Click" CssClass="btn btn-primary btn-block" />
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>







</asp:Content>
