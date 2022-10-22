using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Pulse.Contactador.Dto;

namespace Pulse.Contactador.BusinessLogic
{
    public class GestionadorPlantilla
    {
        Dao.Implementaciones.DaoEncuestaGateway _daoPlantilla;

        public GestionadorPlantilla()
        {
            _daoPlantilla = new Pulse.Contactador.Dao.Implementaciones.DaoEncuestaGateway();
        }

        public void AgregarNuevaPlantilla(Plantilla plantilla)
        {
            bool estaOk = ValidarPlantilla(plantilla);
            if (estaOk == true)
            {
                plantilla.Id = _daoPlantilla.CreatePlantilla(plantilla);
            }
        }

        public List<Plantilla> ObtenerPlantillas()
        {
            List<Plantilla> plantillas = new List<Plantilla>();
            return plantillas = _daoPlantilla.FindAllPlantilla();
        }

        private bool ValidarPlantilla(Plantilla plantilla)
        {
            List<Plantilla> plantillas = new List<Plantilla>();
            plantillas = _daoPlantilla.FindAllPlantilla();
            foreach (Plantilla eachPlantilla in plantillas)
            {
                if (eachPlantilla.Titulo == plantilla.Titulo)
                {
                    return false;
                }
            }
            return true;
        }

        public void EliminarPlantilla(int identificadorPlantilla)
        {
            new Dao.DaoDataModel.DaoCW_PLANTILLAENCUESTA().Delete(identificadorPlantilla);
        }
    }

}
