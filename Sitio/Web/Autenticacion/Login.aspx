<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/ExternoMaster.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Web_Autenticacion_Login" %>

<%@ Register Src="~/Wuc/Bloques/bloqueValidacion.ascx" TagName="bloqueValidacion" TagPrefix="Pulse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/forms.css" rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
    <Pulse:bloqueValidacion ID="bloqueValidacioens" runat="server" />

    <script src="../../scripts/pulse/login.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <h1>
        Livia
    </h1>
    <div id="formulario" style="width: 300px; float: left; background-color: #F0F0E8">
        <h4>
        Ingresar
        </h4>
        <br class="clear" />
        <fieldset>
            <asp:Label ID="lblNombreIngreso" runat="server" AssociatedControlID="tbNombreIngreso">Nombre de ingreso</asp:Label>
            <asp:TextBox ID="tbNombreIngreso" runat="server" CssClass="required" MaxLength="15" minlength="1"></asp:TextBox>
        </fieldset>
        <br class="clear" />
        <fieldset>
            <asp:Label ID="lblContrasenia" runat="server" AssociatedControlID="tbNombreIngreso">Contraseña</asp:Label>
            <asp:TextBox ID="tbContrasenia" runat="server" TextMode="Password" CssClass="required" MaxLength="15" minlength="1"></asp:TextBox>
        </fieldset>
        <br class="clear" />
        <fieldset>
            <asp:Button ID="btnIngresar" runat="server" Text="Ingresar" CssClass="submit" OnClick="btnIngresar_Click" />
        </fieldset>
    </div>
    <div style="float: left; width: 580px; padding: 10px">
        <h2>
            ¿Qué es Livia?
        </h2>
        <p style="text-align:justify">
            Livia es una herramienta pensada en ser la principal forma de retroalimentación de la compañía con sus clientes, su principal función es la de permitir el envío de información digital a clientes de la compañía a través de correo electrónico, esto la convierte en una excelente herramienta para el desarrollo de campañas de marketing, envío de documentos importantes, encuestas, ofertas, promociones y cualquier información que se desee enviar a los clientes de la compañía. Livia se configurará de acuerdo a sus necesidades para generar campañas de envío de correo electrónico a sus clientes de la manera
            que su compañía lo requiera, podrá agendar tareas automáticas de envío de publicidad una vez a la semana, o podrá generar una campaña relámpago que enviará una información importante y crítica a sus clientes.
        </p>
        <img src="../../App_Themes/PulseTheme/images/logos/pigeon.jpg" />
    </div>
    <br class="clear" />
</asp:Content>
