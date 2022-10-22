<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Resultado.aspx.cs" Inherits="Campanias_PanelControl_Resultado" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="radScriptManager" runat="server">
    </telerik:RadScriptManager>
    <asp:HiddenField ID="hiddenListaCorreoId" runat="server" />
    <h1>
        Resultado de envío
    </h1>
    <div class="intro">
        Reporte del resultado de envio.
    </div>
    <div class="div_form">
        <telerik:RadGrid ID="radGridListaCorreo" runat="server" AutoGenerateColumns="false" AllowSorting="false" OnNeedDataSource="radGridListaCorreo_NeedDataSource">
            <MasterTableView DataKeyNames="Id">
                <Columns>
                    <telerik:GridBoundColumn HeaderText="Rut" DataField="Destinatario.Rut">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Correo" DataField="Destinatario.Correo">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Estado del envío" DataField="TipoEstadoEnvio">
                    </telerik:GridBoundColumn>
                    <telerik:GridBoundColumn HeaderText="Anotacion" DataField="Anotacion">
                    </telerik:GridBoundColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
    </div>
</asp:Content>
