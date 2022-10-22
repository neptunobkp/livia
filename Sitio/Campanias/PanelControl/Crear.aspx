<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Campanias_PanelControl_Crear" %>

<%@ Register Src="~/Wuc/Bloques/bloqueValidacion.ascx" TagName="bloqueValidacion"
    TagPrefix="Pulse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
    <Pulse:bloqueValidacion ID="bloqueValidacioens" runat="server" />

    <script src="../../scripts/pulse/mantenedor_crear_conexion.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Crear una nueva campaña
    </h1>
    <div id="formulario" style="width: 700px">
        <fieldset class="superlargo clear">
            <asp:Label ID="lblNombreCampania" runat="server">Nombre de la campaña</asp:Label>
            <asp:TextBox ID="tbNombreCampania" runat="server" CssClass="superlargo required"></asp:TextBox>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblMotivoCampania" runat="server" AssociatedControlID="ddlMotivoCampania">Motivo para esta campaña</asp:Label>
            <asp:DropDownList ID="ddlMotivoCampania" runat="server" CssClass="superlargo required">
                <asp:ListItem Text="Nuevos asegurados de vehículo" Value="1"></asp:ListItem>
                <asp:ListItem Text="Nuevos asegurados de hogar" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblOtroMotivoCampania" runat="server" AssociatedControlID="tbOtroMotivoCampania">Otro Motivo</asp:Label>
            <asp:TextBox ID="tbOtroMotivoCampania" runat="server" CssClass="superlargo"></asp:TextBox>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblFechaProgramadaEnvio" runat="server" AssociatedControlID="tbFechaProgramadaEnvio">Fecha de ejecución</asp:Label>
            <telerik:RadDatePicker ID="tbFechaProgramadaEnvio" runat="server" Width="662px">
                <DateInput ID="DateInput1" runat="server" CssClass="superlargo required">
                </DateInput>
            </telerik:RadDatePicker>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblFechaProgramadaTermino" runat="server" AssociatedControlID="tbFechaProgramadaTermino">Fecha de termino ejecución</asp:Label>
            <telerik:RadDatePicker ID="tbFechaProgramadaTermino" runat="server" Width="662px">
                <DateInput ID="DateInput2" runat="server" CssClass="superlargo required">
                </DateInput>
            </telerik:RadDatePicker>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblPeriodoEjecucion" runat="server" AssociatedControlID="dllPeriodoEjecucion">Periodo de ejecucion</asp:Label>
            <asp:DropDownList ID="dllPeriodoEjecucion" runat="server" DataValueField="Id" DataTextField="Titulo"
                CssClass="superlargo required">
            </asp:DropDownList>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblCarpetaEncuesta" runat="server" AssociatedControlID="ddlCarpetasEncuesta">Carpeta de encuestas</asp:Label>
            <asp:DropDownList ID="ddlCarpetasEncuesta" runat="server" DataTextField="Nombre"
                DataValueField="Id" CssClass="superlargo">
            </asp:DropDownList>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="ddlEncuesta">Encuesta</asp:Label>
            <asp:DropDownList ID="ddlEncuesta" runat="server" CssClass="superlargo">
            </asp:DropDownList>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="Label3" runat="server" AssociatedControlID="ddlMensajesCorreo">Mensaje</asp:Label>
            <asp:DropDownList ID="ddlMensajesCorreo" runat="server" CssClass="superlargo required">
            </asp:DropDownList>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblListaCorreo" runat="server" AssociatedControlID="ddlListaCorreoEnvio">Lista de correo para envío</asp:Label>
            <asp:DropDownList ID="ddlListaCorreoEnvio" runat="server" CssClass="superlargo required">
            </asp:DropDownList>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblTipoEnvio" runat="server" AssociatedControlID="ddlTipoEnvioMasivo">Tipo de envio masivo</asp:Label>
            <asp:DropDownList ID="ddlTipoEnvioMasivo" runat="server" CssClass="superlargo required">
            </asp:DropDownList>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Button ID="btnGuardar" CssClass="submit" runat="server" Text="Guardar Campaña"
                OnClick="btnGuardar_Click" />
            <asp:Button ID="btnVistaPrevia" runat="server" Text="Vista previa de destinatarios"
                OnClick="btnVistaPrevia_Click" />
            <asp:Button ID="btnEjecutarEnvio" runat="server" Text="Ejecutar envio" OnClick="btnEjecutarEnvio_Click"
                Visible="false" />
        </fieldset>
        <br class="clear" />
    </div>
    <telerik:RadGrid ID="radGridListaCorreo" runat="server" AutoGenerateColumns="false"
        AllowSorting="true" AllowFilteringByColumn="true">
        <MasterTableView DataKeyNames="Id">
            <Columns>
                <telerik:GridBoundColumn HeaderText="Rut" DataField="Destinatario.Rut">
                </telerik:GridBoundColumn>
                <telerik:GridBoundColumn HeaderText="Correo" DataField="Destinatario.Correo">
                </telerik:GridBoundColumn>
            </Columns>
        </MasterTableView>
    </telerik:RadGrid>
</asp:Content>
