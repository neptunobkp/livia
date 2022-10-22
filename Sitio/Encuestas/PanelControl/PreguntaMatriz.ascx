<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PreguntaMatriz.ascx.cs" Inherits="Encuestas_PanelControl_PreguntaMatriz" %>
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
                <div style="width: 248px; float: left">
                    <span>Columnas</span>
                    <br />
                    <telerik:RadListBox ID="listboxOpcionesA" runat="server" AllowReorder="true" AllowDelete="true" Width="220px" BorderColor="#D0D0D0" AppendDataBoundItems="true">
                        <ItemTemplate>
                            <input type="checkbox" disabled="disabled" style="display: inline" />
                            <asp:TextBox ID="tbItemOpcionesAText" runat="server" Width="100px" Text='<%# DataBinder.Eval(Container, "Text")%>'></asp:TextBox>
                        </ItemTemplate>
                    </telerik:RadListBox>
                    <asp:ImageButton ID="btnAgregarA" runat="server" ImageUrl="~/App_Themes/PulseTheme/images/icons/agregar.png" OnClick="btnAgregarA_Click" ToolTip="Agregar un nuevo item" />
                </div>
                <div style="width: 248px; float: left">
                    <span>Filas</span>
                    <br />
                    <telerik:RadListBox ID="listboxOpcionesB" runat="server" AllowReorder="true" AllowDelete="true" Width="220px" BorderColor="#D0D0D0" AppendDataBoundItems="true">
                        <ItemTemplate>
                            <input type="checkbox" disabled="disabled" style="display: inline" />
                            <asp:TextBox ID="tbItemOpcionesBText" runat="server" Width="100px" Text='<%# DataBinder.Eval(Container, "Text")%>'></asp:TextBox>
                        </ItemTemplate>
                    </telerik:RadListBox>
                    <asp:ImageButton ID="btnAgregarB" runat="server" ImageUrl="~/App_Themes/PulseTheme/images/icons/agregar.png" OnClick="btnAgregarB_Click" ToolTip="Agregar un nuevo item" />
                </div>
            </td>
        </tr>
        <tr>
            <td class="center">
                <asp:CheckBoxList ID="checkListConfiguracion" runat="server" RepeatDirection="Horizontal" BackColor="#DDDDDD" CellSpacing="5">
                    <asp:ListItem Text="Obligario" Value="Obligario"></asp:ListItem>
                    <asp:ListItem Text="Otro" Value="Otro"></asp:ListItem>
                    <asp:ListItem Text="Aleatorio" Value="Aleatorio"></asp:ListItem>
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
