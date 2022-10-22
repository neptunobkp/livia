<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RespuestaSimple.ascx.cs"
    Inherits="Web_Encuesta_RespuestaSimple" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<h3>
    <asp:Literal ID="tbPregunta" runat="server"></asp:Literal>
</h3>
<span class="anotacion">
    <asp:Literal ID="tbAnotacionPregunta" runat="server"></asp:Literal>
</span>
<div>
    <asp:TextBox ID="tbTextoSimple" runat="server" Width="100%"></asp:TextBox>
</div>
<div class="divisor">
    <span class="anotacion">
        <asp:Label ID="tbAnotacionFinalPregunta" runat="server">
        </asp:Label>
    </span>
</div>
