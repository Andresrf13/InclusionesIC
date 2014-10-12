<%@ Page Title="" Language="C#" MasterPageFile="~/Estudiantes.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Inclusiones_IC_Web.ModuloComite.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.1/jquery.min.js"></script>
    <script src="../Scripts/bootstrap.js"></script>
    <div class="container-fluid">

        <div style="margin-right: auto; margin-left: auto;">
            <div class="row">
                <div class="col-md-4"></div>
                <div class="col-md-4" style="text-align: center;">
                    <h2 class="form-signin-heading">Por favor Inicie sesión</h2>
                    <input id="username" runat="server" class="form-control" placeholder="Nombre de Usuario" required="" autofocus="" />
                    <input id="password" runat="server" type="password" class="form-control" placeholder="Password" required="" />
                    <asp:Button ID="btnIniciar" runat="server" CssClass="btn btn-lg btn-primary btn-block" Text="Iniciar Sesión" OnClick="btnIniciar_Click" />
                    <asp:Label ID="lblError" runat="server" CssClass="alert-danger" Text=""></asp:Label>
                </div>
                <div class="col-md-4"></div>
            </div>
        </div>
    </div>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel" aria-hidden="true">
                <div class="modal-dialog">
                    <div class="modal-content">
                        <div class="modal-header">
                            <button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button>
                            <h4 class="modal-title" id="myModalLabel">
                                <asp:Label ID="txtTitulo" runat="server" Text=""></asp:Label></h4>
                        </div>
                        <div class="modal-body">
                            <asp:Label ID="txtCuerpo" runat="server" Text=""></asp:Label>
                        </div>
                        <div class="modal-footer">
                            <button type="button" class="btn btn-primary" data-dismiss="modal">Aceptar</button>
                        </div>
                    </div>
                </div>
            </div>

            <script type="text/javascript">
                function openModal() {
                    $('#myModal').modal('show');
                }
                function closeModal() {
                    $('#myModal').modal('hide');
                }
            </script>
        </ContentTemplate>       
    </asp:UpdatePanel>



</asp:Content>
