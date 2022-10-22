<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Mantenedores_Conexiones_Crear" %>

<%@ Register Src="~/Wuc/Bloques/bloqueValidacion.ascx" TagName="bloqueValidacion" TagPrefix="Pulse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
    <Pulse:bloqueValidacion ID="bloqueValidacioens" runat="server" />

    <script src="../../scripts/pulse/mantenedor_crear_conexion.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <h1>
        Agregar nueva conexión
    </h1>
    <div id="formulario">
        <div>
            <asp:RadioButtonList ID="radioListBaseDatos" runat="server" RepeatDirection="Horizontal" CssClass="required radioClass">
                <asp:ListItem Text="Sql Server" Value="1"></asp:ListItem>
                <asp:ListItem Text="Oracle" Value="2"></asp:ListItem>
                <asp:ListItem Text="IBM Db2" Value="3"></asp:ListItem>
                <asp:ListItem Text="Microsoft Access" Value="4" Enabled="false"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <fieldset class="largo clear">
            <asp:Label ID="lblAlias" runat="server" AssociatedControlID="tbAlias">Alias</asp:Label>
            <asp:TextBox ID="tbAlias" runat="server" CssClass="required"></asp:TextBox>
        </fieldset>
        <fieldset class="largo clear">
            <asp:Label ID="lblNombreServidor" runat="server" AssociatedControlID="tbServidor">Servidor</asp:Label>
            <asp:TextBox ID="tbServidor" runat="server" CssClass="required"></asp:TextBox>
        </fieldset>
        <fieldset class="largo clear">
            <asp:Label ID="lblUsuarioServidor" runat="server" AssociatedControlID="tbUsuario">Usuario</asp:Label>
            <asp:TextBox ID="tbUsuario" runat="server" CssClass="required"></asp:TextBox>
        </fieldset>
        <fieldset class="largo clear">
            <asp:Label ID="lblContrasenia" runat="server" AssociatedControlID="tbContrasenia">Clave</asp:Label>
            <asp:TextBox ID="tbContrasenia" runat="server" CssClass="required" TextMode="Password"></asp:TextBox>
        </fieldset>
        <fieldset class="largo clear">
            <asp:Label ID="lblNombreBaseDatos" runat="server" AssociatedControlID="tbNombreBaseDatos">Base de datos/SID</asp:Label>
            <asp:TextBox ID="tbNombreBaseDatos" runat="server"></asp:TextBox>
        </fieldset>
        <fieldset class="largo clear">
            <asp:Label ID="lblPuerto" runat="server" AssociatedControlID="tbPuerto">Puerto</asp:Label>
            <asp:TextBox ID="tbPuerto" runat="server"></asp:TextBox>
        </fieldset>
        <fieldset class="largo clear">
            <asp:Button ID="btnTestearConexion" runat="server" Text="Probar Conexión" OnClick="btnTestearConexion_Click" />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" Visible="false" OnClick="btnGuardar_Click" />
        </fieldset>
    </div>
</asp:Content>
