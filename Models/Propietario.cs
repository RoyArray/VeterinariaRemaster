using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaRemaster.Models
{
    public class Propietario
    {
        public int ProId { get; set; }                  
        public string NumeroIdentificacion { get; set; } 
        public string PrimerNombre { get; set; }        
        public string SegundoNombre { get; set; }       
        public string PrimerApellido { get; set; }      
        public string SegundoApellido { get; set; }     
        public string TelefonoCelular { get; set; }     
        public string CorreoElectronico { get; set; }   
        public string AdicionadoPor { get; set; }
        public DateTime FechaAdicion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}