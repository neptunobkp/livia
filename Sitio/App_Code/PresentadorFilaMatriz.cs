using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Pulse.Contactador.Dto;

public class PresentadorFilaMatriz
{
    public int Id { get; set; }
    public int IdentificadorFila { get; set; }
    public String NombrePregunta { get; set; }
    public List<ItemPregunta> ItemsPreguntas { get; set; }
}