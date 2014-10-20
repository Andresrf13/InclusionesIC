<%@ Page AutoEventWireup="true" CodeBehind="AsignarGrupoNuevo.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.AsignarGrupoNuevo" Language="C#" MasterPageFile="~/Comite.Master" Title="" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-sm-1"></div>
        <div class="col-sm-10">
            <div class="page-header">
                <h1>Reasignar grupo Nuevo</h1>
            </div>
        </div>
    </div>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>

            <!-- Modal -->
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title" id="myModalLabel">
                                <asp:Label ID="txtTitulo" runat="server" Text="Label"></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="txtCuerpo" runat="server" Text="Label"></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-default" data-dismiss="modal">Aceptar</button>
                        </div>
                    </div>
                </div>
            </div>

            <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
            <!-- Include all compiled plugins (below), or include individual files as needed -->
            <script src="../Scripts/bootstrap.min.js"></script>

            <script type="text/javascript">
                function openModal() {
                    $('#myModal').modal('show');
                }
                function closeModal() {
                    $('#myModal').modal('close');
                }
            </script>

            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-5">
                    <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-sm-2" style="text-align: right">
                            <h4>Curso:</h4>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpCursos" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpCursos_OnSelectedIndexChanged" Width="100%" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2"></div>
                    </div>
                </div>
                <div class="col-sm-5">
                    <div class="row">
                        <div class="col-sm-2"></div>
                        <div class="col-sm-2" style="text-align: right">
                            <h4>Grupos:</h4>
                        </div>
                        <div class="col-sm-6">
                            <asp:DropDownList ID="drpGrupos" CssClass="form-control" Width="100%" runat="server"></asp:DropDownList>
                        </div>
                        <div class="col-sm-2">
                            <asp:Button ID="btnAsignar" CssClass="btn btn-primary btn-sm" runat="server" Text="Asignar" OnClick="btnAsignar_Click" />
                        </div>
                    </div>
                </div>
                <div class="col-sm-1"></div>
            </div>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <asp:GridView ID="gvGruposNuevos" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="False">

                        <Columns>
                            <asp:BoundField DataField="idBoleta" HeaderText="Boleta" />
                            <asp:BoundField DataField="Sede" HeaderText="Sede" />
                            <asp:BoundField DataField="Curso" HeaderText="Curso" />
                            <asp:BoundField DataField="Numero" HeaderText="Grupo" />
                            <asp:BoundField DataField="Carnet" HeaderText="Carné" />
                            <asp:BoundField DataField="Persona" HeaderText="Estudiante" />
                            <asp:BoundField DataField="RN" HeaderText="RN" />
                            <asp:BoundField DataField="Estado" HeaderText="Estado" />
                        </Columns>

                    </asp:GridView>
                </div>
                <div class="col-sm-1"></div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
