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
             <!-- Modal -->
    <div class="modal fade" id="ModalBoleta" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
      <div class="modal-dialog">
        <div class="modal-content">
          <div class="modal-header">
            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
            <h4 class="modal-title" id="myModalLabel">Boleta de Inclusión</h4>
          </div>
          <div class="modal-body">
              <asp:Label ID="lblNombre" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lblCarnet" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lblCorreo" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lbltelefono" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lblCelular" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lbldia" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lblhora" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lblcarrera" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lblplan" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lblrn" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lbllr" runat="server" Text=""></asp:Label><br />

              <asp:Label ID="lblcomentario" runat="server" Text=""></asp:Label><br />
              <asp:Label ID="lblGrupos" runat="server" Text=""></asp:Label>
          </div>
          <div class="modal-footer">
            <button type="button" class="btn btn-primary" data-dismiss="modal">Cerrar</button>            
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
            $('#ModalBoleta').modal('show');
        }
        function closeModal() {
            $('#ModalBoleta').modal('close');
        }
    </script>



            <div class="row">
                <div class="col-sm-2"></div>
                <div class="col-sm-8">
                    <h3>Filtros:</h3>
                </div>
                <div class="col-sm-2">
                    <asp:Button ID="btnCerrarPeriodo" runat="server" CssClass="btn btn-primary" OnClick="btnCerrarPeriodo_OnClick" Text="Finalizar Periodo" /> 
                </div>
            </div>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <div class="row">
                        <div class="col-sm-1">
                            <p>Sede:</p>
                        </div>
                        <div class="col-sm-3">
                            <asp:DropDownList ID="drpSedes" AutoPostBack="true" OnSelectedIndexChanged="drpSedes_SelectedIndexChanged" Width="100%" runat="server"></asp:DropDownList>
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
                            <asp:DropDownList ID="drpGrupo" AutoPostBack="true" OnSelectedIndexChanged="drpGrupo_SelectedIndexChanged" Width="100%" runat="server"></asp:DropDownList>
                        </div>
                    </div>
                </div>
                <div class="col-sm-1"></div>
            </div>
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <div class="table-responsive">
                        <asp:GridView ID="gvInclusiones" OnRowCommand="gvInclusiones_RowCommand" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvInclusiones_RowDataBound">

                            <Columns>
                                <asp:BoundField DataField="idBoleta" HeaderText="Boleta" />
                                <asp:BoundField DataField="Sede" HeaderText="Sede" />
                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                <asp:BoundField DataField="Curso" HeaderText="Curso" />
                                <asp:TemplateField HeaderText="Grupo">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpCursoBoleta" AutoPostBack="true" OnSelectedIndexChanged="drpCursoBoleta_SelectedIndexChanged" runat="server">                                            
                                        </asp:DropDownList>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="Carnet" HeaderText="Carné" />
                                <asp:BoundField DataField="Persona" HeaderText="Estudiante" />
                                <asp:BoundField DataField="RN" HeaderText="RN" />
                                <asp:TemplateField HeaderText="Choque">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkChoque" Enabled="false" Checked='<%# Eval("Choque") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:ButtonField Text="Ver Comentario" CommandName="Visualizar" />
                                <asp:TemplateField HeaderText="Estado">
                                    <ItemTemplate>
                                        <asp:DropDownList ID="drpEstado" AutoPostBack="true" OnSelectedIndexChanged="drpEstado_SelectedIndexChanged" runat="server">
                                            <asp:ListItem Value="0">Pendiente</asp:ListItem>
                                            <asp:ListItem Value="1">Aceptado</asp:ListItem>
                                            <asp:ListItem Value="2">Rechazado</asp:ListItem>
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
