<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiantes.Master" AutoEventWireup="true" CodeBehind="VisualizarBoleta.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloEstudiante.VisualizarBoleta" %>
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

    
</asp:Content>
