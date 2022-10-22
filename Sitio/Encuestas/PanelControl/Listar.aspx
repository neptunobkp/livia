<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Listar.aspx.cs" Inherits="Encuestas_PanelControl_Listar" %>

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
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Encuestas
    </h1>
    <div class="intro">
    </div>
    <br />
    <asp:HyperLink ID="linkCrear" runat="server" Text="Agregar una nueva encuesta" NavigateUrl="~/Encuestas/PanelControl/Crear.aspx" Font-Underline="true"></asp:HyperLink>
    <div class="div_form">
        <telerik:RadGrid ID="radGridEncuestas" runat="server" PageSize="10" AutoGenerateColumns="false" AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="true" OnNeedDataSource="RadGrid1_NeedDataSource">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="Id" HeaderText="Id">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Titulo" HeaderText="Titulo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Introduccion" HeaderText="Introduccion">
                    </telerik:GridBoundColumn>
                    <telerik:GridDateTimeColumn DataField="FechaCreacion" HeaderText="Fecha de creación">
                    </telerik:GridDateTimeColumn>
                    <telerik:GridBoundColumn DataField="CantidadRespuestas" HeaderText="N° respuestas" AllowFiltering="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn Text="Ver resultados" DataNavigateUrlFormatString="VerResultados.aspx?encuestaId={0}&respuestas={1}" DataNavigateUrlFields="Id,CantidadRespuestas" Target="_blank"
                        AllowFiltering="false">
                    </telerik:GridHyperLinkColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
