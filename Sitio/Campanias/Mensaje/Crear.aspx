<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Campanias_Mensaje_Crear" %>

<%@ Register Src="~/Wuc/Bloques/bloqueValidacion.ascx" TagName="bloqueValidacion" TagPrefix="Pulse" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/forms.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
    <Pulse:bloqueValidacion ID="bloqueValidacioens" runat="server" />

    <script src="../../scripts/pulse/campania_crear_mensaje.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Crear una nueva plantilla de mensaje, la cual sera enviado por correo
    </h1>
    <div class="intro">
    <p>
        Esta plantilla, puede contener parámetros, los cuales seran encadenados durante el envio de correo, los parámetros deben ser ingresados con el siguiente formato <strong>#identificador_parámetro#</strong>
        </p>
        <p>
            En el caso de que el mensaje envie una encuesta contenida, debera agregar el siguiente parámetro <strong>#link#</strong>, que durante el proceso de envio será remplazado por el link de la encuesta
        </p>
    </div>
    <div id="formulario">
        <fieldset class="superlargo clear">
            <asp:Label ID="lblNombreMensaje" runat="server" AssociatedControlID="tbNombreMensaje">Alias de mensaje</asp:Label>
            <asp:TextBox ID="tbNombreMensaje" runat="server" CssClass="superlargo required"></asp:TextBox>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="tbTituloEmail">Título del email</asp:Label>
            <asp:TextBox ID="tbTituloEmail" runat="server" CssClass="superlargo required"></asp:TextBox>
        </fieldset>
        <br class="clear" />
        <CKEditor:CKEditorControl ID="CKEditor1" runat="server" Height="200">
        </CKEditor:CKEditorControl>
        <br class="clear" />
        <strong>Archivos adjuntos</strong><br />
        <asp:FileUpload ID="fileUpload1" runat="server" Width="500px" /><br />
        <br />
        <asp:FileUpload ID="fileUpload2" runat="server" Width="500px" /><br />
        <br />
        <asp:FileUpload ID="fileUpload3" runat="server" Width="500px" /><br />
        <br />
        <asp:FileUpload ID="fileUpload4" runat="server" Width="500px" /><br />
        <br />
        <asp:FileUpload ID="fileUpload5" runat="server" Width="500px" /><br />
        <br />
        <asp:FileUpload ID="fileUpload6" runat="server" Width="500px" /><br />
        <br />
        <fieldset class="superlargo clear">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </fieldset>
        <br class="clear" />
    </div>
</asp:Content>
