<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiantes.Master" AutoEventWireup="true" CodeBehind="VisualizarBoleta.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloEstudiante.VisualizarBoleta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <div class="page-header">
                <h1>Resultado de Inclusiones</h1>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <div class="row">
                <div class="col-sm-2"></div>
                <div style="border-bottom: solid 1px;" class="col-lg-8 text-center">
                    <h5>Consultar</h5>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <div class="row" style="margin-top: 10px">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="Label1" runat="server" Text="Ingrese carné: "></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtCarnet" AutoPostBack="true" OnTextChanged="txtCarnet_TextChanged" CssClass="form-control" Width="100%" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="Label2" runat="server" Text="Curso:"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:DropDownList ID="drpCursos" AutoPostBack="true" OnSelectedIndexChanged="drpCursos_SelectedIndexChanged" CssClass="form-control" Width="100%" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row">
                <div class="col-sm-2"></div>
                <div style="border-bottom: solid 1px; margin-top:10px;" class="col-lg-8 text-center">
                    <h5>Resultado</h5>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row" style="margin-top: 10px;">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <div class="row">
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="Label3" runat="server" Text="Estado de Inclusión: "></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtEstado" CssClass="form-control" Width="100%" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                        <div class="col-sm-2 text-right">
                            <asp:Label ID="Label4" runat="server" Text="Número de grupo:"></asp:Label>
                        </div>
                        <div class="col-sm-4">
                            <asp:TextBox ID="txtgrupo" CssClass="form-control" Width="100%" Enabled="false" runat="server"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row">
                <div class="col-sm-8">
                </div>
                <div class="col-sm-2 text-right">
                    <asp:Button ID="btnCerrar" CssClass="btn btn-primary" OnClick="btnCerrar_Click" runat="server" Text="Cerrar" />
                </div>
                <div class="col-sm-2"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
