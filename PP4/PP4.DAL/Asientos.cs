using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP4.DAL
{
    class Asientos
    {
        //Propiedades
        [Key]
        
        public int Id_asientos { get; set; }
        public int numero { get; set; }
        public Boolean estado { get; set; }

        //relaciones
        public virtual Sala Id_Sala { get; set; }
    }
}
