<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/ExternoMaster.master"
    AutoEventWireup="true" CodeFile="Mensaje.aspx.cs" Inherits="Web_Encuesta_Mensaje" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <h1>
        Gracias por responder a nuestra encuesta!
    </h1>
    <asp:Button ID="btnCerrar" Text="Cerrar esta página" runat="server" OnClientClick="window.close();" />
</asp:Content>
