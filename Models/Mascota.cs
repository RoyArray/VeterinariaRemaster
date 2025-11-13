using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VeterinariaRemaster.Models
{
    public class Mascota
    {
        public int MasId { get; set; }          
        public string Nombre { get; set; }      
        public DateTime FechaNacimiento { get; set; } 
        public string Sexo { get; set; }        
        public decimal Peso { get; set; }       
        public string Alergias { get; set; }    
        public int ProId { get; set; }          
        public string AdicionadoPor { get; set; }
        public DateTime FechaAdicion { get; set; }
        public string ModificadoPor { get; set; }
        public DateTime? FechaModificacion { get; set; }
    }
}