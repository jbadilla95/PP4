using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
   public class Horario
    {
        //Propiedades
        [Key]
        public int ID_Horario { get; set; }
        public int Hora_Inicial { get; set; }
        public int Hora_Final { get; set; }




       
        
    }
}
