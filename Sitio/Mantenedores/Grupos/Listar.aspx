<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="Mantenedores_Grupos_Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Configuracion de grupos
    </h1>
    <div class="intro">
    </div>
    <div id="formulario">
        <fieldset class="clear">
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Mantenedores/Grupos/Crear.aspx" Text="Agregar un nuevo grupo"
                runat="server"></asp:HyperLink>
        </fieldset>
        <br />
        <br />
    </div>
</asp:Content>
