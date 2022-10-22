<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master"
    AutoEventWireup="true" CodeFile="Crear.aspx.cs" Inherits="Campanias_ListaCorreo_Crear" %>

<%@ Register Src="~/Wuc/Bloques/bloqueValidacion.ascx" TagName="bloqueValidacion"
    TagPrefix="Pulse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
    <link href="../../App_Themes/PulseTheme/css/jqueryui/jquery-ui-1.8.16.custom.css"
        rel="stylesheet" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
    <Pulse:bloqueValidacion ID="bloqueValidacioens" runat="server" />

    <script src="../../scripts/pulse/campania_listacorreo_crear.js" type="text/javascript"></script>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <telerik:RadScriptManager ID="ScriptManager" runat="server" />
    <h1>
        Crear una nueva lista de correo
    </h1>
    <div class="intro">
        Es posible agregar una lista de correo, a travez de la ejecución de una query, la
        subida de un archivo de carga o ingresado manualmente
    </div>
    <div id="formulario">
        <fieldset class="superlargo clear">
            <asp:Label ID="lblNombreListaCorreo" runat="server" AssociatedControlID="tbNombreListaCorreo">Nombre para la lista de correo</asp:Label>
            <asp:TextBox ID="tbNombreListaCorreo" runat="server" CssClass="superlargo required"></asp:TextBox>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblCodigoListaCorreo" runat="server" AssociatedControlID="tbCodigoListaCorreo">Codigo identificador de apoyo</asp:Label>
            <asp:TextBox ID="tbCodigoListaCorreo" runat="server" CssClass="superlargo required"></asp:TextBox>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblGrupo" runat="server" AssociatedControlID="ddlGrupo">Grupo</asp:Label>
            <asp:DropDownList ID="ddlGrupo" runat="server" DataTextField="Alias" DataValueField="Id"
                Style="width: 630px; float: left">
            </asp:DropDownList>
            <a href="../../Mantenedores/Grupos/Crear.aspx" title="Agregar un nuevo grupo" style="float: right">
                <img src="../../App_Themes/PulseTheme/images/icons/agregar.png" alt="+" />
            </a>
        </fieldset>
        <fieldset class="superlargo clear">
            <asp:Label ID="lblTipoContacto" runat="server" AssociatedControlID="ddlGrupo">Forma de Contacto</asp:Label>
            <asp:DropDownList ID="ddlFormaContacto" runat="server" Style="width: 630px; float: left">
                <asp:ListItem Text="Correo Electrónico" Value="1"></asp:ListItem>
                <asp:ListItem Text="Mensaje de Texto" Value="2"></asp:ListItem>
            </asp:DropDownList>
        </fieldset>
        <br class="clear" />
        <br />
        <div id="tabs">
            <ul>
                <li><a href="#tab1">Originado por una sentencia sql</a></li>
                <li><a href="#tab2">Cargalo desde un archivo excel</a></li>
                <li><a href="#tab3">Ingresalo uno a uno de forma manual</a></li>
            </ul>
            <div id="tab1">
                <div class="intro">
                    <p>
                        Desde aqui es posible obtener la lista de correo, desde alguna fuente de datos,
                        la query ingresada aqui, debe tener la siguiente estructura, dado que hay información
                        obligatoria para poder ejecutar la transacción.
                    </p>
                    <p>
                        <strong>Formato</strong> : (Select rut* , correo* , identificador*,[parametros,
                        archivos]). destacando con (*) los campos que deben ser obligatorios y con [ ] aquellos
                        que deben ir juntos.
                    </p>
                    <p>
                        <strong>Parámetros</strong> : nombre=juan perez. En caso de enviar mas de un parámetro,
                        estos deben estar separados por un [p] de esta forma nombre=juan perez[p]telefono=5581555
                    </p>
                    <p>
                        <strong>Archivos adjuntos</strong> : los archivos deben contener solo el nombre
                        de la carpeta/nombre del archivo. (Estos archivos deberan haber sido precargados
                        dentro de la carpeta Bandeja/out/{nombre carpeta} del sitio. En caso de adjuntar
                        mas de un archivo, debe esta separados por un pipe "|"
                    </p>
                </div>
                <fieldset class="superlargo clear">
                    <asp:Label ID="lblSentenciaSql" runat="server" AssociatedControlID="tbSentenciaSql">Sentencia SQL</asp:Label>
                    <asp:TextBox ID="tbSentenciaSql" runat="server" CssClass="superlargo sql" TextMode="MultiLine"
                        Width="650px" Height="250px" Font-Names="Curier New" Font-Size="22px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="requiereSentenciaSql" runat="server" ControlToValidate="tbSentenciaSql"
                        ValidationGroup="vgSentenciaSql">*</asp:RequiredFieldValidator>
                </fieldset>
                <fieldset class="superlargo clear">
                    <asp:Label ID="lblCadenaConexion" runat="server" AssociatedControlID="ddlCadenaConexion">Fuente de datos</asp:Label>
                    <asp:DropDownList ID="ddlCadenaConexion" runat="server" DataTextField="Alias" DataValueField="Id"
                        Style="width: 630px; float: left">
                    </asp:DropDownList>
                    <a href="../../Mantenedores/Conexiones/Crear.aspx" title="Agregar una nueva fuente de datos"
                        style="float: right">
                        <img src="../../App_Themes/PulseTheme/images/icons/agregar.png" alt="+" />
                    </a>
                </fieldset>
                <br class="clear" />
                <div id="format_button">
                    <asp:CheckBox ID="checkRutsContieneDigitoVerificador" runat="server" Text="¿El rut ya viene con dígito verificador?"
                        Checked="true" />
                    <asp:CheckBox ID="checkEjecutarAhora" Text="¿Ejecutar query en el envío?." runat="server"
                        Checked="true" />
                </div>
                <br class="clear" />
                <fieldset class="superlargo clear">
                    <asp:LinkButton ID="linkCargarVistaPrevia" runat="server" Text="" OnClick="btnCargar_Click"
                        CausesValidation="true" ValidationGroup="vgSentenciaSql">
                        <img src="../../App_Themes/PulseTheme/images/icons/play.png" alt="x" />
                        <span>Ejecutar sentencia, para una vista previa de los datos.</span>
                    </asp:LinkButton>
                </fieldset>
                <br class="clear" />
                <telerik:RadGrid ID="gridPersonas" runat="server" AutoGenerateColumns="false" AllowPaging="true"
                    PageSize="15">
                    <MasterTableView>
                        <Columns>
                            <telerik:GridBoundColumn DataField="RutOrigen" HeaderText="Rut">
                            </telerik:GridBoundColumn>
                            <telerik:GridTemplateColumn HeaderText="Dato Envio">
                                <ItemTemplate>
                                    <%# (Eval("CorreosOrigen") == null ? Eval("Celular") : Eval("CorreosOrigen"))%>
                                </ItemTemplate>
                            </telerik:GridTemplateColumn>
                            <telerik:GridBoundColumn DataField="IdentificadorContextoOrigen" HeaderText="Identificador">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="GlosaParametros" HeaderText="Parámetros">
                            </telerik:GridBoundColumn>
                            <telerik:GridBoundColumn DataField="ReferenciaArchivosAdjuntoOrigen" HeaderText="Archivos">
                            </telerik:GridBoundColumn>
                        </Columns>
                    </MasterTableView>
                </telerik:RadGrid>
                <br class="clear" />
            </div>
            <div id="tab2">
                <p>
                    Puede subir un archivo excel, con la extensión *.csv, para una interpretación clara
                    de los datos, al igual que los otros tipos de carga, la estructura, debe ser respetada
                    :
                </p>
                <table cellspacing="10px">
                    <tbody>
                        <tr>
                            <td style="border: solid 1px; padding: 10px">
                                Rut;
                            </td>
                            <td style="border: solid 1px; padding: 10px">
                                Correo;
                            </td>
                            <td style="border: solid 1px; padding: 10px">
                                Identificador;
                            </td>
                            <td style="border: solid 1px; padding: 10px">
                                Parametros;
                            </td>
                            <td style="border: solid 1px; padding: 10px">
                                Archivos
                            </td>
                        </tr>
                    </tbody>
                </table>
                <fieldset class="superlargo clear">
                    <asp:Label ID="lblArchivoAdjunto" runat="server" AssociatedControlID="fuArchivoCarga">Archivo de carga csv.</asp:Label>
                    <asp:FileUpload ID="fuArchivoCarga" runat="server" Width="600px" />
                </fieldset>
                <br class="clear" />
            </div>
            <div id="tab3">
                <p>
                    Puede ingresar uno a uno los registros de forma manual, este sistema al igual que
                    el archivo de carga permite escribir sobre el campo de ingreso, se deja un ejemplo
                    en el campo.
                </p>
                <fieldset class="clear">
                    <asp:Label ID="lblDatos" runat="server" AssociatedControlID="tbDatos">Datos</asp:Label>
                    <asp:TextBox ID="tbDatos" runat="server" CssClass="superlargo" TextMode="MultiLine"
                        Width="650px" Height="300px"></asp:TextBox>
                </fieldset>
                <span>Ejemplo : 1234567-5;correo@ejemplo.cl;123;[params];[archivos]</span>
                <br class="clear" />
            </div>
        </div>
        <asp:Button ID="btnGuardar" runat="server" OnClick="btnGuardar_Click" Text="Guardar la lista de correo" />
    </div>
</asp:Content>
