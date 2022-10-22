﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="VerRespuesta.aspx.cs" Inherits="Encuestas_Resultado_VerRespuesta" %>

<%@ Register Src="~/Encuestas/Resultado/ResultadoPreguntaOpcionMultiple.ascx" TagPrefix="Pulse"
    TagName="VerRespuestaOpcionMultiple" %>
<%@ Register Src="~/Encuestas/Resultado/ResultadoPreguntaOpcionUnica.ascx" TagPrefix="Pulse"
    TagName="VerRespuestaOpcionUnica" %>
<%@ Register Src="~/Encuestas/Resultado/ResultadoPreguntaSimple.ascx" TagPrefix="Pulse"
    TagName="VerRespuestaSimple" %>
<%@ Register Src="~/Encuestas/Resultado/ResultadoPreguntaParrafo.ascx" TagPrefix="Pulse"
    TagName="VerRespuestaParrafo" %>
<%@ Register Src="~/Encuestas/Resultado/ResultadoPreguntaMatriz.ascx" TagPrefix="Pulse"
    TagName="VerRespuestaMatriz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/styles/default/ui.css" rel="stylesheet"
        type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">

    <script src="../../scripts/jquery-1.6.4.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="formToWizard.js"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="radscriptManager1" runat="server">
    </telerik:RadScriptManager>
    <asp:Image ID="imageBanner" ImageUrl="~/App_Themes/PulseTheme/css/styles/" runat="server" />
    <div id="formencuesta">
        <div class="content">
            <h1>
                <asp:Literal ID="literalTituloEncuesta" runat="server"></asp:Literal>
            </h1>
            <div id="descripcion-encuesta">
                <asp:Literal ID="literalDescripcion" runat="server"></asp:Literal>
            </div>
            <br />
            <div id="divpaginas">
                <asp:Repeater ID="repeaterPaginas" runat="server">
                    <ItemTemplate>
                        <asp:HiddenField ID="hiddenNumeroPagina" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "NumeroPagina")%>' />
                        <fieldset>
                            <legend style="display: none">
                                <%# DataBinder.Eval(Container.DataItem, "Titulo")%>
                                &nbsp; </legend>
                            <p class="descripcion">
                                <%# DataBinder.Eval(Container.DataItem, "IntroduccionPagina")%></p>
                            <br />
                            <asp:Repeater ID="repeaterPreguntas" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "Preguntas")%>'>
                                <ItemTemplate>
                                    <asp:HiddenField ID="hiddenTipoPregunta" runat="server" Value='<%# ((int)DataBinder.Eval(Container.DataItem, "TipoPregunta")).ToString()%>' />
                                    <asp:HiddenField ID="hiddenIdPregunta" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                                    <br class="clear" />
                                    <asp:Panel ID="panelOtraPreguntaMultiple" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionMultiple"%>'>
                                        <Pulse:VerRespuestaOpcionMultiple ID="preguntaSeleccionMultiple" runat="server" preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionMultiple" ? Container.DataItem : null%>' />
                                    </asp:Panel>
                                    <asp:Panel ID="panelOtraPreguntaOpcionUnica" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionUnica"%>'>
                                        <Pulse:VerRespuestaOpcionUnica ID="preguntaSeleccionUnica" runat="server" preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionUnica" ? Container.DataItem : null%>' />
                                    </asp:Panel>
                                    <asp:Panel ID="panelOtraPreguntaTextoSimple" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoSimple"%>'>
                                        <Pulse:VerRespuestaSimple ID="preguntaSeleccionTextoSimple" runat="server" preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoSimple" ? Container.DataItem : null%>' />
                                    </asp:Panel>
                                    <asp:Panel ID="panelOtraPreguntaTextoEnsayo" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoEnsayo"%>'>
                                        <Pulse:VerRespuestaParrafo ID="preguntaSeleccionTextoEnsayo" runat="server" preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoEnsayo" ? Container.DataItem : null%>' />
                                    </asp:Panel>
                                    <asp:Panel ID="panelOtraPreguntaMatriz" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "Matriz"%>'>
                                        <Pulse:VerRespuestaMatriz ID="preguntaMatriz" runat="server" preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "Matriz" ? Container.DataItem : null%>' />
                                    </asp:Panel>
                                </ItemTemplate>
                            </asp:Repeater>
                            <div class="divisor">
                                <strong>
                                    <%# DataBinder.Eval(Container.DataItem, "MensajePiePagina")%></strong>
                                <%# DataBinder.Eval(Container.DataItem, "DescripcionPiePagina")%>
                            </div>
                        </fieldset>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
            <br />
            <br />
            <div id="encuestapiepagina">
                <asp:Literal ID="literalMensajePiePaginaEncuesta" runat="server"></asp:Literal>
            </div>
            <div id="encuestadescripcionpiepagina">
                <asp:Literal ID="literalDescripcionMensajePiePaginaEncuesta" runat="server"></asp:Literal>
            </div>
        </div>
        <br class="clear" />
    </div>
    <div>
        <asp:Literal ID="literlaMensajePiePagina" runat="server"></asp:Literal>
        <asp:Literal ID="literalDescripcionPiePagina" runat="server"></asp:Literal>
    </div>
</asp:Content>
