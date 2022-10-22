<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ResultadoPreguntaOpcionMatriz.ascx.cs"
    Inherits="Encuestas_Resultados_ResultadoPreguntaOpcionMatriz" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<asp:HiddenField ID="hiddenCantidadRespuesta" runat="server" />
<h3>
    <asp:Literal ID="tbPregunta" runat="server">
    </asp:Literal>
</h3>
<span class="anotacion">
    <asp:Literal ID="tbAnotacionPregunta" runat="server">
    </asp:Literal>
</span>
<div class="hastable">
    <table style="width: 100%">
        <thead>
            <tr>
                <th>
                </th>
                <asp:Repeater ID="repeaterCabezera" runat="server">
                    <ItemTemplate>
                        <th>
                            <%# DataBinder.Eval(Container.DataItem, "GlosaPregunta")%>
                        </th>
                    </ItemTemplate>
                </asp:Repeater>
            </tr>
        </thead>
        <tbody>
            <asp:Repeater ID="repeaterPreguntas" runat="server">
                <ItemTemplate>
                    <tr>
                        <td>
                            <asp:Label ID="lblNombreSubPregunta" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "NombrePregunta")%>'></asp:Label>
                            <asp:HiddenField ID="hiddenItemPreguntaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "IdentificadorFila")%>' />
                        </td>
                        <asp:Repeater ID="repeaterItemsAlternativas" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "ItemsPreguntas")%>'>
                            <ItemTemplate>
                                <td class="centro">
                                    <asp:Label ID="lblPorcentaje" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "ValorInterno")%>'></asp:Label>
                                </td>
                            </ItemTemplate>
                        </asp:Repeater>
                    </tr>
                </ItemTemplate>
            </asp:Repeater>
        </tbody>
    </table>
</div>
<div class="divisor">
    <span class="anotacion">
        <asp:Label ID="tbAnotacionFinalPregunta" runat="server">
        </asp:Label>
    </span>
</div>
