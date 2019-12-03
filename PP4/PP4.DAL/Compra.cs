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
        public int ID_tanda { get; set; }
        public int Total_Pagar { get; set; }
        public int ID_persona { get; set; }



        //Relaciones
        [XmlIgnore]
        public virtual ICollection<Persona> ID_Persona { get; set; }
        public virtual ICollection<Tanda> ID_Tanda { get; set; }

    }
}
