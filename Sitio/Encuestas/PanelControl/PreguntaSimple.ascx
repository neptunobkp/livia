<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PreguntaSimple.ascx.cs" Inherits="Encuestas_PanelControl_PreguntaSimple" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<table>
    <tbody>
        <tr>
            <td>
                <telerik:RadTextBox ID="tbPregunta" runat="server" EmptyMessage="¿Dejar esta pregunta asi?" Width="500px" TextMode="MultiLine" Height="200px" Font-Bold="true">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTextBox ID="tbAnotacionPregunta" runat="server" EmptyMessage="Nota adicional de pregunta" Width="500px">
                </telerik:RadTextBox>
            </td>
        </tr>
        <tr>
            <td class="center">
                <asp:TextBox ID="tbTextoParaUsuario" runat="server" Text="El usuario escribira aqui" Width="400px" Enabled="false"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="center">
                <asp:CheckBoxList ID="checkListConfiguracion" runat="server" RepeatDirection="Horizontal" BackColor="#DDDDDD" CellSpacing="5">
                    <asp:ListItem Text="Obligario" Value="Obligario"></asp:ListItem>
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadTextBox ID="tbAnotacionFinalPregunta" runat="server" EmptyMessage="Nota Final de pregunta" Width="500px">
                </telerik:RadTextBox>
            </td>
        </tr>
    </tbody>
</table>
