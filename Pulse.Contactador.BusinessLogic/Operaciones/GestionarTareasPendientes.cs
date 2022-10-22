using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dao.DaoDataModel;

namespace Pulse.Contactador.BusinessLogic.Operaciones
{
    public class GestionarTareasPendientes
    {
        DaoCW_CAMPANIAS _daoCampania;
        public GestionarTareasPendientes()
        {
            _daoCampania = new DaoCW_CAMPANIAS();
        }

        public List<Campania> ValidarTareasPendientes()
        {
            try
            {
                List<Campania> campanias = _daoCampania.FindAll();
                campanias = campanias.Where(t => t.FechaTerminoEsperado > DateTime.Now && t.FechaEnvioEsperado <= DateTime.Now).ToList();
                List<Campania> campaniasAEjecutar = new List<Campania>();
                foreach (var cadaCampania in campanias)
                {
                    List<EstadoCampania> estadosCampanias = new GestionarEstadoCampanias().ObtenerEstadoCampaniasPorCampania(cadaCampania);
                    if (cadaCampania.TipoPeriodoEjecucion == TiposPeriodosEjecucion.Todoslosdias)
                    {
                        if (!estadosCampanias.Any(t => t.FechaEjecutada.Day == DateTime.Now.Day && t.FechaEjecutada.Month == DateTime.Now.Month && t.FechaEjecutada.Year == DateTime.Now.Year))
                            campaniasAEjecutar.Add(cadaCampania);
                    }

                    if (cadaCampania.TipoPeriodoEjecucion == TiposPeriodosEjecucion.SoloUnaVez)
                    {
                        if (!estadosCampanias.Any())
                            if (DateTime.Now >= cadaCampania.FechaEnvioEsperado && DateTime.Now <= cadaCampania.FechaTerminoEsperado)
                                campaniasAEjecutar.Add(cadaCampania);
                    }
                    if (cadaCampania.TipoPeriodoEjecucion == TiposPeriodosEjecucion.UnaVezPorSemana)
                    {
                        if (!estadosCampanias.Any())
                            campaniasAEjecutar.Add(cadaCampania);
                        else
                        {
                            if (DateTime.Now.Day == estadosCampanias.Max(t => t.FechaEjecutada).AddDays(7).Day)
                                campaniasAEjecutar.Add(cadaCampania);
                        }
                    }
                    if (cadaCampania.TipoPeriodoEjecucion == TiposPeriodosEjecucion.UnaVezPorMes)
                    {
                        if (!estadosCampanias.Any())
                            campaniasAEjecutar.Add(cadaCampania);
                        else
                        {
                            if (DateTime.Now.Day == estadosCampanias.First().FechaEjecutada.Day)
                                campaniasAEjecutar.Add(cadaCampania);
                        }
                    }
                }
                return campaniasAEjecutar;

            }
            catch (Exception ex)
            {
                throw new Pulse.Utils.Exceptions.ActionableException("Error en la busqueda de tareas pendientes" + ex.Message, ex);
            }
        }
    }
}

