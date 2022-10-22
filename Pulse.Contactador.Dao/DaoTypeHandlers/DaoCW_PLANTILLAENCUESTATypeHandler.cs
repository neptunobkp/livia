using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dao.DaoDataModel;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.Dao.DaoTypeHandlers
{
    public class DaoCW_PLANTILLAENCUESTATypeHandler
    {
        public static Plantilla CastToDto(DaoCW_PLANTILLAENCUESTA cw_plantillaencuesta)
        {
            Plantilla dtoObject = new Plantilla()
            {
                BotonSiguiente = new ControlPlantilla(),
                BotonVolver = new ControlPlantilla(),
                BotonGuardar = new ControlPlantilla(),
                BotonSalir = new ControlPlantilla(),
                UsuarioCreador = new Usuario(),
                UsuarioModificador = new Usuario()
            };
            dtoObject.Id = cw_plantillaencuesta.IDPLANTILLAENCUESTA;
            dtoObject.PathBanner = cw_plantillaencuesta.PATHBANNER;
            //dtoObject.AlineacionLogo = cw_plantillaencuesta.ALINEACIONLOGO; TODO
            //dtoObject.AlineacionEncuesta = cw_plantillaencuesta.ALINEACIONENCUESTA; TODO
            dtoObject.RutaArchivoCss = cw_plantillaencuesta.RUTAARCHIVOCSS;
            dtoObject.BotonSiguiente.Texto = cw_plantillaencuesta.BOTONSIGUIENTETEXTO;
            dtoObject.BotonSiguiente.Largo = cw_plantillaencuesta.BOTONSIGUIENTELARGO;
            dtoObject.BotonSiguiente.Ancho = cw_plantillaencuesta.BOTONSIGUIENTEANCHO;
            dtoObject.BotonSiguiente.PathImagen = cw_plantillaencuesta.BOTONSIGUIENTEPATHIMAGEN;
            dtoObject.BotonVolver.Texto = cw_plantillaencuesta.BOTONVOLVERTEXTO;
            dtoObject.BotonVolver.Largo = cw_plantillaencuesta.BOTONVOLVERLARGO;
            dtoObject.BotonVolver.Ancho = cw_plantillaencuesta.BOTONVOLVERANCHO;
            dtoObject.BotonVolver.PathImagen = cw_plantillaencuesta.BOTONVOLVERPATHIMAGEN;
            dtoObject.BotonGuardar.Largo = cw_plantillaencuesta.BOTONGUARDARLARGO;
            dtoObject.BotonGuardar.Ancho = cw_plantillaencuesta.BOTONGUARDARANCHO;
            dtoObject.BotonGuardar.PathImagen = cw_plantillaencuesta.BOTONGUARDARPATHIMAGEN;
            dtoObject.BotonGuardar.Texto = cw_plantillaencuesta.BOTONSALIRTEXTO;
            dtoObject.BotonSalir.Largo = cw_plantillaencuesta.BOTONSALIRLARGO;
            dtoObject.BotonSalir.Ancho = cw_plantillaencuesta.BOTONSALIRANCHO;
            dtoObject.BotonSalir.PathImagen = cw_plantillaencuesta.BOTONSALIRPATHIMAGEN;
            dtoObject.IdentificadorPropietarioAplicacion = cw_plantillaencuesta.IDPROPIETARIOAPP;
            dtoObject.UsuarioCreador.Id = cw_plantillaencuesta.USUARIOCREADOR;
            dtoObject.FechaCreacion = cw_plantillaencuesta.FECHACREACION;
            dtoObject.UsuarioModificador.Id = cw_plantillaencuesta.USUARIOMODIFICADOR;
            dtoObject.FechaModificacion = cw_plantillaencuesta.FECHAMODIFICACION;
            dtoObject.Titulo = cw_plantillaencuesta.TITULO;
            dtoObject.CuerpoHtml = cw_plantillaencuesta.DESCRIPCIONHTML;
            dtoObject.PiePaginaHtml = cw_plantillaencuesta.PIEPAGINAHTML;
            dtoObject.NombreCarpetaEstilo = cw_plantillaencuesta.NOMBRECARPETAPLANTILLA;
            return dtoObject;
        }

        public static DaoCW_PLANTILLAENCUESTA CastToDao(Plantilla dtoObject)
        {
            DaoCW_PLANTILLAENCUESTA daoObject = new DaoCW_PLANTILLAENCUESTA();
            daoObject.IDPLANTILLAENCUESTA = dtoObject.Id;
            daoObject.PATHBANNER = dtoObject.PathBanner;
            //daoObject.ALINEACIONLOGO = dtoObject.AlineacionLogo; TODO
            //daoObject.ALINEACIONENCUESTA = dtoObject.AlineacionEncuesta; TODO
            daoObject.RUTAARCHIVOCSS = dtoObject.RutaArchivoCss;
            if (dtoObject.BotonSiguiente != null)
            {
                daoObject.BOTONSIGUIENTETEXTO = dtoObject.BotonSiguiente.Texto;
                daoObject.BOTONSIGUIENTELARGO = dtoObject.BotonSiguiente.Largo;
                daoObject.BOTONSIGUIENTEANCHO = dtoObject.BotonSiguiente.Ancho;
                daoObject.BOTONSIGUIENTEPATHIMAGEN = dtoObject.BotonSiguiente.PathImagen;
            }
            if (dtoObject.BotonVolver != null)
            {
                daoObject.BOTONVOLVERTEXTO = dtoObject.BotonVolver.Texto;
                daoObject.BOTONVOLVERLARGO = dtoObject.BotonVolver.Largo;
                daoObject.BOTONVOLVERANCHO = dtoObject.BotonVolver.Ancho;
                daoObject.BOTONVOLVERPATHIMAGEN = dtoObject.BotonVolver.PathImagen;
            }
            if (dtoObject.BotonGuardar != null)
            {
                daoObject.BOTONGUARDARLARGO = dtoObject.BotonGuardar.Largo;
                daoObject.BOTONGUARDARANCHO = dtoObject.BotonGuardar.Ancho;
                daoObject.BOTONGUARDARPATHIMAGEN = dtoObject.BotonGuardar.PathImagen;
            }
            if (dtoObject.BotonSalir != null)
            {
                daoObject.BOTONSALIRTEXTO = dtoObject.BotonSalir.Texto;
                daoObject.BOTONSALIRLARGO = dtoObject.BotonSalir.Largo;
                daoObject.BOTONSALIRANCHO = dtoObject.BotonSalir.Ancho;
                daoObject.BOTONSALIRPATHIMAGEN = dtoObject.BotonSalir.PathImagen;
            }
            daoObject.IDPROPIETARIOAPP = dtoObject.IdentificadorPropietarioAplicacion;
            if (dtoObject.UsuarioCreador != null)
                daoObject.USUARIOCREADOR = dtoObject.UsuarioCreador.Id;
            if (dtoObject.UsuarioModificador != null)
                daoObject.USUARIOMODIFICADOR = dtoObject.UsuarioModificador.Id;
            daoObject.FECHACREACION = dtoObject.FechaCreacion;
            daoObject.FECHAMODIFICACION = dtoObject.FechaModificacion;
            daoObject.TITULO = dtoObject.Titulo;
            daoObject.DESCRIPCIONHTML = dtoObject.CuerpoHtml;
            daoObject.PIEPAGINAHTML = dtoObject.PiePaginaHtml;
            daoObject.NOMBRECARPETAPLANTILLA = dtoObject.NombreCarpetaEstilo;
            return daoObject;
        }

        public static List<Plantilla> CastList(IList<DaoCW_PLANTILLAENCUESTA> listOfDaocw_plantillaencuesta)
        {
            List<Plantilla> resultado = new List<Plantilla>();
            foreach (var cadacw_plantillaencuesta in listOfDaocw_plantillaencuesta)
            {
                resultado.Add(CastToDto(cadacw_plantillaencuesta));
            }
            return resultado;
        }


    }
}
