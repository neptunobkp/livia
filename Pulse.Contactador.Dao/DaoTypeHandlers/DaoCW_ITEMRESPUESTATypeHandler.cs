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
    public class DaoCW_ITEMRESPUESTATypeHandler
    {
        public static ItemRespuesta CastToDto(DaoCW_ITEMRESPUESTA cw_itemrespuesta)
        {
            ItemRespuesta dtoObject = new ItemRespuesta() { PregunaRespondida = new Pregunta() };
            dtoObject.Id = cw_itemrespuesta.IDITEMRESPUESTA;
            dtoObject.PregunaRespondida.Id = cw_itemrespuesta.IDPREGUNTA;
            dtoObject.GlosaRespuesta = cw_itemrespuesta.GLOSARESPUESTA;
            dtoObject.ValorRespuesta = cw_itemrespuesta.VALORRESPUESTA;
            dtoObject.NumeroOrden = cw_itemrespuesta.NUMEROORDEN;
            dtoObject.ValorTipoColumna = cw_itemrespuesta.VALORTIPOCOLUMNA;
            dtoObject.GlosaTipoColumna = cw_itemrespuesta.GLOSATIPOCOLUMNA;
            dtoObject.TipoPreguntaRespondida = (TiposPregunta)cw_itemrespuesta.TIPOPREGUNTARESPONDIDA;
            dtoObject.OtraRespuesta = cw_itemrespuesta.OTRARESPUESTA;
            dtoObject.IdentificadorPropietario = cw_itemrespuesta.IDRESPUESTA;
            return dtoObject;
        }

        public static DaoCW_ITEMRESPUESTA CastToDao(ItemRespuesta dtoObject)
        {
            DaoCW_ITEMRESPUESTA daoObject = new DaoCW_ITEMRESPUESTA();
            daoObject.IDITEMRESPUESTA = dtoObject.Id;
            daoObject.IDPREGUNTA = dtoObject.PregunaRespondida.Id;
            daoObject.GLOSARESPUESTA = dtoObject.GlosaRespuesta;
            daoObject.VALORRESPUESTA = dtoObject.ValorRespuesta;
            daoObject.NUMEROORDEN = dtoObject.NumeroOrden;
            daoObject.VALORTIPOCOLUMNA = dtoObject.ValorTipoColumna;
            daoObject.GLOSATIPOCOLUMNA = dtoObject.GlosaTipoColumna;
            daoObject.TIPOPREGUNTARESPONDIDA = (int)dtoObject.TipoPreguntaRespondida;
            daoObject.OTRARESPUESTA = dtoObject.OtraRespuesta;
            daoObject.IDRESPUESTA = dtoObject.IdentificadorPropietario;
            return daoObject;
        }

        public static List<ItemRespuesta> CastList(IList<DaoCW_ITEMRESPUESTA> listOfDaocw_itemrespuesta)
        {
            List<ItemRespuesta> resultado = new List<ItemRespuesta>();
            foreach (var cadacw_itemrespuesta in listOfDaocw_itemrespuesta)
            {
                resultado.Add(CastToDto(cadacw_itemrespuesta));
            }
            return resultado;
        }


    }
}
