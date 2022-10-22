<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="Campanias_Mensaje_Listar" %>

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
        Plantilla de mensajes
    </h1>
    <div class="intro">
        <p>
            Esta plantilla, puede contener parámetros, los cuales seran encadenados durante el envio de correo, los parámetros deben ser ingresados con el siguiente formato <strong>##identificador_parámetro##</strong>
        </p>
    </div>
    <div id="formulario">
        <fieldset>
            <asp:HyperLink ID="hyperlinkCrearNuevaLista" runat="server" Text="Agregar un nuevo mensaje" NavigateUrl="~/Campanias/Mensaje/Crear.aspx"></asp:HyperLink>
        </fieldset>
    </div>
    <div class="div_form">
        <telerik:RadGrid ID="radGridMensajes" runat="server" AutoGenerateColumns="false" AllowSorting="false" OnNeedDataSource="radGridMensajes_NeedDataSource">
            <MasterTableView DataKeyNames="Id">
                <Columns>
                    <telerik:GridBoundColumn HeaderText="Titulo" DataField="Titulo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="NombreDe" DataField="NombreDe">
                    </telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn Text="Modificar" DataNavigateUrlFormatString="Editar.aspx?id={0}" DataNavigateUrlFields="Id" Target="_blank" AllowFiltering="false">
                    </telerik:GridHyperLinkColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
