using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
    class Compra
    {
        //Propiedades
        [Key]
        public int Id_Compra { get; set; }
        //public List<Asientos> Id_Asientos { get; set; }



        //Relaciones
        [XmlIgnore]
        public virtual ICollection<Persona> ID_Persona { get; set; }
        public virtual ICollection<Horario> ID_horario { get; set; }

    }
}
