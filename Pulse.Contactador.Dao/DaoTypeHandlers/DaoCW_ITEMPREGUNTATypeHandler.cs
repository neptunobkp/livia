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
    public class DaoCW_ITEMPREGUNTATypeHandler
    {
        public static ItemPregunta CastToDto(DaoCW_ITEMPREGUNTA cw_itempregunta)
        {
            ItemPregunta dtoObject = new ItemPregunta();
            dtoObject.Id = cw_itempregunta.IDITEMPREGUNTA;
            dtoObject.IdentificadorPropietario = cw_itempregunta.IDPREGUNTA;
            dtoObject.TipoItemPregunta = (TiposItemPregunta)cw_itempregunta.TIPOITEMPREGUNTA;
            dtoObject.OrdenCorrelativo = cw_itempregunta.ORDENCORRELATIVO;
            dtoObject.ValorInterno = cw_itempregunta.VALORINTERNO;
            dtoObject.GlosaPregunta = cw_itempregunta.GLOSA;
            return dtoObject;
        }

        public static DaoCW_ITEMPREGUNTA CastToDao(ItemPregunta dtoObject)
        {
            DaoCW_ITEMPREGUNTA daoObject = new DaoCW_ITEMPREGUNTA();
            daoObject.IDITEMPREGUNTA = dtoObject.Id;
            daoObject.IDPREGUNTA = dtoObject.IdentificadorPropietario;
            daoObject.TIPOITEMPREGUNTA = (int)dtoObject.TipoItemPregunta;
            daoObject.ORDENCORRELATIVO = dtoObject.OrdenCorrelativo;
            daoObject.VALORINTERNO = dtoObject.ValorInterno;
            daoObject.GLOSA = dtoObject.GlosaPregunta;
            return daoObject;
        }

        public static List<ItemPregunta> CastList(IList<DaoCW_ITEMPREGUNTA> listOfDaocw_itempregunta)
        {
            List<ItemPregunta> resultado = new List<ItemPregunta>();
            foreach (var cadacw_itempregunta in listOfDaocw_itempregunta)
            {
                resultado.Add(CastToDto(cadacw_itempregunta));
            }
            return resultado;
        }
    }
}
