<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="VerResultados.aspx.cs" Inherits="Encuestas_Resultados_VerResultados" %>

<%@ Register Src="~/Encuestas/Resultados/ResultadoPreguntaOpcionMultiple.ascx" TagPrefix="Pulse"
    TagName="ResultadoPreguntaOpcionMultiple" %>
<%@ Register Src="~/Encuestas/Resultados/ResultadoPreguntaOpcionUnica.ascx" TagPrefix="Pulse"
    TagName="ResultadoPreguntaOpcionUnica" %>
<%@ Register Src="~/Encuestas/Resultados/ResultadoPreguntaParrafo.ascx" TagPrefix="Pulse"
    TagName="ResultadoPreguntaParrafo" %>
<%@ Register Src="~/Encuestas/Resultados/ResultadoPreguntaSimple.ascx" TagPrefix="Pulse"
    TagName="ResultadoPreguntaSimple" %>
<%@ Register Src="~/Encuestas/Resultados/ResultadoPreguntaOpcionMatriz.ascx" TagPrefix="Pulse"
    TagName="ResultadoPreguntaMatriz" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css"
        rel="stylesheet" type="text/css" />
    <link href="../../App_Themes/PulseTheme/css/styles/default/ui.css" rel="stylesheet"
        type="text/css" />
    <style type="text/css">
        .prev, .next
        {
            background-color: #00B4E2;
            color: White;
            font-weight: bold;
            padding: 5px 10px;
            color: #fff;
            text-decoration: none;
        }
        .prev:hover, .next:hover
        {
            background-color: #47BBCD;
            text-decoration: none;
        }
        .prev
        {
            float: left;
        }
        .next
        {
            float: right;
        }
        fieldset
        {
            border: none;
            width: 650px;
        }
        #steps
        {
            list-style: none;
            width: 100%;
            overflow: hidden;
            margin: 0px;
            padding: 0px;
        }
        #steps li
        {
            font-size: 24px;
            float: left;
            padding: 10px;
            color: #b0b1b3;
        }
        #steps li span
        {
            font-size: 11px;
            display: block;
        }
        #steps li.current
        {
            color: #000;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">

    <script src="../../scripts/jquery-1.6.4.min.js" type="text/javascript"></script>

    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

    <script type="text/javascript" src="formToWizard.js"></script>

    <script type="text/javascript">
       

    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <h1>
        Resultados encuesta
        <asp:Literal ID="literalTituloEncuesta" runat="server"></asp:Literal>
    </h1>
    <h3>
        Páginas</h3>
    <div id="divpaginas">
        <asp:Repeater ID="repeaterPaginas" runat="server">
            <ItemTemplate>
                <asp:HiddenField ID="hiddenNumeroPagina" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "NumeroPagina")%>' />
                <fieldset>
                    <legend>Preguntas</legend>
                    <br />
                    <br />
                    <asp:Repeater ID="repeaterPreguntas" runat="server" DataSource='<%# DataBinder.Eval(Container.DataItem, "Preguntas")%>'>
                        <ItemTemplate>
                            <asp:HiddenField ID="hiddenTipoPregunta" runat="server" Value='<%# ((int)DataBinder.Eval(Container.DataItem, "TipoPregunta")).ToString()%>' />
                            <asp:HiddenField ID="hiddenIdPregunta" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "Id")%>' />
                            <br class="clear" />
                            <asp:Panel ID="panelOtraPreguntaMultiple" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionMultiple"%>'>
                                <Pulse:ResultadoPreguntaOpcionMultiple ID="preguntaSeleccionMultiple" runat="server"
                                    CantidadRespuestas='<%# numeroRespuestas() %>' preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionMultiple" ? Container.DataItem : null%>' />
                            </asp:Panel>
                            <asp:Panel ID="panelOtraPreguntaOpcionUnica" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionUnica"%>'>
                                <Pulse:ResultadoPreguntaOpcionUnica ID="ResultadoPreguntaOpcionUnica" runat="server"
                                    CantidadRespuestas='<%# numeroRespuestas() %>' preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "SeleccionUnica" ? Container.DataItem : null%>' />
                            </asp:Panel>
                            <asp:Panel ID="panelOtraPreguntaTextoSimple" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoSimple"%>'>
                                <Pulse:ResultadoPreguntaSimple ID="ResultadoPreguntaSimple" runat="server" CantidadRespuestas='<%# numeroRespuestas() %>'
                                    preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoSimple" ? Container.DataItem : null%>' />
                            </asp:Panel>
                            <asp:Panel ID="panelOtraPreguntaTextoEnsayo" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoEnsayo"%>'>
                                <Pulse:ResultadoPreguntaParrafo ID="ResultadoPreguntaParrafo" runat="server" CantidadRespuestas='<%# numeroRespuestas() %>'
                                    preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "TextoEnsayo" ? Container.DataItem : null%>' />
                            </asp:Panel>
                            <asp:Panel ID="panelPreguntaMatriz" runat="server" Visible='<%# DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "Matriz"%>'>
                                <Pulse:ResultadoPreguntaMatriz ID="ResultadoPreguntaMatriz" runat="server" CantidadRespuestas='<%# numeroRespuestas() %>'
                                    preguntainterna='<%#  DataBinder.Eval(Container.DataItem, "TipoPregunta").ToString() == "Matriz" ? Container.DataItem : null%>' />
                            </asp:Panel>
                        </ItemTemplate>
                    </asp:Repeater>
                </fieldset>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</asp:Content>
