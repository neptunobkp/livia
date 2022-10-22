<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="ConfigurarEncuestas.aspx.cs" Inherits="Mantenedores_CarpetaEncuesta_ConfigurarEncuestas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">

    <script src="../../scripts/pulse/mantenedor_editar_carpetaencuesta.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Configurar Carpeta Encuesta
    </h1>
    <asp:ValidationSummary runat="server" ID="vsEncuestas" ValidationGroup="vgEncuestas" />
    <div class="intro">
    </div>
    <div id="formulario">
        <br />
        <br />
        <fieldset>
            <asp:Label ID="lblgrupo" runat="server" Text="Grupo" AssociatedControlID="ddlGrupo"></asp:Label>
            <asp:DropDownList runat="server" ID="ddlGrupo">
            </asp:DropDownList>
            <asp:RequiredFieldValidator ID="requiereGrupo" runat="server" ControlToValidate="ddlGrupo"
                ValidationGroup="vgEncuestas"></asp:RequiredFieldValidator>
        </fieldset>
        <telerik:RadGrid ID="radGridEncuestas" runat="server" PageSize="10" AutoGenerateColumns="false"
            AllowSorting="true" AllowPaging="true">
            <MasterTableView>
                <Columns>
                    <telerik:GridBoundColumn DataField="Titulo" HeaderText="Nombre">
                    </telerik:GridBoundColumn>
                    <telerik:GridTemplateColumn AllowFiltering="false" HeaderText="Selección">
                        <ItemTemplate>
                            <asp:HiddenField ID="hfId" runat="server" Value='<%# Eval("Id")%>' />
                            <asp:RadioButtonList ID="rblEstados" runat="server" RepeatDirection="Horizontal">
                                <asp:ListItem Selected="True" Text="No Seleccionada" Value="0"></asp:ListItem>
                                <asp:ListItem Text="Obligatoria" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Opcional" Value="2"></asp:ListItem>
                            </asp:RadioButtonList>
                        </ItemTemplate>
                    </telerik:GridTemplateColumn>
                </Columns>
            </MasterTableView>
        </telerik:RadGrid>
        <fieldset>
            <asp:Button ID="btnGuardar" CausesValidation="true" ValidationGroup="vgEncuestas"
                runat="server" Visible="false" Text="Guardar" OnClick="btnGuardar_Click" />
        </fieldset>
    </div>
</asp:Content>
