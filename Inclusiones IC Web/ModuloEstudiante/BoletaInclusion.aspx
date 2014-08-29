<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiantes.Master" AutoEventWireup="true" CodeBehind="BoletaInclusion.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloEstudiante.BoletaInclusion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-10">
            <div class="page-header">
                <h1>Boleta de Inclusión - <small> Datos personales</small></h1>
            </div>
        </div>

    </div>
    <div class="row">
        <div class="col-md-1"></div>
        <div class="col-md-10">
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
    <div class="col-md-6">
        <div class="jumbotron">
            <form class="form-horizontal">
                <fieldset>
                    <legend>Datos personales</legend>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="LabelName" runat="server" Text="Nombre completo"></asp:Label>
                            </div>      
                        <div class="col-md-10" style="margin-bottom:15px;">
                            <asp:TextBox ID="TxtName" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>                        
                        </div>
                        </div>
                    </div>                  
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="LabelCarne" runat="server" Text="Carné"></asp:Label>
                            </div>                     
                            <div class="col-lg-10" style="margin-bottom:15px;">
                                <asp:TextBox ID="TxtCarne" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>                        
                            </div>
                        </div>
                    </div>   
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="LabelCellphone" runat="server" Text="Celular"></asp:Label>
                            </div>                        
                            <div class="col-lg-10" style="margin-bottom:15px;">
                                <asp:TextBox ID="TxtCellphone" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>                        
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="LabelPhone" runat="server" Text="Teléfono"></asp:Label>
                            </div>
                            <div class="col-lg-10" style="margin-bottom:15px";>
                                <asp:TextBox ID="TxtPhone" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>                        
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
                            </div>                        
                            <div class="col-lg-10" style="margin-bottom:15px;">
                                <asp:TextBox ID="TxtEmail" runat="server" CssClass="col-lg-10 form-control"></asp:TextBox>                        
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">                        
                            <div class="col-md-2">
                                <asp:Label ID="LabelSede" runat="server" Text="Sede"></asp:Label>
                            </div>                        
                            <div class="col-lg-10" style="margin-bottom:15px">
                                <asp:DropDownList ID="DropDownSede" runat="server" CssClass="form-control">
                                <asp:ListItem Text="Cartago" />
                                <asp:ListItem Text="Centro Académico" />
                                <asp:ListItem Text="Limón" />
                                <asp:ListItem Text="Alajuela"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>                    
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="LabelRegistrationTime" runat="server" Text="Hora de matrícula"></asp:Label>
                            </div>                        
                            <div class="col-lg-5" style="margin-bottom:15px;"> 
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
                            <div class="col-lg-5" style="margin-bottom:15px;">
                                <asp:DropDownList ID="DropDownRegistrationTimeMinute" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="00" />
                                    <asp:ListItem Text="15" />
                                    <asp:ListItem Text="30" />
                                    <asp:ListItem Text="45"></asp:ListItem>
                                </asp:DropDownList>
                            </div>                            
                        </div>               
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="LabelRegistrationDay" runat="server" Text="Día de matrícula"></asp:Label>
                            </div>
                            <div class="col-md-10" style="margin-bottom:15px;">
                                <asp:DropDownList ID="DropDownRegistrationDay" runat="server" CssClass="form-control">
                                    <asp:ListItem Text="Día 1" />                                                                        
                                    <asp:ListItem Text="Día 2"></asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>                         
                </fieldset>
            </form>
        </div>
    </div>
    <div class="col-md-6">
        <div class="jumbotron">
            <form class="form-horizontal">
                <fieldset>
                    <legend>Curso en el que desea solicitar Inclusión</legend>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="Label1" runat="server" Text="Carrera"></asp:Label>
                            </div>      
                        <div class="col-md-10" style="margin-bottom:15px;">
                            <asp:DropDownList ID="drpCarrera" runat="server"></asp:DropDownList>  
                        </div>
                        </div>
                    </div>                  
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="Label2" runat="server" Text="Plan de Estudios"></asp:Label>
                            </div>                     
                            <div class="col-lg-10" style="margin-bottom:15px;">
                                <asp:DropDownList ID="drpPlan" runat="server"></asp:DropDownList>                        
                            </div>
                        </div>
                    </div>   
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="Label3" runat="server" Text="Curso"></asp:Label>
                            </div>                        
                            <div class="col-lg-10" style="margin-bottom:15px;">
                                <asp:DropDownList ID="drpCursos" runat="server"></asp:DropDownList>                        
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="Label4" runat="server" Text="Grupo"></asp:Label>
                            </div>
                            <div class="col-md-5" style="margin-bottom:15px";>
                                <asp:DropDownList ID="drpGrupo" runat="server"></asp:DropDownList>                        
                            </div>
                            <div class="col-md-2">
                                <asp:Button ID="btnAddGrupo" CssClass="btn btn-default btn-sm" runat="server" Text="Agregar" />
                            </div>
                            <div class="col-md-3" style="text-align:right;">
                                <asp:CheckBox ID="chkNUevo" CssClass="checkbox" Text="Grupo Nuevo" runat="server" />
                            </div>                                    
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-2">
                                <asp:Label ID="Label5" runat="server"  Text="Por Orden de prioridad"></asp:Label>
                            </div>                        
                            <div class="col-md-8" style="margin-bottom:15px;">
                                <asp:GridView ID="gvGrupos" runat="server" AutoGenerateColumns="False">
                                    <Columns>
                                        <asp:BoundField HeaderText="Grupo" />
                                        <asp:CheckBoxField HeaderText="Choque de Horario" />
                                        <asp:ButtonField Text="Eliminar" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <div class="col-md-2"></div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="form-group">                        
                            <div class="col-md-2">
                                <asp:Label ID="Label6" runat="server" Text="¿Tiene RN?"></asp:Label>
                            </div>        
                            <div class="col-md-4">
                                <div>
                                    <asp:RadioButton ID="rbnoRN"  Text="No" runat="server" Checked="true" OnCheckedChanged="rbnoRN_CheckedChanged" GroupName="RNRadioButon" />
                                    <asp:RadioButton ID="rbsiRN"  Text="Sí" runat="server" OnCheckedChanged="rbnoRN_CheckedChanged" GroupName="RNRadioButon" />
                                    
                                </div>
                            </div>  
                            <div id="divRN" runat="server" >
                                <div class="col-md-2">
                                <asp:Label ID="Label9" runat="server" Text="Numero RN:"></asp:Label>
                            </div>                
                            <div class="col-md-4" style="margin-bottom:15px">
                                <asp:DropDownList ID="drpNoRN" runat="server">
                                    <asp:ListItem Value="2">2</asp:ListItem>
                                    <asp:ListItem Value="3">3</asp:ListItem>
                                    <asp:ListItem Value="4">4</asp:ListItem>                                    
                                </asp:DropDownList>
                            </div>
                            </div>
                            
                        </div>
                    </div>                    
                    <div class="row">
                        <div class="form-group">
                            <div class="col-md-8">
                                <asp:Label ID="Label7" runat="server" Text="¿Necesita levantar requisitos para esta inclusión?"></asp:Label>
                            </div>                        
                            <div class="col-md-4" style="margin-bottom:15px;"> 
                                <div>
                                    <asp:RadioButton ID="rbNoLR"  Text="No" runat="server" Checked="true"  GroupName="LRRadioButon" />
                                    <asp:RadioButton ID="rbSiLR"  Text="Sí" runat="server"  GroupName="LRRadioButon" />                                    
                                </div>
                            </div>                                                        
                        </div>               
                    </div>
                    <div class="row" id="divLRPeriodo">
                        <div class="col-md-8">
                                <asp:Label ID="Label10" runat="server" Text="¿Hizo levantamiento de requisitos para este período?"></asp:Label>
                            </div>   
                            <div  class="col-md-4" style="margin-bottom:15px;">
                                <div>
                                    <asp:RadioButton ID="rbNoLRProceso"  Text="No" runat="server" Checked="true"  GroupName="LRProcRadioButon" />
                                    <asp:RadioButton ID="rbSiLRProceso"  Text="Sí" runat="server"  GroupName="LRProcRadioButon" />                                    
                                </div>
                            </div>
                    </div>    
                    <div class="row">
                        <div class="col-md-6" style="text-align:center">
                            <asp:Button ID="btnComentario" runat="server"  CssClass="btn btn-success btn-sm" Text="Agregar Comentario" />
                        </div>
                        <div class="col-md-6" style="text-align:center">
                            <asp:Button ID="btnVisualizar" runat="server"  CssClass="btn btn-success btn-sm" Text="Visualizar Boleta" />
                        </div>
                    </div>                     
                </fieldset>
            </form>
        </div>
    </div>
</asp:Content>
