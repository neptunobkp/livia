<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResultadoPreguntaOpcionMultiple.ascx.cs"
    Inherits="Encuestas_Resultado_ResultadoPreguntaOpcionMultiple" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<h3>
    <asp:Literal ID="tbPregunta" runat="server"></asp:Literal>
</h3>
<span class="anotacion">
    <asp:Literal ID="tbAnotacionPregunta" runat="server"></asp:Literal>
</span>
<br />
<div class="opcionesmultiple">
    <asp:CheckBoxList ID="checkboxListOpciones" runat="server" Width="100%" RepeatLayout="Flow"
        Enabled="false">
    </asp:CheckBoxList>
    <telerik:RadTextBox ID="radTextboxOtraOpcion" runat="server" Visible="false" EmptyMessage="Otra alternativa"
        Enabled="false" Width="200px">
    </telerik:RadTextBox>
</div>
<div class="divisor">
    <span class="anotacion">
        <asp:Label ID="tbAnotacionFinalPregunta" runat="server">
        </asp:Label>
    </span>
</div>
