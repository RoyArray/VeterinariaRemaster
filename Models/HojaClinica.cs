using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaRemaster.Models
{
    public class HojaClinica
    {
        public int HojId { get; set; }              
        public DateTime FechaAtencion { get; set; } 
        public string Sintomas { get; set; }        
        public string Diagnostico { get; set; }     
        public string Tratamiento { get; set; }     
        public int MasId { get; set; }              
        public string AdicionadoPor { get; set; }
        public DateTime FechaAdicion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}