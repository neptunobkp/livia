<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Opciones.aspx.cs" Inherits="Encuestas_PanelControl_Opciones" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Editor de encuestas
    </h1>
    <div class="intro">
    </div>
    <div id="formulario">
        <fieldset class="largo clear">
            <a href="Crear.aspx">Agregar una nueva encuesta desde cero. </a>
        </fieldset>
        <br />
        <fieldset class="largo clear">
            <a href="../../Mantenedores/Plantillas/Crear.aspx">Crear una plantilla.</a>
        </fieldset>
        <fieldset class="largo clear">
            <a href="Listar.aspx">Ver todas las encuestas.</a>
        </fieldset>
    </div>
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
