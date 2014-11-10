<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="generarreportes.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.generarreportes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     
    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
        <ContentTemplate>
    <!-- Modal -->
            <div class="modal fade" id="FinalizarProceso" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
              <div class="modal-dialog">
                <div class="modal-content">
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">Excel generado.</h4>
                  </div>
                  <div class="modal-body">
                      <h4>El archivo Excel fue generado exitosamente</h4>                                         
                      <%--<asp:Image ID="IMGcargando" ImageAlign="Middle" Visible="False" runat="server" CssClass="img-responsive" ImageUrl="../Imagenes/cargando1.gif"  />--%>
                      <div class="row">
                          <div class="col-sm-5"></div>
                          <div class="col-sm-2">
                              <img id="inngCargar" style="visibility: hidden; width: 80px; height: 80px;"  src="../Imagenes/cargando1.gif" />
                          </div>
                          <div class="col-sm-5"></div>
                      </div>                      
                  </div>
                  <div class="modal-footer">
                      <asp:Button ID="BtnDescargarExcel" OnClientClick="visible();" runat="server" CssClass="btn btn-info" Text="Descargar Excel" OnClick="BtnDescargarExcel_Click" />
                  </div>
                </div>
              </div>
            </div>

            <script type="text/javascript">
                function openModal() {
                    $('#FinalizarProceso').modal('show');
                }
                function closeModal() {
                    $('#FinalizarProceso').modal('close');
                }
            </script>
            <div class="page-header" style="margin-left: 20px">
                <h1>Reportes <small>Admisión y Registro</small></h1>
            </div>    
            <div class="row">
            <div class="col-sm-4" style="text-align: right;"></div>
            <div class="col-sm-6" style="text-align: right;">
                <asp:Button ID="BtnGenerarReporteAdmin" runat="server" CssClass="btn btn-success btn-sm col-sm-6" Text="Generar reporte" OnClick="BtnGenerarReporteAdmin_Click" />                  
            </div>           
        </ContentTemplate>
        </asp:UpdatePanel>
</asp:Content>
