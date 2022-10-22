<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Mantenedores_CarpetaEncuesta_Crear" %>

<%@ Register Src="~/Wuc/Bloques/bloqueValidacion.ascx" TagName="bloqueValidacion"
    TagPrefix="Pulse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
    <Pulse:bloqueValidacion ID="bloqueValidacioens" runat="server" />

    <script src="../../scripts/pulse/mantenedor_crear_carpetaencuesta.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Agregar nueva Carpeta Encuesta
    </h1>
    <div id="formulario">
        <fieldset class="largo clear">
            <asp:Label ID="lblNombre" runat="server" AssociatedControlID="tbNombre">Nombre Carpeta</asp:Label>
            <asp:TextBox ID="tbNombre" runat="server" CssClass="required"></asp:TextBox>
        </fieldset>
        <telerik:RadGrid ID="radGridEncuestas" runat="server" PageSize="10" AutoGenerateColumns="false"
            AllowSorting="true" AllowPaging="false">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="Titulo" HeaderText="Nombre Encuesta">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Selección">
                        <ItemTemplate>
                            <asp:CheckBox ID="checkSeleccionar" CssClass='<%# Eval("Id")%>' runat="server"></asp:CheckBox>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <fieldset class="largo clear">
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" OnClick="btnGuardar_Click" />
        </fieldset>
    </div>
</asp:Content>
