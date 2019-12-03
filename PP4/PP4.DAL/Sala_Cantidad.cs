using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Sala_Cantidad
    {
        //Propiedades
        [Key]
        public int ID_SCantidad { get; set; }
        public int ID_Sala { get; set; }

        public int ID_Asiento { get; set; }
        public int Cantidad_total { get; set; }
        public int Cantidad_disponible { get; set; }

       

        [XmlIgnore]
        public virtual ICollection<Sala> ID_sala { get; set; }
        public virtual ICollection<Asientos> ID_asiento { get; set; }

    }
}
