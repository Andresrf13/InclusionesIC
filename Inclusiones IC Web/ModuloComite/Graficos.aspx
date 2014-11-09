<%@ Page Title="" Language="C#" MasterPageFile="~/Comite.Master" AutoEventWireup="true" CodeBehind="Graficos.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.Graficos" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="row">
                <div class="row">
                    <div class="col-sm-3">
                        <h2 class="text-center">Graficos y Reportes</h2>
                        <div class="list-group">
                            <asp:Button ID="btnGrafico1" Width="100%" CssClass="list-group-item" runat="server" Text="Inclusiones por Periodo" OnClick="btnGrafico1_OnClick" />
                            <asp:Button ID="btnGrafico2" Width="100%" CssClass="list-group-item" runat="server" Text="Rendimiento de Inclusiones" OnClick="btnGrafico2_OnClick" />
                            <asp:Button ID="btnGrafico3" Width="100%" CssClass="list-group-item" runat="server" Text="Inclusiones de Estudiante" OnClick="btnGrafico3_OnClick" />
                            <asp:Button ID="btnGrafico4" Width="100%" CssClass="list-group-item" runat="server" Text="Historial Inclusiones de Estudiante" OnClick="btnGrafico4_OnClick" />
                        </div>
                    </div>
                    <div class="col-sm-9">
                        <asp:MultiView ID="MultiView1" runat="server">
                            <asp:View ID="vGrafico1" runat="server">
                                <h2 class="text-center">Inclusiones aprobadas en un periodo</h2>
                                <div class="row">
                                    <div class="col-sm-4"></div>
                                    <div class=" col-sm-4 text-center">
                                        <h5>Seleccione un periodo:</h5>
                                        <asp:DropDownList ID="drpPeriodoGrafico1" OnSelectedIndexChanged="drpPeriodoGrafico1_OnSelectedIndexChanged" AutoPostBack="True" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-4"></div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 text-center">
                                        <asp:Chart ID="Grafico1" runat="server" Width="800" >
                                            <Series>
                                                <asp:Series Name="Series1"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea  Name="ChartArea1"></asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="vGrafico2" runat="server">
                                <h2 class="text-center">Inclusiones aprobadas vs Rendimiento</h2>
                                <div class="row">
                                    <div class="col-sm-3"></div>
                                    <div class="col-sm-3 text-center">
                                        <h5>Seleccione un periodo:</h5>
                                        <asp:DropDownList ID="drpPeriodoGrafico2" AutoPostBack="True" OnSelectedIndexChanged="drpPeriodoGrafico2_OnSelectedIndexChanged" CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class="col-sm-3 text-center">
                                        <h5>Seleccione un periodo:</h5>
                                        <asp:DropDownList ID="drpCursoGrafico2" AutoPostBack="True" OnSelectedIndexChanged="drpPeriodoGrafico2_OnSelectedIndexChanged"  CssClass="form-control" runat="server"></asp:DropDownList>
                                    </div>
                                <div class="col-sm-3"></div>
                                </div>                                
                                <div class="row">
                                    <div class="col-sm-12 text-center">
                                        <asp:Chart ID="Grafico2" runat="server" Width="800" >
                                            <Series>
                                                <asp:Series Name="Series1"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea  Name="ChartArea1"></asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </asp:View>
                            <asp:View ID="vGrafico3" runat="server">
                                <h2 class="text-center">Inclusiones por estudiante por periodo</h2>
                                <div class="row">
                                    
                                    <div class="col-sm-3"></div>
                                    <div class="col-sm-3">
                                        <h5>Seleccione un periodo:</h5>
                                        <asp:DropDownList ID="drpPeriodoGrafico3" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="drpPeriodoGrafico3_OnSelectedIndexChanged" runat="server"></asp:DropDownList>
                                    </div>
                                    <div class=" col-sm-3 text-center">
                                        <h5>Ingrese un carné:</h5>
                                        <asp:TextBox ID="txtCarnetGrafico3" AutoPostBack="True" OnTextChanged="txtCarnetGrafico3_OnTextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                    <div class="col-sm-3"></div>
                                </div>
                                <div class="row" style="margin: 10px;">
                                    <div class="col-sm-2"></div>
                                    <div class="col-sm-8">
                                        <asp:GridView ID="Grid3"  Width="100%" CssClass="table table-responsive" runat="server" AutoGenerateColumns="False">
                                            <Columns>
                                                <asp:BoundField DataField="Codigo" HeaderText="Codigo" />
                                                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                                                <asp:BoundField DataField="Numero" HeaderText="Numero" />
                                                <asp:BoundField DataField="Estado" HeaderText="Estado" />
                                            </Columns>
                                        </asp:GridView> 
                                    </div>
                                    <div class="col-sm-2"></div>
                                </div>
                            </asp:View>
                            <asp:View ID="vGrafico4" runat="server">
                                <h2 class="text-center">Comportamiento de inclusiones para un estudiante</h2>
                                <div class="row">
                                    <div class="col-sm-4"></div>                                    
                                    <div class="col-sm-4 text-center">
                                        <h5>Ingrese un carné:</h5>
                                         <asp:TextBox ID="txtcarnetGrafico4" AutoPostBack="True" OnTextChanged="txtcarnetGrafico4_OnTextChanged" CssClass="form-control" runat="server"></asp:TextBox>
                                    </div>
                                <div class="col-sm-4"></div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12 text-center">
                                        <asp:Chart ID="Grafico4" runat="server" Width="800" >
                                            <Series>
                                                <asp:Series Name="Series1"></asp:Series>
                                            </Series>
                                            <ChartAreas>
                                                <asp:ChartArea  Name="ChartArea1"></asp:ChartArea>
                                            </ChartAreas>
                                        </asp:Chart>
                                    </div>
                                </div>
                            </asp:View>
                        </asp:MultiView>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
