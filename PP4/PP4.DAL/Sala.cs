using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
   public class Sala
    {
        //Propiedades
        [Key]
        public int ID_Sala { get; set; }
        public string Desc_sala { get; set; }
        
        

        //relaciones
    }
}
