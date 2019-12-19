using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
   public class Compra
    {
        //Propiedades
        [Key]
        public int ID_Compra { get; set; }
        public DateTime Fecha { get; set; }
        public int Total_Pagar { get; set; }
        public int ID_persona { get; set; }

        public string Descripcion_peli { get; set; }
        public int ID_sala { get; set; }




        //Relaciones

        
    }
}
