<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="Campanias_ListaCorreo_Listar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css" rel="stylesheet" type="text/css" />

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">

    <script type="text/javascript">
        $(document).ready(function() {

            $('#panel-mensaje-popup').dialog({
                autoOpen: false,
                width: 600,
                bgiframe: false,
                modal: true,
                buttons: {
                    "Aceptar": function() {
                        $(this).dialog("close");
                    }
                }
            });
        });
    </script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="radScriptManager" runat="server">
    </telerik:RadScriptManager>
    <h1>
        Listas de correo
    </h1>
    <div class="intro">
        Las listas de correo son utilizadas para el envio de correos masivos, o encuestas masivas mediante correos.
    </div>
    <div id="formulario">
        <fieldset>
            <asp:HyperLink ID="hyperlinkCrearNuevaLista" runat="server" Text="Agregar una nueva lista de correo" NavigateUrl="~/Campanias/ListaCorreo/Crear.aspx"></asp:HyperLink>
        </fieldset>
    </div>
    <div class="div_form">
        <telerik:RadGrid ID="radGridListasCorreo" runat="server" AutoGenerateColumns="false" AllowSorting="false" OnNeedDataSource="radGridListasCorreo_NeedDataSource">
            <MasterTableView DataKeyNames="Id">
                <Columns>
                    <telerik:GridBoundColumn HeaderText="Descripcion" DataField="Descripcion">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Codigo" DataField="Codigo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="TipoOrigenListaCorreo" DataField="TipoOrigenListaCorreo">
                    </telerik:GridBoundColumn>
                    <telerik:GridDateTimeColumn HeaderText="Fecha de creación" DataField="FechaCreacion">
                    </telerik:GridDateTimeColumn>
                    <telerik:GridHyperLinkColumn Text="Modificar" DataNavigateUrlFormatString="Editar.aspx?id={0}" DataNavigateUrlFields="Id" Target="_blank" AllowFiltering="false">
                    </telerik:GridHyperLinkColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
