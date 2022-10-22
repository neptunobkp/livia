<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Mantenedores_Grupos_Crear" %>

<%@ Register Src="~/Wuc/Bloques/bloqueValidacion.ascx" TagName="bloqueValidacion"
    TagPrefix="Pulse" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
    <Pulse:bloqueValidacion ID="bloqueValidacioens" runat="server" />

    <script src="../../scripts/pulse/mantenedor_crear_conexion.js" type="text/javascript"></script>

    <script src="../../scripts/pulse/campania_listacorreo_crear.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <div id="formulario" style="background-image: url('../../App_Themes/PulseTheme/images/inicio/envios2.png');
        background-repeat: no-repeat; background-position: top right">
        <h3>
            Configuracion de un grupo
        </h3>
        <div id="formulario">
            <fieldset class="superlargo clear">
                <p>
                    <asp:Label runat="server" ID="lblNombreGrupo" Text="Nombre Grupo" AssociatedControlID="tbNombreGrupo"></asp:Label>
                    <asp:TextBox runat="server" ID="tbNombreGrupo"></asp:TextBox>
                </p>
                <p>
                    <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar Grupo" />
                </p>
            </fieldset>
        </div>
        <br class="clear" />
        <br class="clear" />
        <br class="clear" />
        <br class="clear" />
        <br class="clear" />
    </div>
</asp:Content>
