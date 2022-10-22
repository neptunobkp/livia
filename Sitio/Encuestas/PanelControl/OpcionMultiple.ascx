<%@ Control Language="C#" AutoEventWireup="true" CodeFile="OpcionMultiple.ascx.cs" Inherits="Encuestas_PanelControl_OpcionMultiple" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<table>
    <tbody>
        <tr>
            <td>
                <telerik:RadTextBox ID="tbPregunta" runat="server" EmptyMessage="Descripción de la pregunta" Width="500px" TextMode="MultiLine" Height="200px" Font-Bold="true">
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
                        <input type="checkbox" disabled="disabled" style="display: inline" />
                        <asp:TextBox ID="tbItemOpcionesText" runat="server" TextMode="MultiLine" Width="300px" Text='<%# DataBinder.Eval(Container, "Text")%>'></asp:TextBox>
                    </ItemTemplate>
                </telerik:RadListBox>
                <asp:ImageButton ID="btnAgregar" runat="server" ImageUrl="~/App_Themes/PulseTheme/images/icons/agregar.png" OnClick="btnAgregar_Click" ToolTip="Agregar un nuevo item" />
            </td>
        </tr>
        <tr>
            <td class="center">
                <asp:CheckBoxList ID="checkListConfiguracion" runat="server" RepeatDirection="Horizontal" BackColor="#DDDDDD" CellSpacing="5">
                    <asp:ListItem Text="Obligario" Value="Obligario"></asp:ListItem>
                    <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                    <asp:ListItem Text="Aleatorio" Value="Aleatorio"></asp:ListItem>
                </asp:CheckBoxList>
                <br />
                <telerik:RadNumericTextBox Label="Número de columnas" Width="300px" ID="tbNumeroColumnas" Type="Number" ShowSpinButtons="true" MinValue="1" MaxValue="3" runat="server" NumberFormat-DecimalDigits="0"
                    Value="1">
                </telerik:RadNumericTextBox>
                <br />
                <telerik:RadNumericTextBox Label="Límite de opciones" Width="300px" ID="tbNumeroMaximoItemsSeleccionado" Type="Number" ShowSpinButtons="true" MinValue="0" MaxValue="1000" runat="server"
                    NumberFormat-DecimalDigits="0" Value="1">
                    <NumberFormat DecimalDigits="0"></NumberFormat>
                </telerik:RadNumericTextBox>
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
