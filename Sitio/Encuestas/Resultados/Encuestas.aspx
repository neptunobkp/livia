<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="Encuestas.aspx.cs" Inherits="Encuestas_Resultados_Encuestas" %>

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
                    <telerik:GridBoundColumn DataField="Titulo" HeaderText="Titulo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn DataField="Introduccion" HeaderText="Introduccion">
                    </telerik:GridBoundColumn>
                    <telerik:GridDateTimeColumn DataField="FechaCreacion" HeaderText="Fecha de creación">
                    </telerik:GridDateTimeColumn>
                    <telerik:GridBoundColumn DataField="CantidadRespuestas" HeaderText="N° respuestas"
                        AllowFiltering="false">
                    </telerik:GridBoundColumn>
                    <telerik:GridHyperLinkColumn Text="Ver Respuestas" DataNavigateUrlFormatString="VerRespuestas.aspx?encuestaId={0}"
                        DataNavigateUrlFields="Id" AllowFiltering="false">
                    </telerik:GridHyperLinkColumn>
                    <telerik:GridHyperLinkColumn Text="Ver Totales" DataNavigateUrlFormatString="VerResultados.aspx?encuestaId={0}&respuestas={1}"
                        DataNavigateUrlFields="Id,CantidadRespuestas" Target="_blank" AllowFiltering="false">
                    </telerik:GridHyperLinkColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
