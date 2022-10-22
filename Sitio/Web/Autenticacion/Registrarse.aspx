<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/ExternoMaster.master" AutoEventWireup="true" CodeFile="Registrarse.aspx.cs" Inherits="Web_Autenticacion_Registrarse" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <h1>
        Registrarse
    </h1>
    <div id="formulario">
        <fieldset>
            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="tbNombre">Nombre Completo</asp:Label>
            <asp:TextBox ID="tbNombre" runat="server"></asp:TextBox>
        </fieldset>
        <fieldset>
            <asp:Label ID="lblRut" runat="server" AssociatedControlID="tbRut">Rut</asp:Label>
            <asp:TextBox ID="tbRut" runat="server"></asp:TextBox>
        </fieldset>
        <fieldset>
            <asp:Label ID="lblNombreIdentificacion" runat="server" AssociatedControlID="tbNombreIdentificacion">Nombre Completo</asp:Label>
            <asp:TextBox ID="tbNombreIdentificacion" runat="server"></asp:TextBox>
        </fieldset>
        <fieldset>
            <asp:Label ID="lblCompania" runat="server" AssociatedControlID="ddlCompnia">Compañía</asp:Label>
            <asp:TextBox ID="ddlCompnia" runat="server"></asp:TextBox>
        </fieldset>
        <fieldset>
            <asp:Button ID="btnRegistrarse" runat="server" Text="Registrarse" />
        </fieldset>
    </div>
</asp:Content>
