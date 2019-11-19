using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
    class Sala
    {
        //Propiedades
        [Key]
        public int Id_Sala { get; set; }
        public int capacidad { get; set; }
        public Boolean Estado { get; set; }
        

        //relaciones
    }
}
