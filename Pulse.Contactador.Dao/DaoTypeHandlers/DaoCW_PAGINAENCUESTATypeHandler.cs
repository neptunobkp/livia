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
    public class DaoCW_PAGINAENCUESTATypeHandler
    {
        public static Pagina CastToDto(DaoCW_PAGINAENCUESTA cw_paginaencuesta)
        {
            Pagina dtoObject = new Pagina();
            dtoObject.Id = cw_paginaencuesta.IDPAGINAENCUESTA;
            dtoObject.Titulo = cw_paginaencuesta.TITULO;
            dtoObject.IntroduccionPagina = cw_paginaencuesta.INTRODUCCIONPAGINA;
            dtoObject.MensajePiePagina = cw_paginaencuesta.MENSAJEPIEPAGINA;
            dtoObject.DescripcionPiePagina = cw_paginaencuesta.DESCRIPCIONPIEPAGINA;
            dtoObject.NumeroPagina = cw_paginaencuesta.NUMEROPAGINA;
            dtoObject.IdentificadorPropietario = cw_paginaencuesta.IDENCUESTA;
            return dtoObject;
        }

        public static DaoCW_PAGINAENCUESTA CastToDao(Pagina dtoObject)
        {
            DaoCW_PAGINAENCUESTA daoObject = new DaoCW_PAGINAENCUESTA();
            daoObject.IDPAGINAENCUESTA = dtoObject.Id;
            daoObject.TITULO = dtoObject.Titulo;
            daoObject.INTRODUCCIONPAGINA = dtoObject.IntroduccionPagina;
            daoObject.MENSAJEPIEPAGINA = dtoObject.MensajePiePagina;
            daoObject.DESCRIPCIONPIEPAGINA = dtoObject.DescripcionPiePagina;
            daoObject.NUMEROPAGINA = dtoObject.NumeroPagina;
            daoObject.IDENCUESTA = dtoObject.IdentificadorPropietario;
            return daoObject;
        }

        public static List<Pagina> CastList(IList<DaoCW_PAGINAENCUESTA> listOfDaocw_paginaencuesta)
        {
            List<Pagina> resultado = new List<Pagina>();
            foreach (var cadacw_paginaencuesta in listOfDaocw_paginaencuesta)
            {
                resultado.Add(CastToDto(cadacw_paginaencuesta));
            }
            return resultado;
        }


    }
}
