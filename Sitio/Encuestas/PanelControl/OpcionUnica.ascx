<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpcionUnica.ascx.cs" Inherits="Encuestas_PanelControl_OpcionUnica" %>
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
                <telerik:RadListBox ID="listboxOpciones" runat="server" AllowReorder="true" AllowDelete="true" Width="400px" BorderColor="#D0D0D0" AppendDataBoundItems="true">
                    <ItemTemplate>
                        <input type="radio" disabled="disabled" style="display: inline" />
                        <asp:TextBox ID="tbItemOpcionesText" runat="server" TextMode="MultiLine" Width="300px" Text='<%# DataBinder.Eval(Container, "Text")%>'></asp:TextBox>
                    </ItemTemplate>
                </telerik:RadListBox>
                <br />
                <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/App_Themes/PulseTheme/images/icons/agregar.png" OnClick="btnAgregar_Click" ToolTip="Agregar un nuevo item" />
            </td>
        </tr>
        <tr>
            <td class="center">
                <asp:CheckBoxList ID="checkListConfiguracion" runat="server" RepeatDirection="Horizontal" BackColor="#DDDDDD" CellSpacing="5">
                    <asp:ListItem Text="Obligario" Value="Obligario"></asp:ListItem>
                    <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                    <asp:ListItem Text="Combobox" Value="Combobox"></asp:ListItem>
                    <asp:ListItem Text="Aleatorio" Value="Aleatorio"></asp:ListItem>
                    <asp:ListItem Text="Horizontal" Value="Horizontal"></asp:ListItem>
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
