<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="Mantenedores_CarpetaEncuesta_Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">

    <script src="../../scripts/pulse/mantenedor_editar_carpetaencuesta.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Carpeta Encuesta
    </h1>
    <div class="intro">
    </div>
    <div id="formulario">
        <fieldset class="clear">
            <asp:HyperLink NavigateUrl="~/Mantenedores/CarpetaEncuesta/Crear.aspx" Text="Agregar nueva Carpeta de Encuesta"
                runat="server"></asp:HyperLink>
        </fieldset>
        <br />
        <br />
        <telerik:RadGrid ID="radGridCadenasConexion" runat="server" PageSize="10" AutoGenerateColumns="false"
            AllowSorting="true" AllowPaging="true" OnNeedDataSource="RadGrid1_NeedDataSource">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre">
                    </telerik:GridBoundColumn>
                    <%--<telerik:GridHyperLinkColumn Text="Modificar" DataNavigateUrlFormatString="Editar.aspx?carpetaEncuestaId={0}"
                    </telerik:GridHyperLinkColumn>--%>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
