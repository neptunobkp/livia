<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="VerRespuestas.aspx.cs" Inherits="Encuestas_Resultados_VerRespuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Encuestas
    </h1>
    <div class="intro">
        Para ver el resultado de alguna encuesta, debe hacer click en el link, ver resultados
    </div>
    <br />
    <br />
    <div class="div_form">
        <telerik:RadGrid ID="radGridEncuestas" runat="server" PageSize="10" AutoGenerateColumns="false"
            AllowFilteringByColumn="true" AllowSorting="true" AllowPaging="true" OnNeedDataSource="RadGrid1_NeedDataSource">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="Id" HeaderText="Id">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Encuestado.Rut" HeaderText="Encuestado">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Encuestado.Correo" HeaderText="Correo Encuestado">
                    </telerik:GridBoundColumn>
                    <telerik:GridDateTimeColumn DataField="TipoEstadoRespuestaEncuesta" HeaderText="Estado">
                    </telerik:GridDateTimeColumn>
                    <telerik:GridDateTimeColumn DataField="InicioRespuestaEncuesta" HeaderText="Fecha">
                    </telerik:GridDateTimeColumn>
                    <telerik:GridDateTimeColumn DataField="NombreUsuarioCliente" HeaderText="Usuario">
                    </telerik:GridDateTimeColumn>
                    <telerik:GridDateTimeColumn DataField="Navegador" HeaderText="Browser">
                    </telerik:GridDateTimeColumn>
                    <telerik:GridHyperLinkColumn Text="Ver mas" DataNavigateUrlFormatString="~/Encuestas/Resultado/VerRespuesta.aspx?encuestaId={0}&respuestaId={1}"
                        DataNavigateUrlFields="IdentificadorPropietario,Id" Target="_blank" AllowFiltering="false">
                    </telerik:GridHyperLinkColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
