<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpcionUnica.ascx.cs" Inherits="Web_Encuesta_OpcionUnica" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<h3>
    <asp:Literal ID="tbPregunta" runat="server"></asp:Literal>
</h3>
<span class="anotacion">
    <asp:Literal ID="tbAnotacionPregunta" runat="server"></asp:Literal>
</span>
<div>
    <asp:RequiredFieldValidator ID="reuiqreOpcion" runat="server" ControlToValidate="checkboxListOpciones"
        Display="Dynamic" ValidationGroup="vgEncuenstas">Debe seleccionar alguna alternativa.
    </asp:RequiredFieldValidator>
    <asp:RadioButtonList ID="checkboxListOpciones" runat="server" BackColor="#F7F7F7"
        CellSpacing="15" Width="100%">
    </asp:RadioButtonList>
    <br />
    <telerik:RadTextBox ID="radTextboxOtraOpcion" runat="server" Visible="false" EmptyMessage="Otra alternativa">
    </telerik:RadTextBox>
</div>
<div class="divisor">
    <span class="anotacion">
        <asp:Label ID="tbAnotacionFinalPregunta" runat="server">
        </asp:Label>
    </span>
</div>
