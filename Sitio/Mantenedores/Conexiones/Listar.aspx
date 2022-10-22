<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="Mantenedores_Conexiones_Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">

    <script src="../../scripts/pulse/mantenedor_editar_conexion.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Cadenas de conexion
    </h1>
    <div class="intro">
    </div>
    <div id="formulario">
        <fieldset class="clear">
            <asp:HyperLink NavigateUrl="~/Mantenedores/Conexiones/Crear.aspx" Text="Agregar nueva cadena de conexión" runat="server"></asp:HyperLink>
        </fieldset>
        <br />
        <br />
        <telerik:RadGrid ID="radGridCadenasConexion" runat="server" PageSize="10" AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" OnNeedDataSource="RadGrid1_NeedDataSource">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="Alias" HeaderText="Alias">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Servidor" HeaderText="Servidor">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="BaseDatos" HeaderText="BaseDatos">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="NombreUsuario" HeaderText="NombreUsuario">
                    </telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn Text="Modificar" DataNavigateUrlFormatString="VerResultados.aspx?encuestaId={0}&respuestas={1}" DataNavigateUrlFields="Id,CantidadRespuestas" Target="_blank"
                        AllowFiltering="false">
                    </telerik:GridHyperLinkColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
