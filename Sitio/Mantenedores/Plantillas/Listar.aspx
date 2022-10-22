<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="Mantenedores_Plantillas_Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">

    <script src="../../scripts/pulse/manetenedor_listar_plantilla.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Plantillas de encuesta
    </h1>
    <div class="intro">
    </div>
    <div id="formulario">
        <fieldset class="clear">
            <asp:HyperLink ID="HyperLink1" NavigateUrl="~/Mantenedores/Plantillas/Crear.aspx" Text="Agregar una nueva plantilla" runat="server"></asp:HyperLink>
        </fieldset>
        <br />
        <br />
        <telerik:RadGrid ID="radGridPlantillas" runat="server" PageSize="10" AutoGenerateColumns="false" AllowSorting="true" AllowPaging="true" OnNeedDataSource="RadGrid1_NeedDataSource" OnItemCommand="grid_oncommmand">
            <MasterTableView DataKeyNames="Id">
                <Columns>
                    <telerik:GridBoundColumn DataField="Id" HeaderText="Identificador">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Nombre" HeaderText="Nombre">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Titulo" HeaderText="Titulo">
                    </telerik:GridBoundColumn>
                    <%-- <telerik:GridHyperLinkColumn DataNavigateUrlFormatString="VerResultados.aspx?encuestaId={0}&respuestas={1}" DataNavigateUrlFields="Id,CantidadRespuestas" Target="_blank" AllowFiltering="false">
                        <img src="../../App_Themes/PulseTheme/images/grid/lapiz.png" alt="edit" />
                    </telerik:GridHyperLinkColumn>--%>
                    <telerik:GridTemplateColumn HeaderText="opt">
                        <ItemTemplate>
                            <asp:LinkButton ID="linkEditar" runat="server" CommandName="Modificar" ToolTip="Modificar plantilla" Visible="false" CommandArgument='<%# Eval("Id") %>'>
                                <img src="../../App_Themes/PulseTheme/images/grid/editar.png" alt="1"/>
                            </asp:LinkButton>
                            <asp:LinkButton ID="linkEliminar" runat="server" CommandName="Eliminar" ToolTip="Eliminar plantilla" CommandArgument='<%# Eval("Id") %>' OnClientClick="return confirm('¿Está seguro que desea eliminar este registro?');">
                                <img src="../../App_Themes/PulseTheme/images/grid/eliminar.png" alt="2" />
                            </asp:LinkButton>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
