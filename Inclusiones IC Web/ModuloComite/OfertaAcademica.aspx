<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="OfertaAcademica.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.OfertaAcademica" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4">
            </div>
            <div class="col-md-4" style="text-align: center">
                <h1>Oferta Académica</h1>
            </div>
            <div class="col-md-4">
            </div>
        </div>

        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10" style="text-align:center">
                        <asp:GridView ID="gvOfertaAcademica" OnRowCommand="gvOfertaAcademica_RowCommand" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover" HeaderStyle-CssClass="success" AlternatingRowStyle-CssClass="active" >
                            <Columns>
                                <asp:BoundField HeaderText="Codigo" DataField="Codigo" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Sede" DataField="Sede" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Capacidad" DataField="Disponible" />
                                <asp:BoundField HeaderText="Capacidad Máxima" DataField="Maximo" HtmlEncode="false" />
                                <asp:BoundField DataField="" HtmlEncode="false" />
                                <asp:BoundField HeaderText="# Grupo" DataField="Grupo" HtmlEncode="false" />
                                <asp:BoundField DataField="Horario" HeaderText="Aula y Horario" HtmlEncode="false" />                                
                                <asp:BoundField HeaderText="Profesor" DataField="Profesor" HtmlEncode="false" />
                                <asp:ButtonField Text="Editar" CommandName="Editar" />
                                <asp:ButtonField Text="Eliminar" CommandName="Eliminar" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="col-md-1"></div>
                </div>
                <div class="row">
                    <div class="col-md-5"></div>
                    <div class="col-md-2" style="margin:10px; text-align:center;">
                        <asp:Button ID="btnNuevo" CssClass="btn btn-default btn-sm" runat="server" Text="Nuevo" OnClick="btnNuevo_Click" />
                    </div>
                    <div class="col-md-5"></div>
                </div>
                <div class="jumbotron" id="divAgregar" runat="server" Visible="false" > 
                    
                    <div class="row">                        
                        <div class="col-md-12">
                            <div class="row" style="margin: 10px;">
                                <div class="col-md-1" style="text-align:right;">
                                    <p style="font-size:1em;">Código curso:</p>
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="drpCursos" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="drpCursos_SelectedIndexChanged" ></asp:DropDownList>
                                </div>
                                <div class="col-md-8">
                                    <asp:TextBox ID="txtNombreCurso" Enabled="false" CssClass="form-control" runat="server"></asp:TextBox>
                                </div>
                            </div>
                            <div class="row" style="margin: 10px;">
                                 <div class="col-md-1" style="text-align: right;">
                                    <p style="font-size:1em; ">Grupo:</p>
                                </div>
                                <div class="col-md-2">
                                    <input class="form-control" id="txtGrupo"   runat="server" type="number" value="" />
                                </div>
                                <div class="col-md-2" style="text-align: right;">
                                    <p style="font-size:1em;">Capacidad Máxima:</p>
                                </div>
                                <div class="col-md-3">
                                   <input class="form-control" id="txtCapMax"   runat="server" type="number" value="" />
                                </div>
                                <div class="col-md-1" style="text-align: right;">
                                    <p style="font-size:1em;">disponible:</p>                                    
                                </div>
                                <div class="col-md-3">
                                    <input class="form-control" id="txtCapDis"  runat="server" type="number" value="" />
                                </div>
                            </div>

                             <div class="row" style="margin: 10px;">
                                 <div class="col-md-1" style="text-align: right;">
                                    <p style="font-size:1em; ">Sede:</p>
                                </div>
                                <div class="col-md-2">
                                    <asp:DropDownList ID="drpSede" runat="server" CssClass="form-control"></asp:DropDownList>
                                </div>
                                <div class="col-md-2" style="text-align: right;">
                                    <p style="font-size:1em;">Horario y Aula:</p>
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txthoraaula" CssClass="form-control"   TextMode="MultiLine" runat="server"></asp:TextBox>
                                </div>
                                <div class="col-md-1" style="text-align: right;">
                                    <p style="font-size:1em;">profesor:</p>                                    
                                </div>
                                <div class="col-md-3">
                                    <asp:DropDownList ID="drpProfesores" CssClass="form-control"  runat="server"></asp:DropDownList>
                                </div>
                            </div>
                             <div class="row" style="margin: 10px;">
                                 <div class="col-md-5">

                                 </div>
                                 <div class="col-md-2">
                                     <asp:Button ID="btnAgregar" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnAgregar_Click" />
                                 </div>
                                 <div class="col-md-5">

                                 </div>
                             </div>
                        </div>                        
                    </div>
                </div>

            </ContentTemplate>
        </asp:UpdatePanel>

    </div>
</asp:Content>
