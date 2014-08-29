﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="OfertaAcademica.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.OfertaAcademica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4">
                <h1>Oferta Académica</h1>
            </div>
            <div class="col-md-4">
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-2"></div>
                    <div class="col-md-8">
                        <asp:GridView ID="gvOfertaAcademica" runat="server">
                            <Columns>
                                <asp:BoundField HeaderText="Codigo" DataField="" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Sede" DataField="" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Nombre" DataField="" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Capacidad" DataField="" />
                                <asp:BoundField HeaderText="Capacidad Máxima" DataField="" HtmlEncode="false" />
                                <asp:BoundField DataField="" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Grupo" DataField="" HtmlEncode="false" />
                                <asp:BoundField DataField="" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Aula" DataField="" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Profesor" DataField="" HtmlEncode="false" />
                                <asp:ButtonField Text="Editar" />
                                <asp:ButtonField Text="Eliminar" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-2"></div>
                </div>
                <div class="row">
                    <div class="col-md-5"></div>
                    <div class="col-md-2">
                        <asp:Button ID="btnNuevo" CssClass="btn btn-default" runat="server" Text="Nuevo" />
                    </div>
                    <div class="col-md-5"></div>
                </div>
                <div class="jumbotron">
                    <div class="row">
                        <div class="col-md-1"></div>
                        <div class="col-md-10">
                            <div class="row">
                                <div class="col-md-2">
                                    <p>Código:</p>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="drpCursos" runat="server"></asp:DropDownList>
                                </div>
                                <div class="col-md-7">
                                    <asp:TextBox ID="txtNombreCurso" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row">
                                 <div class="col-md-2">
                                    <p>Grupo:</p>
                                </div>
                                <div class="col-md-2">
                                    <asp:TextBox ID="txtGrupo" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-2">
                                    <p><small>Capacidad Máxima:</small></p>
                                </div>
                                <div class="col-md-2">
                                   <input class="form-control" id="txtCapMax"  runat="server" type="number" value="" />
                                </div>
                                <div class="col-md-2">
                                    <p><small>disponible:</small> </p>
                                </div>
                                <div class="col-md-2">
                                    <input class="form-control" id="txtCapDis" runat="server" type="number" value="" />
                                </div>
                            </div>

                        </div>
                        <div class="col-md-1"></div>
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
