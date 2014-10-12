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
                        <asp:GridView ID="gvInclusiones" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="False">

                            <Columns>
                                <asp:BoundField HeaderText="Boleta" />
                                <asp:BoundField HeaderText="Sede" />
                                <asp:BoundField HeaderText="Codigo" />
                                <asp:BoundField HeaderText="Curso" />
                                <asp:TemplateField HeaderText="Choque">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpgvGrupo" runat="server"></asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Carné" />
                                <asp:BoundField HeaderText="Estudiante" />
                                <asp:BoundField HeaderText="RN" />
                                <asp:TemplateField HeaderText="Choque">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkChoque" AutoPostBack="true" Enabled="false" Checked='<%# Eval("choque") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Ver Comentario" CommandName="Visualizar" />
                                <asp:TemplateField HeaderText="Choque">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpEstado" runat="server">
                                            <asp:ListItem>Pendiente</asp:ListItem>
                                            <asp:ListItem>Aceptado</asp:ListItem>
                                            <asp:ListItem>Rechazado</asp:ListItem>
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
