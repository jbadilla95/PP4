using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Tanda
    {
        [Key]
        public int ID_tanda { get; set; }
        public int ID_sala { get; set; }
        public int ID_horario { get; set; }
        public int ID_pelicula { get; set; }

        //relaciones 

        [XmlIgnore]
        public virtual ICollection<Sala> ID_Sala { get; set; }
        public virtual ICollection<Horario> ID_Horario { get; set; }
        public virtual ICollection<Pelicula> ID_Pelicula { get; set; }

    }
}
