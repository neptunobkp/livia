<%@ Control Language="C#" AutoEventWireup="true" CodeFile="RespuestaMatriz.ascx.cs"
    Inherits="Web_Encuesta_RespuestaMatriz" %>
<asp:HiddenField ID="hiddenCodigoPregunta" runat="server" />
<h3>
    <asp:Literal ID="tbPregunta" runat="server"></asp:Literal>
</h3>
<span class="anotacion">
    <asp:Literal ID="tbAnotacionPregunta" runat="server"></asp:Literal>
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
                                    <asp:HiddenField ID="hiddenSubItemColumnaPreguntaId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <asp:HiddenField ID="hiddenGlosaPregunta" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "GlosaPregunta")%>' />
                                    <input type="radio" value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' name='<%# DataBinder.Eval(Container.DataItem, "NombreGrupo")%>' />
                                    <%--<asp:RadioButton ID="radioAlternativa" runat="server" Text="" GroupName='<%# DataBinder.Eval(Container.DataItem, "NombreGrupo")%>'
                                        CssClass='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />--%>
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
