using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dao.DaoDataModel;

namespace Pulse.Contactador.Dao.Implementaciones
{
    public class DaoEncuestaGateway
    {
        DaoCW_ENCUESTA _daoEncuesta;
        DaoCW_PAGINAENCUESTA _daoPagina;
        DaoCW_PREGUNTA _daoPregunta;
        DaoCW_ITEMPREGUNTA _daoItemPregunta;
        DaoCW_RESPUESTA _daoRespuesta;
        DaoCW_ITEMRESPUESTA _daoItemRespuesta;
        DaoCW_CONFSALIDACORREO _daoConfiguracionSalidaCorreo;
        DaoCW_MENSAJECORREO _daoMensajeCorreo;
        DaoCW_LISTACORREO _daoListaCorreo;
        DaoCW_PLANTILLAENCUESTA _daoPlantilla;
        DaoCW_ITEMCORREODESTINO _daoItemCorreoDestino;
        DaoCW_CAMPANIAS _daoCampania;
        DaoCW_EVALUADOR _daoEvaluador;
        DaoCW_EVALUADORENCUESTA _daoEvaluadorEncuesta;
        DaoCW_SEGUIMIENTOENCUESTA _daoSeguimientoEncuesta;
        public DaoEncuestaGateway()
        {
            _daoEncuesta = new DaoCW_ENCUESTA();
            _daoPagina = new DaoCW_PAGINAENCUESTA();
            _daoPregunta = new DaoCW_PREGUNTA();
            _daoItemPregunta = new DaoCW_ITEMPREGUNTA();
            _daoRespuesta = new DaoCW_RESPUESTA();
            _daoItemRespuesta = new DaoCW_ITEMRESPUESTA();
            _daoConfiguracionSalidaCorreo = new DaoCW_CONFSALIDACORREO();
            _daoMensajeCorreo = new DaoCW_MENSAJECORREO();
            _daoListaCorreo = new DaoCW_LISTACORREO();
            _daoPlantilla = new DaoCW_PLANTILLAENCUESTA();
            _daoItemCorreoDestino = new DaoCW_ITEMCORREODESTINO();
            _daoCampania = new DaoCW_CAMPANIAS();
            _daoEvaluador = new DaoCW_EVALUADOR();
            _daoEvaluadorEncuesta = new DaoCW_EVALUADORENCUESTA();
            _daoSeguimientoEncuesta = new DaoCW_SEGUIMIENTOENCUESTA();
        }

        public int CreateEncuesta(Encuesta encuesta)
        {
            return _daoEncuesta.Create(encuesta);
        }
        public Encuesta FindEncuesta(int id)
        {
            return _daoEncuesta.Find(id);
        }
        public int CreateCampania(Campania campania)
        {
            return _daoCampania.Create(campania);
        }
        public int CreatePagina(Pagina cadaPagina)
        {
            return _daoPagina.Create(cadaPagina);
        }
        public int CreatePregunta(Pregunta pregunta)
        {
            switch (pregunta.TipoPregunta)
            {
                case TiposPregunta.SeleccionUnica:
                    return _daoPregunta.Create(pregunta as PreguntaOpcionUnica);
                case TiposPregunta.SeleccionMultiple:
                    return _daoPregunta.Create(pregunta as PreguntaOpcionMultiple);
                case TiposPregunta.Matriz:
                    return _daoPregunta.Create(pregunta as PreguntaMatriz);
                default:
                    return _daoPregunta.Create(pregunta as Pregunta);
            }
        }

        public void CreateItemPregunta(ItemPregunta cadaItemPregunta)
        {
            _daoItemPregunta.Create(cadaItemPregunta);
        }
        public List<Pagina> FindPaginasByEncuestaId(int id)
        {
            return _daoPagina.FindByEncuestaId(id);
        }
        public List<Pregunta> FindPreguntasByPaginaId(int id)
        {
            return _daoPregunta.FindByPaginaId(id);
        }
        public List<ItemPregunta> FindItemsPreguntaByIdPregunta(int id)
        {
            return _daoItemPregunta.FindByPreguntaId(id);
        }
        public int CreateRespuesta(Respuesta respuestaEncuesta)
        {
            return _daoRespuesta.Create(respuestaEncuesta);
        }
        public int CreateItemRespuesta(ItemRespuesta cadaItemRespuesta)
        {
            return _daoItemRespuesta.Create(cadaItemRespuesta);
        }
        public List<Encuesta> FindAllEncuestas()
        {
            return _daoEncuesta.FindAll();
        }
        public List<ItemRespuesta> FindItemsRespuestaByIdPregunta(int id)
        {
            return _daoItemRespuesta.FindByPreguntaId(id);
        }
        public int? CountResultadoByEncuesta(int encuestaId)
        {
            return _daoRespuesta.CountRespuestasByEncuestaId(encuestaId);
        }
        public List<ConfiguracionSalidaCorreo> FindConfiguracionesSalidaCorreo()
        {
            return _daoConfiguracionSalidaCorreo.FindAll();
        }
        public int CreateMensajeCorreo(MensajeCorreoDestino mensajeCorreoDestino)
        {
            return _daoMensajeCorreo.Create(mensajeCorreoDestino);
        }
        public int CreateListaCorreo(ListaCorreoDestino listaCorreoDestino)
        {
            return _daoListaCorreo.Create(listaCorreoDestino);
        }
        public void UpdateListaCorreo(ListaCorreoDestino listaCorreoDestino)
        {
            _daoListaCorreo.Update(listaCorreoDestino);
        }
        public List<MensajeCorreoDestino> FindAllMensajesCorreoDestino()
        {
            return _daoMensajeCorreo.FindAll();
        }
        public List<ListaCorreoDestino> FindAllListaCorreo()
        {
            return _daoListaCorreo.FindAll();
        }
        public int CreatePlantilla(Plantilla plantilla)
        {
            return _daoPlantilla.Create(plantilla);
        }
        public List<Plantilla> FindAllPlantilla()
        {
            return _daoPlantilla.FindAll();
        }
        public Plantilla FindPlantillaById(int id)
        {
            return _daoPlantilla.Find(id);
        }
        public int CreateItemCorreoDestino(CorreoDestino correoDestino)
        {
            return _daoItemCorreoDestino.Create(correoDestino);
        }
        public IList<CorreoDestino> FindCorreosDestionByListaCorreoId(int listaCorreoId)
        {
            return _daoItemCorreoDestino.FindByListaCorreoId(listaCorreoId);
        }
        public CorreoDestino FindCorreoDestino(int id)
        {
            return _daoItemCorreoDestino.Find(id);
        }
        public ListaCorreoDestino FindListaCorreo(int id)
        {
            return _daoListaCorreo.Find(id);
        }
        public MensajeCorreoDestino FindMensajeCorreoDestino(int mensajeId)
        {
            return _daoMensajeCorreo.Find(mensajeId);
        }
        public void UpdateCorreoDestino(CorreoDestino cadaCorreoDestino)
        {
            _daoItemCorreoDestino.Update(cadaCorreoDestino);
        }
        public void UpdateRespuesta(Respuesta respuestaEncuesta)
        {
            _daoRespuesta.Update(respuestaEncuesta);
        }
        public Respuesta FindRespuestaPorItemCorreoIdCampaniaIdEncuestaId(int itemCorreoId, int campaniaId, int encuestaId)
        {
            return _daoRespuesta.FindByItemCorreoIdCampainaIdEncuestaId(itemCorreoId, campaniaId, encuestaId);
        }
        public List<Respuesta> FindRespuestasByEncuestaId(int encuestaId)
        {
            return _daoRespuesta.FindRespuestasByEncuestaId(encuestaId);
        }
        public Respuesta FindRespuesta(int idRespuesta)
        {
            return _daoRespuesta.Find(idRespuesta);
        }
        public List<ItemRespuesta> FindItemsPreguntaByIdRespuesta(int idRespuesta)
        {
            return _daoItemRespuesta.FindByRespuestaId(idRespuesta);
        }
        public ListaCorreoDestino FindListaCorreoDestinoByGrupoId(int cadaGrupo)
        {
            return _daoListaCorreo.FindByGrupoId(cadaGrupo);
        }
        public Evaluador FindEvaluador(int id)
        {
            return _daoEvaluador.Find(id);
        }
        public List<Evaluador> FindAllEvaluadores()
        {
            return _daoEvaluador.FindAll();
        }
        public List<Evaluador> FindEvaluadoresByGerencia(string gerencia)
        {
            return _daoEvaluador.FindDaoCW_EVALUADORbyGERENCIA(gerencia);
        }
        public List<Evaluador> FindEvaluadoresByArea(string area)
        {
            return _daoEvaluador.FindDaoCW_EVALUADORbyAREA(area);
        }
        public List<EvaluadorEncuesta> FindAllEvaluadoresEncuesta()
        {
            return _daoEvaluadorEncuesta.FindAll();
        }
        public List<EvaluadorEncuesta> FindAllEvaluadoresEncuestaPorEncuesta(int idEncuesta)
        {
            return _daoEvaluadorEncuesta.FindDaoCW_EVALUADORENCUESTAbyENCUESTA(idEncuesta);
        }
        public List<EvaluadorEncuesta> FindAllEvaluadoresencuestaPorEvaluador(int idEvaluador)
        {
            return _daoEvaluadorEncuesta.FindDaoCW_EVALUADORENCUESTAByEVALUADOR(idEvaluador);
        }
        public int CreateEvaluador(Evaluador evaluador)
        {
            return _daoEvaluador.Create(evaluador);
        }
        public int CreateEvaluadorEncuesta(EvaluadorEncuesta evaluadorEncuesta)
        {
            return _daoEvaluadorEncuesta.Create(evaluadorEncuesta);
        }
        public void UpdateEvaluadorEncuesta(EvaluadorEncuesta evaluadorEncuesta)
        {
            _daoEvaluadorEncuesta.Update(evaluadorEncuesta);
        }
        public List<EvaluadorEncuesta> FindEvaluadoresEncuestaPendientes()
        {
            return _daoEvaluadorEncuesta.FindDaoCW_EVALUADORENCUESTAPendientes();
        }
        public SeguimientoEncuesta FindSeguimientoEncuesta(SeguimientoEncuesta seguimientoEncuesta)
        {
            return _daoSeguimientoEncuesta.Find(seguimientoEncuesta);
        }
        public List<SeguimientoEncuesta> FindAllSeguimientoEncuesta()
        {
            return _daoSeguimientoEncuesta.FindAll();
        }
        public void CreateSeguimientoEncuesta(SeguimientoEncuesta seguimientoEncuesta)
        {
            _daoSeguimientoEncuesta.Create(seguimientoEncuesta);
        }
        public void UpdateSeguimientoEncuesta(SeguimientoEncuesta seguimientoEncuesta)
        {
            _daoSeguimientoEncuesta.Update(seguimientoEncuesta);
        }
        public void UpdateEvaluador(Evaluador evaluador)
        {
            _daoEvaluador.Update(evaluador);
        }
        public EvaluadorEncuesta FindEvaluadorEncuestaByGuid(string guid)
        {
            return _daoEvaluadorEncuesta.FindDaoCW_EVALUADORENCUESTAByGUID(guid);
        }
        public Respuesta FindRespuestasByEncuestaEvaluador(int encuestaId, int evaluadorId)
        {
            return _daoRespuesta.FindRespuestaByEncuestaEvaluador(encuestaId, evaluadorId);
        }

        public List<Respuesta> FindRespuestasByEncuestaEvaluadorModificada(int encuestaId, int evaluadorId)
        {
            return _daoRespuesta.FindRespuestasByEncuestaEvaluador(encuestaId, evaluadorId);
        }
    }
}
