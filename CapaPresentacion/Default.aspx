<%@ Page
    Language="C#"
    MasterPageFile="~/Principal.Master"
    AutoEventWireup="true"
    CodeBehind="Default.aspx.cs"
    Inherits="CapaPresentacion.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Scripts/jquery-3.3.1.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>
    <link rel="stylesheet" href="Content/bootstrap.min.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jumbotron">
        <div class="container">
            <h1 class="display-4">Cube Summation Jesús Garcia</h1>
            <p class="lead">Prueba para cargo de oferta laboral en la empresa XpertGroup.</p>
            <hr class="my-4">

            <div class="row">
                <div class="col-4">
                    <asp:TextBox runat="server" ID="txb_Entrada" TextMode="MultiLine" Height="400px" Width="100%"></asp:TextBox>
                </div>
                <div class="col-4">
                    <asp:TextBox runat="server" ID="txb_Salida" TextMode="MultiLine" Height="400px" Width="100%" Enabled="false"></asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-4 offset-md-2">
                    <asp:Button runat="server" CssClass="btn btn-primary" Text="Realizar Calculo" ID="btnCalcular" OnClick="RealizarCalculo" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>