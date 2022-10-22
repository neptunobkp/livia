using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;
using Pulse.Contactador.Dao.DaoDataModel;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorCarpetaEncuesta
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoEncuesta;

        public GestionadorCarpetaEncuesta()
        {
            _daoEncuesta = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }
        public CarpetaEncuesta ObtenerCarpetaEncuesta(int carpetaEncuestaId)
        {
            CarpetaEncuesta carpetaEncuestaResultado = new CarpetaEncuesta();
            try
            {
                var carpetaEncuesta = new Dao.DaoDataModel.DaoCarpetaEncuesta().Find(carpetaEncuestaId);
                if (carpetaEncuesta != null && carpetaEncuesta.Count == 1)
                {
                    carpetaEncuestaResultado = carpetaEncuesta.First();
                    carpetaEncuestaResultado.ItemsCarpetaEncuesta = new DaoItemCarpetaEncuesta().FindByCarpetaId(carpetaEncuestaId);
                    carpetaEncuestaResultado.Relaciones = new DaoRelacionCarpetaEncuesta().FindRelacionesCarpetaEncuesta(carpetaEncuestaId);
                }
                return carpetaEncuestaResultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<CarpetaEncuesta> ObtenerCarpetasEncuestas()
        {
            return new Dao.DaoDataModel.DaoCarpetaEncuesta().FindAll();
        }
    }
}
