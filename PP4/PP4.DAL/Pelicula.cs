using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
   public class Pelicula
    {
        //Propiedades
        [Key]
        public int ID_Pelicula { get; set; }
        public string Descripcion_Pelicula { get; set; }
        public int Duracion { get; set; }
        public int Estado { get; set; }



        
        
    }
}
