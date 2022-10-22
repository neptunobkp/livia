<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResultadoPreguntaParrafo.ascx.cs"
    Inherits="Encuestas_Resultados_ResultadoPreguntaParrafo" %>
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
                <li>
                    <asp:Repeater ID="repeaterTextos" runat="server">
                        <ItemTemplate>
                            <ul>
                                <asp:TextBox ID="tbResupuesta" Text='<%# DataBinder.Eval(Container.DataItem, "GlosaRespuesta")%>'
                                    runat="server"></asp:TextBox>
                            </ul>
                        </ItemTemplate>
                    </asp:Repeater>
                </li>
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
