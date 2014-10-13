<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="EstadoInclusiones.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.EstadoInclusiones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <div class="page-header">
                <h1>Inclusiones Solicitadas</h1>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-10">
                    <h3>Filtros:</h3>
                </div>
                <div class="col-sm-2"></div>
            </div>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <div class="row">
                        <div class="col-sm-1">
                            <p>Sede:</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="drpSedes" Width="100%" runat="server"></asp:DropDownList>
                        </div>

                        <div class="col-sm-1">
                            <p>Curso:</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="drpCursos" OnSelectedIndexChanged="drpCursos_SelectedIndexChanged" AutoPostBack="true" Width="100%" runat="server"></asp:DropDownList>
                        </div>

                        <div class="col-sm-1">
                            <p>Grupo:</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="drpGrupo" Width="100%" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-sm-1"></div>
            </div>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <div class="table-responsive">
                        <asp:GridView ID="gvInclusiones" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvInclusiones_RowDataBound">

                            <Columns>
                                <asp:BoundField DataField="idBoleta" HeaderText="Boleta" />
                                <asp:BoundField DataField="Sede" HeaderText="Sede" />
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                <asp:BoundField DataField="Curso" HeaderText="Curso" />
                                <asp:TemplateField HeaderText="Grupo">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpCursoBoleta" runat="server">                                            
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Numero" HeaderText="Grupo" />
                                <asp:BoundField DataField="Carnet" HeaderText="Carné" />
                                <asp:BoundField DataField="Persona" HeaderText="Estudiante" />
                                <asp:BoundField DataField="RN" HeaderText="RN" />
                                <asp:TemplateField HeaderText="Choque">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkChoque" AutoPostBack="true" Enabled="false" Checked='<%# Eval("Choque") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Ver Comentario" CommandName="Visualizar" />
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpEstado" runat="server">
                                            <asp:ListItem Value="1">Pendiente</asp:ListItem>
                                            <asp:ListItem Value="2">Aceptado</asp:ListItem>
                                            <asp:ListItem Value="3">Rechazado</asp:ListItem>
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                    </div>
                </div>
                <div class="col-sm-1"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
