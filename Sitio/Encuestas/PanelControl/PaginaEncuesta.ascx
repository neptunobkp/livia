<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PaginaEncuesta.ascx.cs" Inherits="Encuestas_PanelControl_PaginaEncuesta" %>
<%@ Register Src="~/Encuestas/PanelControl/OpcionUnica.ascx" TagPrefix="PulsePregunta" TagName="OpcionUnica" %>
<%@ Register Src="~/Encuestas/PanelControl/OpcionMultiple.ascx" TagPrefix="PulsePregunta" TagName="OpcionMultiple" %>
<%@ Register Src="~/Encuestas/PanelControl/PreguntaSimple.ascx" TagPrefix="PulsePregunta" TagName="TextoSimple" %>
<%@ Register Src="~/Encuestas/PanelControl/PreguntaParrafo.ascx" TagPrefix="PulsePregunta" TagName="TextoEnsayo" %>
<%@ Register Src="~/Encuestas/PanelControl/PreguntaMatriz.ascx" TagPrefix="PulsePregunta" TagName="Matriz" %>
<div class="ui-accordion ui-widget ui-helper-reset ui-accordion-icons">
    <table>
        <tbody>
            <tr>
                <td>
                    <telerik:RadTextBox ID="tbTituloPagina" runat="server" EmptyMessage="Título de la página" Width="500px" Font-Bold="true">
                    </telerik:RadTextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <telerik:RadTextBox ID="tbIntroduccionPagina" runat="server" EmptyMessage="Mensaje inicial de la página" Width="500px" TextMode="MultiLine" Height="250px" Font-Bold="true">
                    </telerik:RadTextBox>
                </td>
            </tr>
        </tbody>
    </table>
    <br />
    <h3>
        Preguntas</h3>
    <br />
    <asp:Repeater ID="repeaterPreguntas" runat="server" OnItemCommand="repeaterPreguntas_ItemCommand">
        <ItemTemplate>
            <h3 class="ui-accordion-header ui-helper-reset ui-state-default ui-state-active ui-corner-top">
                <a href="#">Pregunta
                    <%# (int)DataBinder.Eval(Container,"ItemIndex") + 1 %>
                </a>
            </h3>
            <div class="ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-active hasformencuestatable">
                <asp:HiddenField ID="hiddenTipoPregunta" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta")%>' />
                <asp:HiddenField ID="hiddenCodigoPreugnta" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>' />
                <asp:ImageButton ID="linkBotonSubir" ImageUrl="~/App_Themes/PulseTheme/images/icons/up.png" runat="server" CssClass="miniboton" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>'
                    CommandName="Subir"></asp:ImageButton>
                <asp:ImageButton ID="linkBotonBajar" ImageUrl="~/App_Themes/PulseTheme/images/icons/down.png" runat="server" CssClass="miniboton" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>'
                    CommandName="Bajar"></asp:ImageButton>
                <asp:ImageButton ID="linkBotonEliminar" ImageUrl="~/App_Themes/PulseTheme/images/icons/close.png" runat="server" CssClass="miniboton" CommandArgument='<%# DataBinder.Eval(Container.DataItem, "Codigo")%>'
                    CommandName="Eliminar"></asp:ImageButton>
                <br class="clear" />
                <asp:Panel ID="panelOtraPreguntaMultiple" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionMultiple"%>'>
                    <PulsePregunta:OpcionMultiple ID="preguntaSeleccionMultiple" runat="server" PreguntaInterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionMultiple" ? Container.DataItem : null%>' />
                </asp:Panel>
                <asp:Panel ID="panelOtraPreguntaUnica" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionUnica"%>'>
                    <PulsePregunta:OpcionUnica ID="preguntaOpcionUnica" runat="server" PreguntaInterna='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionUnica" ? Container.DataItem : null %>' />
                </asp:Panel>
                <asp:Panel ID="panelOtraPreguntaTextoSimple" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoSimple"%>'>
                    <PulsePregunta:TextoSimple ID="preguntaTextoSimple" runat="server" PreguntaInterna='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoSimple" ? Container.DataItem : null %>' />
                </asp:Panel>
                <asp:Panel ID="panelOtraPreguntaTextoEnsayo" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoEnsayo"%>'>
                    <PulsePregunta:TextoEnsayo ID="preguntaTextoEnsayo" runat="server" PreguntaInterna='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoEnsayo" ? Container.DataItem : null %>' />
                </asp:Panel>
                <asp:Panel ID="panelOtraPreguntaMatriz" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "Matriz"%>'>
                    <PulsePregunta:Matriz ID="preguntaMatriz" runat="server" PreguntaInterna='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "Matriz" ? Container.DataItem : null %>' />
                </asp:Panel>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
<br />
<table>
    <tbody>
        <tr>
            <td>
                <asp:LinkButton ID="linkbtnAgregarPreguntaOpcionMultiple" runat="server" OnClick="btnAgregarPreguntaOpcionMultiple_Click" ForeColor="White" CssClass="linkbotonencuesta">
                    <img src="../../App_Themes/PulseTheme/images/icons/plus.gif" alt="+"  />
                    <span>Opción Múltiple</span>
                </asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="linkAgregarPreguntaOpcionUnica" runat="server" OnClick="btnAgregarPreguntaOpcionUnica_Click" ForeColor="White" CssClass="linkbotonencuesta">
                    <img src="../../App_Themes/PulseTheme/images/icons/plus.gif" alt="+"  />
                    <span>Opción Única</span>
                </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="linkAgregarPreguntaSimple" runat="server" OnClick="linkAgregarPreguntaSimple_Click" ForeColor="White" CssClass="linkbotonencuesta">
                    <img src="../../App_Themes/PulseTheme/images/icons/plus.gif" alt="+"  />
                    <span>Texto Simple</span>
                </asp:LinkButton>
            </td>
            <td>
                <asp:LinkButton ID="linkAgregarPreguntaEnsayo" runat="server" OnClick="linkAgregarPreguntaEnsayo_Click" ForeColor="White" CssClass="linkbotonencuesta">
                    <img src="../../App_Themes/PulseTheme/images/icons/plus.gif" alt="+"  />
                    <span>Texto Ensayo</span>
                </asp:LinkButton>
            </td>
        </tr>
        <tr>
            <td>
                <asp:LinkButton ID="linkAgregarPreguntaMatriz" runat="server" OnClick="linkAgregarPreguntaMatriz_Click" ForeColor="White" CssClass="linkbotonencuesta">
                    <img src="../../App_Themes/PulseTheme/images/icons/plus.gif" alt="+"  />
                    <span>Matriz</span>
                </asp:LinkButton>
            </td>
            <td>
            </td>
        </tr>
    </tbody>
</table>
