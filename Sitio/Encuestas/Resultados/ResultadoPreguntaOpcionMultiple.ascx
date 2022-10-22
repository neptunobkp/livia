<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResultadoPreguntaOpcionMultiple.ascx.cs"
    Inherits="Encuestas_Resultados_ResultadoPreguntaOpcionMultiple" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<asp:HiddenField ID="hiddenCantidadRespuesta" runat="server" />
<table border="1px">
    <tbody>
        <tr>
            <td>
                <asp:Label ID="tbPregunta" Enabled="false" runat="server" Font-Bold="true">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="tbAnotacionPregunta" runat="server">
                </asp:Label>
            </td>
        </tr>
        <tr>
            <td class="center">
                <asp:CheckBoxList ID="checkboxListOpciones" runat="server" Visible="false">
                </asp:CheckBoxList>
            </td>
        </tr>
        <tr>
            <td>
                <telerik:RadChart ID="radChartItems" runat="server" AutoLayout="true" Width="800px"
                    Skin="Telerik">
                    <ChartTitle>
                        <TextBlock Text="Datos" />
                    </ChartTitle>
                    <PlotArea>
                        <XAxis DataLabelsColumn="Glosa">
                        </XAxis>
                    </PlotArea>
                </telerik:RadChart>
            </td>
        </tr>
        <tr>
            <td>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="tbAnotacionFinalPregunta" runat="server">
                </asp:Label>
            </td>
        </tr>
    </tbody>
</table>
