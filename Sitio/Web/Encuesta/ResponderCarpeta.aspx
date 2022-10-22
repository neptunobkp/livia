<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/ExternoMaster.master"
    AutoEventWireup="true" CodeFile="ResponderCarpeta.aspx.cs" Inherits="Web_Encuesta_ResponderCarpeta" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <style type="text/css">
        .progress-bar
        {
            border: 1px solid #00B4E2;
            background: #ffffff;
            width: 100%;
            height: 24px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            -khtml-border-radius: 10px;
            border-radius: 10px;
        }
        .status
        {
            background: #85C300;
            width: 50%;
            height: 24px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            -khtml-border-radius: 10px;
            border-radius: 10px;
            text-align: center;
            color: White;
            font-weight: bolder;
            font-size: large;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <div id="formencuesta">
        <div class="content">
            <h1>
                Carpeta de encuestas
            </h1>
            <div class="hastable">
                <asp:Repeater ID="repeaterEncuestas" runat="server">
                    <HeaderTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <th>
                                        Encuesta
                                    </th>
                                    <th>
                                        Categoría
                                    </th>
                                    <th>
                                        Estado
                                    </th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:HyperLink ID="hyperlinkEncuesta" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"UrlEncuesta" )%>'
                                    Text='<%# DataBinder.Eval(Container.DataItem,"NombreEncuesta" )%>' Enabled='<%# DataBinder.Eval(Container.DataItem,"Disponible" )%>'></asp:HyperLink>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TipoCategoria")%>
                            </td>
                            <td style="text-align: center">
                                <asp:HyperLink ID="hyperlinkEstadoEncuesta" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"UrlEncuesta" )%>'
                                    ToolTip='<%# DataBinder.Eval(Container.DataItem,"ToolTipIcon" )%>' Enabled='<%# DataBinder.Eval(Container.DataItem,"Disponible" )%>'>
                        <img src='<%# DataBinder.Eval(Container.DataItem,"PathImagenEstado" )%>'  alt='<%# DataBinder.Eval(Container.DataItem,"Disponible" ).ToString()%>' />
                                </asp:HyperLink>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                <br />
                <h4>
                    Estado de avance sobre las encuestas obligatorias.
                </h4>
                <div class="progress-bar">
                    <div id="status" class="status">
                        <asp:Literal ID="literalPorcentajeAvance" runat="server"></asp:Literal>
                    </div>
                </div>
                <br />
                <br />
                <h4>
                    Estado de avance general.
                </h4>
                <div class="progress-bar">
                    <div id="status2" class="status">
                        <asp:Literal ID="literalPorcentajeAvanceOtras" runat="server"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
