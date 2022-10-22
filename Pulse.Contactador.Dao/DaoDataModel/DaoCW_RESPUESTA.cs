using System;
using System.Collections.Generic;
using System.Text;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System.Linq;
using System.Diagnostics;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dao.DaoTypeHandlers;
using Pulse.Utils.Exceptions;
using System.Collections;

namespace Pulse.Contactador.Dao.DaoDataModel
{
    public class DaoCW_RESPUESTA
    {
        SqlMapper _mapper;
        #region Instacia SqlMapper
        SqlMapper Instance()
        {
            return ((_mapper == null) ? _mapper = MapperFactory.CrearMapper() : _mapper);
        }
        #endregion

        public int IDRESPUESTA { get; set; }
        public int IDENCUESTA { get; set; }
        public int ENCUESTADORUT { get; set; }
        public String ENCUESTADONOMBRE { get; set; }
        public String ENCUESTADOCORREO { get; set; }
        public DateTime INICIORESPUESTAENCUESTA { get; set; }
        public DateTime? TERMINORESPUESTAENCUESTA { get; set; }
        public String DIRECCIONIP { get; set; }
        public int COMPLETADO { get; set; }
        public int MINUTOSTRANSCURRIDOS { get; set; }
        public String NAVEGADOR { get; set; }
        public String URLENCUESTAENVIADA { get; set; }
        public String ANOTACION { get; set; }
        public int IDITEMCORREODESTINO { get; set; }
        public int TIPOESTADORESPUESTA { get; set; }
        public int IDCAMPANIA { get; set; }
        public String NOMBREUSUARIOCLIENTE { get; set; }


        #region Metodos DaoCW_RESPUESTA
        public int Create(Respuesta daoObject)
        {
            try
            {
                DaoCW_RESPUESTA daocw_respuesta = DaoCW_RESPUESTATypeHandler.CastToDao(daoObject);
                object resultado = Instance().Insert("DaoCW_RESPUESTA.CreateDaoCW_RESPUESTA", daocw_respuesta);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de crear daocw_respuesta", ex);
            }

        }

        public Respuesta Find(int id)
        {
            try
            {
                DaoCW_RESPUESTA resultado = Instance().QueryForObject<DaoCW_RESPUESTA>("DaoCW_RESPUESTA.FindDaoCW_RESPUESTA", id);
                Respuesta resultadoCasteado = DaoCW_RESPUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_RESPUESTA", ex);
            }
        }


        public Respuesta FindByItemCorreoId(int itemCorreoId)
        {
            try
            {
                DaoCW_RESPUESTA resultado = Instance().QueryForObject<DaoCW_RESPUESTA>("DaoCW_RESPUESTA.FindByItemCorreoId", itemCorreoId);
                if (resultado == null) return null;
                Respuesta resultadoCasteado = DaoCW_RESPUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_RESPUESTA", ex);
            }
        }

        public List<Respuesta> FindAll()
        {
            try
            {
                return DaoCW_RESPUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_RESPUESTA>("DaoCW_RESPUESTA.FindAllDaoCW_RESPUESTA", null));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_RESPUESTA", ex);
            }
        }


        public List<Respuesta> FindRespuestasByEncuestaId(int encuestaId)
        {
            try
            {
                return DaoCW_RESPUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_RESPUESTA>("DaoCW_RESPUESTA.FindDaoCW_RESPUESTAByIDENCUESTA", encuestaId));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_RESPUESTA", ex);
            }
        }

        public void Update(Respuesta daoObject)
        {
            try
            {
                DaoCW_RESPUESTA daocw_respuesta = DaoCW_RESPUESTATypeHandler.CastToDao(daoObject);
                Instance().Update("DaoCW_RESPUESTA.UpdateDaoCW_RESPUESTA", daocw_respuesta);

            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de actualizar datos de daocw_respuesta", ex);
            }

        }

        public void Delete(int idStatement)
        {
            try
            {
                Instance().Delete("DaoCW_RESPUESTA.DeleteDaoCW_RESPUESTA", idStatement);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al tratar de eliminar daocw_respuesta", ex);

            }

        }

        public int CountRespuestasByEncuestaId(int encuestaId)
        {
            try
            {
                object resultado = Instance().QueryForObject("DaoCW_RESPUESTA.CountRespuestasByEncuestaId", encuestaId);
                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                throw new DaoException("Ha ocurrido un problema al obtener la cantidad de encuestas por encuesta id", ex);
            }
        }

        #endregion


        public Respuesta FindByItemCorreoIdCampainaIdEncuestaId(int itemCorreoId, int campaniaId, int encuestaId)
        {
            try
            {
                Hashtable parameters = new Hashtable();
                parameters.Add("itemcorreoid", itemCorreoId);
                parameters.Add("campaniaid", campaniaId);
                parameters.Add("encuestaid", encuestaId);
                DaoCW_RESPUESTA resultado = Instance().QueryForObject<DaoCW_RESPUESTA>("DaoCW_RESPUESTA.FindByItemCorreoIdCampaniaId", parameters);
                if (resultado == null) return null;
                Respuesta resultadoCasteado = DaoCW_RESPUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_RESPUESTA", ex);
            }
        }

        public Respuesta FindRespuestaByEncuestaEvaluador(int encuestaId, int evaluadorId)
        {
            try
            {
                Hashtable parameters = new Hashtable();
                parameters.Add("evaluadorid", evaluadorId);
                parameters.Add("encuestaid", encuestaId);
                DaoCW_RESPUESTA resultado = Instance().QueryForObject<DaoCW_RESPUESTA>("DaoCW_RESPUESTA.FindRespuestaByEncuestaEvaluador", parameters);
                if (resultado == null) return null;
                Respuesta resultadoCasteado = DaoCW_RESPUESTATypeHandler.CastToDto(resultado);
                return resultadoCasteado;
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_RESPUESTA", ex);
            }
        }

        public List<Respuesta> FindRespuestasByEncuestaEvaluador(int encuestaId, int evaluadorId)
        {
            try
            {
                Hashtable parameters = new Hashtable();
                parameters.Add("evaluadorid", evaluadorId);
                parameters.Add("encuestaid", encuestaId);
                return DaoCW_RESPUESTATypeHandler.CastList(Instance().QueryForList<DaoCW_RESPUESTA>("DaoCW_RESPUESTA.FindRespuestasByEncuestaEvaluador", parameters));
            }
            catch (Exception ex)
            {
                throw new DaoException("se ha producido un error al buscar DaoCW_RESPUESTA", ex);
            }
        }

        
    }
}
