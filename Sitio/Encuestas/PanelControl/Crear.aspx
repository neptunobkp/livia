<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Encuestas_PanelControl_Crear" %>

<%@ Register Src="~/Encuestas/PanelControl/PaginaEncuesta.ascx" TagPrefix="PulsePregunta" TagName="PaginaEncuesta" %>
<%@ Register Src="~/Encuestas/PanelControl/OpcionUnica.ascx" TagPrefix="PulsePregunta" TagName="OpcionUnica" %>
<%@ Register Src="~/Encuestas/PanelControl/OpcionMultiple.ascx" TagPrefix="PulsePregunta" TagName="OpcionMultiple" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        html body .RadInput_Windows7 .riEmpty, html body .RadInput_Empty_Windows7
        {
            color: #00B4E2 !important;
            font-weight: bold;
        }
        .ui-tabs-vertical
        {
            width: 55em;
        }
        .ui-tabs-vertical .ui-tabs-nav
        {
            float: left;
            padding: 0.2em 0.1em 0.2em 0.2em;
            width: 12em;
        }
        .ui-tabs-vertical .ui-tabs-nav li
        {
            border-bottom-width: 1px !important;
            border-right-width: 0 !important;
            clear: left;
            margin: 0 -1px 0.2em 0;
            width: 100%;
        }
        .ui-tabs-vertical .ui-tabs-nav li a
        {
            display: block;
        }
        .ui-tabs-vertical .ui-tabs-nav li.ui-tabs-selected
        {
            border-right-width: 1px;
            padding-bottom: 0;
            padding-right: 0.1em;
        }
        .ui-tabs-vertical .ui-tabs-panel
        {
            float: right;
            padding: 1em;
            width: 40em;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">

    <script src="../../scripts/jquery-1.6.4.min.js" type="text/javascript"></script>

    <script src="../../scripts/jquery-ui-1.8.16.custom.min.js" type="text/javascript"></script>

    <script src="../../scripts/pulse/encuesta.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <br />
    <h3>
        Agregar nueva encuesta
    </h3>
    <div>
        <span>Número de páginas</span>
        <asp:RadioButtonList ID="radiButtonListNumeroPaginas" runat="server" RepeatDirection="Horizontal" CellSpacing="10" RepeatLayout="Flow">
            <asp:ListItem Text="1" Value="1"></asp:ListItem>
            <asp:ListItem Text="2" Value="2"></asp:ListItem>
            <asp:ListItem Text="3" Value="3"></asp:ListItem>
            <asp:ListItem Text="4" Value="4"></asp:ListItem>
        </asp:RadioButtonList>
    </div>
    <br />
    <div style="width: 800px; margin-left: 1px">
        <asp:LinkButton ID="linkGuardar" runat="server" OnClick="linkGuardar_Click" ForeColor="White" CssClass="linkbotonencuesta">
                    <img src="../../App_Themes/PulseTheme/images/icons/plus.gif" alt="+"  />
                    <span>Guardar encuesta</span>
        </asp:LinkButton>
    </div>
    <br />
    <div id="tabs">
        <ul>
            <li><a href="#conf">Configuración</a></li>
            <li><a href="#pag1">Página 1</a></li>
            <li>
                <asp:LinkButton href="#tabs-2" runat="server" ID="linkTab2">Página 2</asp:LinkButton></li>
            <li>
                <asp:LinkButton href="#tabs-3" runat="server" ID="linkTab3">Página 3</asp:LinkButton></li>
            <li>
                <asp:LinkButton href="#tabs-4" runat="server" ID="linkTab4">Página 4</asp:LinkButton></li>
        </ul>
        <div id="conf">
            <table>
                <tbody>
                    <tr>
                        <td colspan="2">
                            <telerik:RadTextBox ID="tbTituloEncuesta" runat="server" EmptyMessage="Titulo de encuesta" Width="500px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <telerik:RadTextBox ID="tbDescripcionEncuesta" runat="server" EmptyMessage="Descripción de encuesta" Width="500px" TextMode="MultiLine" Height="150px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <telerik:RadComboBox ID="radcomboPlantilla" runat="server" Width="500px">
                                <Items>
                                    <telerik:RadComboBoxItem Value="" Text="Seleccione una plantilla" />
                                </Items>
                            </telerik:RadComboBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <h3>
                                &nbsp;</h3>
                            <br class="clear" />
                            <telerik:RadTextBox ID="tbMensajePiePagina" runat="server" EmptyMessage="Mensaje de pie de página" Width="500px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <telerik:RadTextBox ID="tbDescripcionPiePagina" runat="server" EmptyMessage="Decripción de pie de página" Width="500px" TextMode="MultiLine" Height="150px">
                            </telerik:RadTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <telerik:RadDatePicker ID="tbFechaInicioEncuesta" runat="server" DateInput-DateFormat="dd-MM-yyyy" Width="250px">
                                <DateInput runat="server" EmptyMessage="Fecha inicio" Width="250px">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                        <td>
                            <telerik:RadDatePicker ID="tbFechaTErminoEncuesta" runat="server" Width="250px">
                                <DateInput runat="server" EmptyMessage="Fecha término" Width="250px">
                                </DateInput>
                            </telerik:RadDatePicker>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <br />
                            <telerik:RadNumericTextBox Label="Límite de encuestas" Width="500px" ID="tbCantidadEncuestasMaximas" Type="Number" ShowSpinButtons="true" MinValue="0" MaxValue="100000" runat="server"
                                EmptyMessage="Dejar en 0 para no limitar" NumberFormat-DecimalDigits="0">
                            </telerik:RadNumericTextBox>
                            <br />
                            <br />
                            <asp:CheckBox ID="checkMantenerPrimeraPaginaContenida" runat="server" Text="Mantener presentación y primera página juntas" />
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div id="pag1">
            <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                <ContentTemplate>
                    <PulsePregunta:PaginaEncuesta ID="paginaEncuesta1" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-2">
            <asp:UpdatePanel ID="udp1" runat="server">
                <ContentTemplate>
                    <PulsePregunta:PaginaEncuesta ID="paginaEncuesta2" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-3">
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <PulsePregunta:PaginaEncuesta ID="paginaEncuesta3" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
        <div id="tabs-4">
            <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                <ContentTemplate>
                    <PulsePregunta:PaginaEncuesta ID="paginaEncuesta4" runat="server" />
                </ContentTemplate>
            </asp:UpdatePanel>
        </div>
    </div>
    <br />
    <div style="width: 800px; margin-left: 1px">
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="linkGuardar_Click" ForeColor="White" CssClass="linkbotonencuesta">
                    <img src="../../App_Themes/PulseTheme/images/icons/plus.gif" alt="+"  />
                    <span>Guardar encuesta</span>
        </asp:LinkButton>
    </div>
</asp:Content>
