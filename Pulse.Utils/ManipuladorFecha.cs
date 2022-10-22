using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pulse.Utils
{
    public class ManipuladorFecha
    {
        public int Anio { get; set; }
        public int Mes { get; set; }
        public int Dia { get; set; }


        public static int CalcularEdad(DateTime fechaNacimiento)
        {
            return new DateTime(DateTime.Now.Subtract(fechaNacimiento).Ticks).Year - 1;
        }

        public DateTime TextoAFecha(string texto)
        {
            List<string> campos = new List<string>();
            if (texto.Contains('-')) campos = texto.Split('-').ToList();
            else if (texto.Contains('/')) campos = texto.Split('/').ToList();
            else throw new InvalidCastException("No se puede convertir el texto ingresado a una fecha, ya que no tiene un formato compatible");
            if (campos.Count != 3) throw new InvalidCastException("El valor ingresado no es una fecha válida");
            Convertir(campos.Last(), campos[1], campos.First());
            return new DateTime(Anio, Mes, Dia);
        }

        private void Convertir(string anio, string mes, string dia)
        {
            this.Anio = Convert.ToInt32(anio);
            this.Mes = Convert.ToInt32(mes);
            this.Dia = Convert.ToInt32(dia);
        }

        public DateTime? TextoAFechaNulable(string fechaResult)
        {
            try
            {
                if (string.IsNullOrEmpty(fechaResult)) return null;
                return TextoAFecha(fechaResult);
            }
            catch (Exception) //TODO implmenetar log en caso de que el metodo este malo.
            {
                return null;
            }
        }

        public DateTime? TextoAFechaNulable(string anio, string mes, string dia)
        {
            Convertir(anio, mes, dia);
            return new DateTime(this.Anio, this.Mes, this.Dia);
        }
    }
}
