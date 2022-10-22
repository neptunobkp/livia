<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ResponderEncuestas.aspx.cs"
    MasterPageFile="~/Compartida/Masters/ExternoMaster.master" Inherits="Web_Encuesta_ResponderEncuestas" %>

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
        <asp:Image ID="imageBanner" ImageUrl="~/App_Themes/PulseTheme/css/styles/" runat="server" />
        <div class="content">
            <h1>
                Encuesta Cliente Interno
            </h1>
            <div class="hastable">
                <asp:Repeater ID="repeaterEncuestas" runat="server">
                    <HeaderTemplate>
                        <table>
                            <thead>
                                <tr>
                                    <th>
                                        Área
                                    </th>
                                    <th>
                                        Servicio
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
                            <td style="width:200px;font-weight:bold">
                                <%# DataBinder.Eval(Container.DataItem, "Introduccion")%> 
                            </td>
                            <td>
                                <asp:HyperLink ID="hyperlinkEncuesta" runat="server" NavigateUrl='<%# DataBinder.Eval(Container.DataItem,"UrlEncuesta" )%>'
                                    Text='<%# DataBinder.Eval(Container.DataItem,"NombreEncuesta" )%>' Enabled='<%# DataBinder.Eval(Container.DataItem,"Disponible" )%>'></asp:HyperLink>
                            </td>
                            <td>
                                <%# DataBinder.Eval(Container.DataItem, "TipoCategoria")%>
                            </td>
                            <td>
                                <%#DataBinder.Eval(Container.DataItem, "Estado") %>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody> </table>
                    </FooterTemplate>
                </asp:Repeater>
                <br />
                <br />
            </div>
        </div>
    </div>
    <br class="clear" />
</asp:Content>
