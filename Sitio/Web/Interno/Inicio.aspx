<%@ Page Title="" Language="C#" MasterPageFile="~/Compartida/Masters/Principal.master" AutoEventWireup="true" CodeFile="Inicio.aspx.cs" Inherits="Web_Interno_Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="headcss" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="headjs" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="content_body" runat="Server">
    <h1>
        Livian
    </h1>
    <div class="intro">
        <p>
            Livia consiste en una plataforma para el envío de información digital tanto a los actuales clientes de su compañía como a prospectos.
        </p>
    </div>
    <div id="formulario">
        <div style="height: 260px">
            <img src="../../App_Themes/PulseTheme/images/inicio/campanias.png" style="float: right; margin-right: 20px" alt="1" />
            <h3>
                Campañas de Envio
            </h3>
            <p>
                Configure capañas de envío masivo de forma periódica o programada.
            </p>
        </div>
        <div style="height: 260px">
            <img src="../../App_Themes/PulseTheme/images/inicio/listacorreo.png" style="float: left; margin-right: 20px" alt="1" />
            <h3>
                Clientes
            </h3>
            <p>
                Crea un direcotrio de contactos desde el editor de listas de correos, el origen de esta lista puede ser, desde un archivo excel de carga, de forma manual o <strong>una sentencia sql sobre su motor de base de datos</strong>.
            </p>
        </div>
        <div style="height: 260px">
            <img src="../../App_Themes/PulseTheme/images/inicio/encuesta.png" style="float: right; margin-right: 20px" alt="1" />
            <h3>
                Encuestas
            </h3>
            <p>
                Diseña y configura encuestas a la medida, desde el editor de encuestas.
            </p>
            <p>
            </p>
        </div>
        <div style="height: 260px">
            <img src="../../App_Themes/PulseTheme/images/inicio/resultados.png" style="float: left; margin-right: 20px" alt="1" />
            <h3>
                Resultados
            </h3>
            <p>
                Analiza los resultados de respuestas de tus encuestas, desde los gráficos estadísticos presentados por cada encuesta.
            </p>
        </div>
        <div style="height: 260px">
            <img src="../../App_Themes/PulseTheme/images/inicio/paleta.png" style="float: right; margin-right: 20px" alt="1" />
            <h3>
                Personaliza
            </h3>
            <p>
                Personaliza la plantilla y el diseño del sitio y la vista del correo que presentara la encuesta a los clientes.
            </p>
        </div>
    </div>
</asp:Content>
