<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="ProfesoresDatos.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.ProfesoresDatos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container-fluid">
        <div style="margin-right: auto; margin-left:auto;">
            <div class="row" >
                 <div class="col-md-4"></div>               
                 <div class="col-md-4">
                     <h1>Datos de Profesores</h1>
                 </div>
                <div class="col-md-4">
            </div>               
            </div>             
        </div>
        <asp:UpdatePanel ID="UpdatePanel2" runat ="server">
            <ContentTemplate>
                <div class="row">
                    <div class="col-md-1"></div>
                    <div class="col-md-10" style="text-align:center">
                        <asp:GridView ID="gridviewProfesores" runat="server" AutoGenerateColumns="false" CssClass="table table-striped table-hover" HeaderStyle-CssClass="success" AlternatingRowStyle-CssClass="active" OnRowCommand="gridviewProfesores_RowCommand" >
                            <Columns>
                                <asp:BoundField HeaderText="Codigo" DataField="IdProfesor" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Nombre" DataField="Nombre" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Correo" DataField="Correo" HtmlEncode="false" />
                                <asp:BoundField HeaderText="Telefono" DataField="Telefono" HtmlEncode="false" />
                                <asp:ButtonField Text="Editar" CommandName="Editar" />
                                <asp:ButtonField Text="Eliminar" CommandName="Eliminar" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div class="row">
                    <div class="col-md-5"></div>
                    <div class="col-md-2" style="margin:10px; text-align:center;">
                        <asp:Button ID="btnNuevoProfe" CssClass="btn btn-default btn-sm" runat="server" Text="Nuevo" OnClick="btn_NuevoProfeClick" />
                    </div>
                    <div class="col-md-5"></div>
                </div>
                <div class="jumbotron" id="divAgregarProfe" runat="server" Visible="false" > 
                    
                    <div class="row">                        
                        <div class="col-md-12">
                            <div class="col-md-5"> </div>
                            <div class="row" style="margin: 10px;">
                                <div class="col-md-3"> </div>
                                <div class="col-md-2" style="text-align: right;">
                                    <p style="font-size:1em; ">Nombre:</p>
                                </div>
                                <div class="col-md-2">
                                    <input class="form-control" id="txtProfe"   runat="server" type="text" value="" />
                                </div>
                                <div class="col-md-5"> </div>

                            </div>
                            <div class ="row" style="margin: 10px">
                                 <div class="col-md-3"> </div>
                                <div class="col-md-2" style="text-align: right;">
                                    <p style="font-size:1em; ">Correo Electronico:</p>
                                </div>
                                <div class="col-md-2">
                                    <input class="form-control" id="txtCorreo"   runat="server" type="text" value="" />
                                </div>
                                <div class="col-md-5"> </div>

                            </div>
                            <div class="row" style="margin: 10px;">
                                <div class="col-md-3"> </div>
                                <div class="col-md-2" style="text-align: right;">
                                    <p style="font-size:1em; ">Numero de Telefono:</p>
                                </div>
                                <div class="col-md-2">
                                    <input class="form-control" id="txtTelefono"   runat="server" type="text" value="" />
                                </div>
                                <div class="col-md-5"> </div>
                            </div>
                             <div class="row" style="margin: 10px;">
                                 <div class="col-md-6"> </div>
                                 <div class="col-md-3.5">
                                     <asp:Button ID="btnAgregarProfe" runat="server" CssClass="btn btn-success" Text="Guardar" OnClick="btnAgregarProfe_Click" />
                                 </div> 
                                 <div class="col-md-2.5"></div>
                             </div>
                        </div>                        
                    </div>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div> 
</asp:Content>
