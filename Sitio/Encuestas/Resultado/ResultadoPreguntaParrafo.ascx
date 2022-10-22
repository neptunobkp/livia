<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResultadoPreguntaParrafo.ascx.cs" Inherits="Encuestas_Resultado_ResultadoPreguntaParrafo" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<h3>
    <asp:Literal ID="tbPregunta" runat="server"></asp:Literal>
</h3>
<span class="anotacion">
    <asp:Literal ID="tbAnotacionPregunta" runat="server"></asp:Literal>
</span>
<div>
    <asp:TextBox ID="tbTextoSimple" runat="server" Width="500px" TextMode="MultiLine" Enabled="false"
        Height="200px"></asp:TextBox>
</div>
<div class="divisor">
    <span class="anotacion">
        <asp:Label ID="tbAnotacionFinalPregunta" runat="server">
        </asp:Label>
    </span>
</div>
