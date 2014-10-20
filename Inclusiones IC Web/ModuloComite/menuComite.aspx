<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="menuComite.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.menuComite" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">  
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="row">
                  <div class="col-md-4" style="text-align:center;">                    
                    <asp:LinkButton ID="lbtnAprobarInclusiones" CssClass="btn btn-link" onclick="lbtnAprobarInclusiones_Click" runat="server" >
                          <div class="row">
                              <div >
                                  <img src="../Imagenes/aprobarinclusion.jpg"  class="img-responsive" style="display: inline; max-width:150px; max-height: 100px; text-align:center;" />
                                  <p class="text-primary" style="display: inline;">Aprobar Inclusiones</p>
                              </div>                              
                          </div>                                                    
                      </asp:LinkButton>
                  </div>
                  <div class="col-md-4" style="text-align:center;">                      
                      <asp:LinkButton ID="lbtnAjustes" OnClick="lbtnAjustes_Click" CssClass="btn btn-link" runat="server" >
                          <div class="row">
                              <div>
                                  <img src="../Imagenes/ajustes.jpg" class="img-responsive" style="display: inline; max-width:150px; max-height: 100px; text-align:center;" />
                                  <p class="text-primary" style="display: inline;">Ajustes</p>
                              </div>                              
                          </div>                                                    
                      </asp:LinkButton>
                  </div>

                  <div class="col-md-4" style="text-align:center;">
                      <asp:LinkButton ID="lbtnadminProfes" CssClass="btn btn-link" OnClick="lbtnadminProfes_Click" runat="server" >
                          <div class="row">
                              <div>
                                  <img src="../Imagenes/administrarprofesores.jpg" class="img-responsive"style="display: inline; max-width:150px; max-height: 100px; text-align:center;" />
                                  <p class="text-primary" style="display: inline;">Administrar Profesores</p>
                              </div>                              
                          </div>                                                    
                      </asp:LinkButton>
                   
                  </div>
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>   
        <div class="row">
            <div class="col-md-1"></div>
            <div class="col-md-10">
                <div class="row">
                  <div class="col-md-4" style="text-align:center;">
                      <asp:LinkButton ID="lbtnOferta" CssClass="btn btn-link" runat="server"  onclick="lbtnOferta_Click" >
                          <div class="row">
                              <div >
                                  <img src="../Imagenes/admincursos.png" class="img-responsive" style="display: inline; max-width:150px; max-height: 100px; text-align:center;" />
                                  <p class="text-primary" style="display: inline;">Oferta Académica</p>
                              </div>                              
                          </div>                                                    
                      </asp:LinkButton>
                    
                  </div>
                  <div class="col-md-4" style="text-align:center;">
                      <asp:LinkButton ID="lbtnReportes" OnClick="lbtnReportes_Click" CssClass="btn btn-link" runat="server" >
                          <div class="row">
                              <div>
                                  <img src="../Imagenes/reportes.jpg" class="img-responsive" style="display: inline; max-width:150px; max-height: 100px; text-align:center;" />
                                  <p class="text-primary"  style="display: inline;">Reportes</p>
                              </div>                              
                          </div>                                                    
                      </asp:LinkButton>
                    
                  </div>    
                    <div class="col-md-4" style="text-align:center;">
                      <asp:LinkButton ID="lbtnGrupoNuevo" OnClick="lbtnGrupoNuevo_OnClick" CssClass="btn btn-link" runat="server" >
                          <div class="row">
                              <div>
                                  <img src="../Imagenes/grupo_nuevo.jpg" class="img-responsive" style="display: inline; max-width:150px; max-height: 100px; text-align:center;" />
                                  <p class="text-primary"  style="display: inline;">Grupos Nuevos</p>
                              </div>                              
                          </div>                                                    
                      </asp:LinkButton>
                    
                  </div>               
                </div>
            </div>
            <div class="col-md-1"></div>
        </div>           
    </div>
</asp:Content>
