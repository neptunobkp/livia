<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Mantenedores_Plantillas_Crear" %>

<%@ Register Src="~/Wuc/Bloques/bloqueValidacion.ascx" TagName="bloqueValidacion" TagPrefix="Pulse" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
    <Pulse:bloqueValidacion ID="bloqueValidacioens" runat="server" />

    <script src="../../scripts/pulse/mantenedor_crear_conexion.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <div id="formulario" style="background-image: url('../../App_Themes/PulseTheme/images/inicio/paleta.png'); background-repeat: no-repeat; background-position: top right">
        <h3>
            Configuración de una plantilla
        </h3>
        <fieldset class="clear">
            <asp:Label ID="lblNombrePlantilla" runat="server" AssociatedControlID="tbNombrePlantilla">Nombre de referencia de la plantilla</asp:Label>
            <asp:TextBox ID="tbNombrePlantilla" runat="server" CssClass="required" MaxLength="100"></asp:TextBox>
        </fieldset>
        <br class="clear" />
        <div class="intro">
            <p>
                <strong>Banner (máximo - 950px por 200px)</strong>
                <asp:FileUpload ID="uploadImagenBanner" runat="server" Width="500px" CssClass="required"></asp:FileUpload>
                <br />
            </p>
        </div>
        <h3>
            &nbsp;</h3>
        <h1>
            <telerik:RadTextBox ID="tbTituloPlantilla" runat="server" Width="700px" Font-Bold="true" Font-Size="X-Large" runat="server" EmptyMessage="Título de la encuesta">
            </telerik:RadTextBox>
        </h1>
        <br />
        <asp:Label ID="lblCuerpoHtml" runat="server" Font-Bold="true" Font-Size="Large">Descripción de la encuesta</asp:Label>
        <CKEditor:CKEditorControl ID="CKEditorControl1" runat="server" Height="200" CssClass="required">
        </CKEditor:CKEditorControl>
        <br />
        <div style="padding: 100px 5px; background-color: #FAFAFA">
            <asp:Label ID="lblPreguntas" runat="server" ForeColor="#DE5A03" Font-Bold="true" Font-Size="XX-Large" Text="Aqui se ubicaran las preguntas"></asp:Label>
        </div>
        <h3>
            &nbsp;</h3>
        <fieldset class="clear">
            <telerik:RadTextBox ID="CKEditorControl2" Width="600px" Font-Bold="true" Font-Size="X-Large" runat="server" CssClass="required" EmptyMessage="Mensaje al pie de la página">
            </telerik:RadTextBox>
        </fieldset>
        <fieldset class="clear">
            <asp:Label ID="lblArchivoCss" runat="server" AssociatedControlID="uploadArchivoCss">Archivo css de estilos.</asp:Label>
            <asp:FileUpload ID="uploadArchivoCss" runat="server" />
        </fieldset>
        <fieldset class="clear">
            <br />
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar Plantilla" CssClass="submit" OnClick="btnGuardar_Click" />
        </fieldset>
        <br class="clear" />
    </div>
</asp:Content>
