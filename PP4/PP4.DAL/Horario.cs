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
    class Horario
    {
        //Propiedades
        [Key]
        [Column(Order = 1)]
        public int Id_horario { get; set; }
        public DateTime Hora { get; set; }
        public DateTime Dia { get; set; }
        [Key]
        [Column(Order = 2)]
        public int ID_pelicula { get; set; }
        [Key]
        [Column(Order = 3)]
        public int ID_sala { get; set; }



        //Relaciones
        //relaciones
        [XmlIgnore]
        public virtual ICollection<Pelicula> Peliculas { get; set; }
    }
}
