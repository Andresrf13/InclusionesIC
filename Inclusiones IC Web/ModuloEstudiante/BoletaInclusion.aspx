﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiantes.Master" AutoEventWireup="true" CodeBehind="BoletaInclusion.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloEstudiante.BoletaInclusion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>    
            
            <script type="text/javascript">
                function visible() {
                    document.getElementById('inngCargar').style.visibility = 'visible';
                }
            </script>

            <!-- jQuery (necessary for Bootstrap's JavaScript plugins) -->
            <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
            <!-- Include all compiled plugins (below), or include individual files as needed -->
            <script src="../Scripts/bootstrap.min.js"></script>
            
            <!-- Modal -->
            <div class="modal fade" id="FinalizarProceso" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
              <div class="modal-dialog">
                <div class="modal-content">
                  <div class="modal-header">
                    <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                    <h4 class="modal-title" id="myModalLabel">Solicitud Enviada</h4>
                  </div>
                  <div class="modal-body">
                      <h4>Al dar clic en enviar, recibirá un PDF de la boleta de inclusión al correo que puso como contacto.</h4>
                      <p>El proceso puede tardar unos segundos, por favor espere mientras generamos el PDF</p>                                          
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
                      <asp:Button ID="BtnImprimirPDF" OnClientClick="visible();" runat="server" CssClass="btn btn-info" Text="Enviar" OnClick="BtnImprimirPDF_Click" />
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

                   
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <div class="page-header">
                        <h1>Boleta de Inclusión - <small>Periodo: <asp:Label ID="lblPeriodoshow" runat="server" Text="Label"></asp:Label></small></h1>
                    </div>
                </div>
            </div>
            
            <div class="row">
                <div class="col-sm-1"></div>
                <div class="col-sm-10">
                    <div class="panel panel-info">
                        <div class="panel-heading">
                            <h3 class="panel-title">Instrucciones generales</h3>
                        </div>
                        <div class="panel-body">
                            <p>- Para solicitar una inclusión, el estudiante debe tener los requisitos aprobados para llevar el curso.</p>
                            <p>- El curso que se solicita incluir no debe provocar un choque de horario en su matrícula.</p>
                            <p>- El curso que se solicita incluir no puede superar el límite de créditos que le restringa el RN de ningún curso.</p>
                        </div>
                    </div>
                </div>
            </div>
            <div id="divBoleta" runat="server" visible="true">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="jumbotron">
                            <div class="form-horizontal">
                                <fieldset>
                                    <legend>Datos personales</legend>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="LabelCarne" runat="server" Text="Carné"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:TextBox ID="TxtCarne" runat="server" AutoPostBack="True" OnTextChanged="TxtCarne_OnTextChanged" required="required" CssClass="col-lg-10 form-control"></asp:TextBox>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="LabelName" runat="server" Text="Nombre completo"></asp:Label>
                                            </div>
                                            <div class="col-sm-10" style="margin-bottom: 15px;">
                                                <asp:TextBox ID="TxtName" required="required" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="validar" ID="RequiredFieldValidator1" runat="server" CssClass="alert-danger" Display="Dynamic" ControlToValidate="TxtName" ErrorMessage="Debe Ingresar un Nombre"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>                                    
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="LabelCellphone" runat="server" Text="Celular"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:TextBox ID="TxtCellphone" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator CssClass="alert-danger" ID="RegularExpressionValidator1" runat="server" Display="Dynamic" ValidationGroup="validar" ControlToValidate="TxtCellphone" ValidationExpression="\d{8}" ErrorMessage="Ingrese solo numeros sin espacios ni otros"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="LabelPhone" runat="server" Text="Teléfono"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:TextBox ID="TxtPhone" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>
                                                <asp:RegularExpressionValidator CssClass="alert-danger" ID="RegularExpressionValidator2" runat="server" Display="Dynamic" ValidationGroup="validar" ControlToValidate="TxtPhone" ValidationExpression="\d{8}" ErrorMessage="Ingrese solo numeros sin espacios ni otros"></asp:RegularExpressionValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:TextBox ID="TxtEmail" required="required" TextMode="Email" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>
                                                <asp:RequiredFieldValidator ValidationGroup="validar" ID="RequiredFieldValidator2" runat="server" CssClass="alert-danger" Display="Dynamic" ControlToValidate="TxtEmail" ErrorMessage="Debe Ingresar un Nombre"></asp:RequiredFieldValidator>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="LabelSede" runat="server" Text="Sede"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px">
                                                <asp:DropDownList ID="drpSedes" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="LabelRegistrationTime" runat="server" Text="Hora de matrícula"></asp:Label>
                                            </div>
                                            <div class="col-lg-5" style="margin-bottom: 15px;">
                                                <asp:DropDownList ID="DropDownRegistrationTimeHour" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="08" />
                                                    <asp:ListItem Text="09" />
                                                    <asp:ListItem Text="10" />
                                                    <asp:ListItem Text="11" />
                                                    <asp:ListItem Text="12" />
                                                    <asp:ListItem Text="13" />
                                                    <asp:ListItem Text="14" />
                                                    <asp:ListItem Text="15" />
                                                    <asp:ListItem Text="16"></asp:ListItem>
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-lg-5" style="margin-bottom: 15px;">
                                                <asp:DropDownList ID="DropDownRegistrationTimeMinute" runat="server" CssClass="form-control">
                                                    <asp:ListItem Value="00" Text="00" />
                                                    <asp:ListItem Text="10" Value="10" />
                                                    <asp:ListItem Text="20" Value="20" />
                                                    <asp:ListItem Text="30" Value="30" />
                                                    <asp:ListItem Text="40" Value="40" />
                                                    <asp:ListItem Text="50" Value="50" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="LabelRegistrationDay" runat="server" Text="Día de matrícula"></asp:Label>
                                            </div>
                                            <div class="col-sm-10" style="margin-bottom: 15px;">
                                                <asp:DropDownList ID="DropDownRegistrationDay" runat="server" CssClass="form-control">
                                                    <asp:ListItem Text="Día 1" Value="1" />
                                                    <asp:ListItem Text="Día 2" Value="2" />
                                                    <asp:ListItem Text="Día 3" Value="3" />
                                                </asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label1" runat="server" Text="Carrera"></asp:Label>
                                            </div>
                                            <div class="col-sm-10" style="margin-bottom: 15px;">
                                                <asp:DropDownList ID="drpCarrera" OnSelectedIndexChanged="drpCarrera_SelectedIndexChanged" AutoPostBack="true" runat="server" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label2" runat="server" Text="Plan de Estudios"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:DropDownList ID="drpPlan" CssClass="form-control" runat="server" OnSelectedIndexChanged="drpPlan_SelectedIndexChanged"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>


                    <div class="col-sm-6">
                        <div class="jumbotron">
                            <div class="form-horizontal">
                                <fieldset>
                                    <legend>Curso en el que desea solicitar Inclusión</legend>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-1">
                                                <asp:Label ID="Label3" runat="server" Text="Curso"></asp:Label>
                                            </div>
                                            
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:DropDownList ID="drpCursos" AutoPostBack="true" runat="server" OnSelectedIndexChanged="drpCursos_SelectedIndexChanged" CssClass="form-control"></asp:DropDownList>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label4" runat="server" Text="Grupo"></asp:Label>
                                            </div>
                                            <div class="col-sm-5" style="margin-bottom: 15px;">
                                                <asp:DropDownList ID="drpGrupo" runat="server" CssClass="form-control">
                                                </asp:DropDownList>
                                            </div>
                                            <div class="col-sm-2">
                                                <asp:Button ID="btnAddGrupo" CssClass="btn btn-default btn-sm" runat="server" OnClick="btnAddGrupo_Click" Text="Agregar" />
                                            </div>
                                            <div class="col-sm-3" style="text-align: right;">
                                                <asp:Button ID="btnGrupoNuevo" OnClick="btnGrupoNuevo_Click" runat="server" CssClass="btn btn-info btn-xs" Text="Grupo Nuevo" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label5" runat="server" Text="Por Orden de prioridad"></asp:Label>
                                            </div>
                                            <div class="col-sm-8" style="margin-bottom: 15px;">
                                                <asp:GridView ID="gvGrupos" CssClass="table table-striped table-hover" runat="server" AutoGenerateColumns="False" OnRowCommand="gvGrupos_RowCommand">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Grupo" DataField="show" />
                                                        <asp:TemplateField HeaderText="Choque">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="chkChoque" AutoPostBack="true" OnCheckedChanged="chkChoque_CheckedChanged" Checked='<%# Eval("choque") %>' runat="server" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:ButtonField Text="Eliminar" CommandName="Eliminar" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="col-sm-2"></div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label6" runat="server" Text="¿Tiene RN?"></asp:Label>
                                            </div>
                                            <div class="col-sm-4">
                                                <div>
                                                    <asp:RadioButton ID="rbsiRN" Text="Sí" runat="server" OnCheckedChanged="rbnoRN_CheckedChanged" GroupName="RNRadioButon" AutoPostBack="true" />
                                                    <asp:RadioButton ID="rbnoRN" Text="No" runat="server" Checked="true" OnCheckedChanged="rbnoRN_CheckedChanged" AutoPostBack="true" GroupName="RNRadioButon" />

                                                </div>
                                            </div>
                                            <div id="divRN" runat="server" visible="false">
                                                <div class="col-sm-3">
                                                    <asp:Label ID="Label9" runat="server" Text="Número RN:"></asp:Label>
                                                </div>
                                                <div class="col-sm-3" style="margin-bottom: 15px">
                                                    <asp:DropDownList ID="drpNoRN" runat="server" CssClass="form-control">
                                                        <asp:ListItem Value="2">2</asp:ListItem>
                                                        <asp:ListItem Value="3">3</asp:ListItem>
                                                        <asp:ListItem Value="4">4</asp:ListItem>
                                                        <asp:ListItem Value="5">5</asp:ListItem>
                                                        <asp:ListItem Value="6">6</asp:ListItem>
                                                        <asp:ListItem Value="7">7</asp:ListItem>
                                                        <asp:ListItem Value="8">8</asp:ListItem>
                                                        <asp:ListItem Value="9">9</asp:ListItem>
                                                        <asp:ListItem Value="10">10</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-5">
                                                <asp:Label ID="Label7" runat="server" Text="¿Cumple con los requisitos para esta inclusión?"></asp:Label>
                                            </div>

                                            <div class="col-sm-4" style="margin-bottom: 15px;">
                                                <div>
                                                    <asp:RadioButton ID="rbSiLR" Text="Sí" runat="server" GroupName="LRRadioButon" AutoPostBack="true" OnCheckedChanged="rbSiLR_CheckedChanged" />
                                                    <asp:RadioButton ID="rbNoLR" Text="No" runat="server" Checked="true" GroupName="LRRadioButon" AutoPostBack="true" OnCheckedChanged="rbSiLR_CheckedChanged" />
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="divLRPeriodo" visible="false" style="margin: 10px;" runat="server">
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:Label ID="Label10" runat="server" Text="Cumple con los requisitos porque:"></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:RadioButton ID="rbSiLRCursos" Text="Ganó todos los cursos que son requisito" runat="server" Checked="true" GroupName="LRProcRadioButon" />
                                            </div>
                                        </div>
                                        <div class="row">
                                            <div class="col-sm-12">
                                                <asp:RadioButton ID="rbSiLRProceso" Text="Hizo el proceso de levantamiento de requisitos en el período" runat="server" GroupName="LRProcRadioButon" />
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-sm-6" style="text-align: center">
                                            <asp:Label ID="Label8" runat="server" Text="Comentario"></asp:Label>
                                            <asp:TextBox ID="TxtComentario" runat="server" CssClass="col-lg-10 form-control" TextMode="MultiLine"></asp:TextBox>
                                        </div>
                                        <div class="col-sm-6" style="text-align: center">
                                            <asp:Button ID="btnVisualizar" runat="server" CssClass="btn btn-success btn-sm" Text="Visualizar Boleta" Enabled="false" OnClick="btnVisualizar_Click" />
                                        </div>
                                    </div>

                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <%--<-- VISUALIZADOR -->--%>
            <div id="divVisualizador" runat="server" visible="false">
                <div class="row">
                    <div class="col-sm-6">
                        <div class="jumbotron">
                            <div class="form-horizontal">
                                <fieldset>
                                    <legend>Datos personales</legend>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label11" runat="server" Text="Nombre completo: "></asp:Label>
                                            </div>
                                            <div class="col-sm-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizadorNombre" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label12" runat="server" Text="Carné"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizadorCarne" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label13" runat="server" Text="Celular"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarCelular" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label14" runat="server" Text="Teléfono"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarTelefono" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label15" runat="server" Text="Email"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarEmail" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label16" runat="server" Text="Sede"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px">
                                                <asp:Label ID="LabelVisualizarSede" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label17" runat="server" Text="Hora de matrícula"></asp:Label>
                                            </div>
                                            <div class="col-lg-1" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarHora" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label18" runat="server" Text="Día de matrícula"></asp:Label>
                                            </div>
                                            <div class="col-sm-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarDiaMatricula" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                    <div class="col-sm-6">
                        <div class="jumbotron">
                            <div class="form-horizontal">
                                <fieldset>
                                    <legend>Curso en el que desea solicitar Inclusión</legend>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label19" runat="server" Text="Carrera"></asp:Label>
                                            </div>
                                            <div class="col-sm-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarCarrera" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label20" runat="server" Text="Plan de Estudios"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarPlan" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label21" runat="server" Text="Curso"></asp:Label>
                                            </div>
                                            <div class="col-lg-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarCurso" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label22" runat="server" Text="Grupos"></asp:Label>
                                            </div>
                                            <div class="col-sm-10" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarGrupo" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                            </div>
                                            <div class="col-sm-8" style="margin-bottom: 15px;">
                                            </div>
                                            <div class="col-sm-2"></div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-2">
                                                <asp:Label ID="Label24" runat="server" Text="¿Tiene RN?"></asp:Label>
                                            </div>
                                            <div class="col-sm-4">
                                                <asp:Label ID="LabelVisualizarRN" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                            <div id="div1" runat="server" visible="true">
                                                <div class="col-sm-3">
                                                    <asp:Label ID="Label25" runat="server" Text="Numero RN:"></asp:Label>
                                                </div>
                                                <div class="col-sm-3" style="margin-bottom: 15px">
                                                    <asp:Label ID="LabelVisualizarNumeroRN" runat="server" Text="" CssClass=""></asp:Label>
                                                </div>
                                            </div>

                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="form-group">
                                            <div class="col-sm-7">
                                                <asp:Label ID="Label26" runat="server" Text="¿Cumple con los requisitos para esta inclusión?"></asp:Label>
                                            </div>

                                            <div class="col-sm-4" style="margin-bottom: 15px;">
                                                <asp:Label ID="LabelVisualizarRequisitos" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                    <div id="div2" runat="server">
                                        <div class="row">
                                            <div class="col-sm-6">
                                                <asp:Label ID="Label27" runat="server" Text="Cumple con los requisitos porque:"></asp:Label>
                                            </div>
                                            <div class="col-sm-6">
                                                <asp:Label ID="LabelVisualizarCumpleRequisitos" runat="server" Text="" CssClass=""></asp:Label>
                                            </div>
                                        </div>
                                        <div class="row">
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 10px;">
                                        <div class="col-sm-4">
                                            <asp:Label ID="Label28" runat="server" Text="Comentario"></asp:Label>

                                        </div>
                                        <div class="col-sm-8">
                                            <asp:Label ID="LabelVisualizarComentario" runat="server" Text="" CssClass=""></asp:Label>
                                        </div>
                                    </div>
                                    <div class="row" style="margin-top: 20px; margin-left: 80px;">
                                        <div class="col-sm-4" style="text-align: center">
                                            <asp:Button ID="BtnSuccess" runat="server" OnClick="BtnSuccess_Click" CssClass="btn btn-success btn-sm col-sm-6" Text="Enviar" />
                                        </div>
                                        <div class="col-sm-4" style="text-align: center">
                                        </div>
                                        <div class="col-sm-4" style="text-align: center">
                                            <asp:Button ID="BtnRegresar" runat="server" CssClass="btn btn-danger btn-sm col-sm-6" Text="Regresar" OnClick="BtnRegresar_Click" />
                                        </div>
                                    </div>

                                    <div id="divpdf" runat="server" visible="false">
                                        <div class="row">
                                            <div class="col-sm-12" style="text-align: center">                                                
                                            </div>
                                        </div>

                                    </div>
                                </fieldset>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>


    
</asp:Content>
