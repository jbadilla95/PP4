using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
    class Pelicula
    {
        //Propiedades
        [Key]
        public int Id_Pelicula { get; set; }
        public string Titulo { get; set; }
        public int Duracion { get; set; }
        public int Precio { get; set; }



        //Relaciones
        [XmlIgnore]
        public virtual ICollection<Sala> Salas { get; set; }
    }
}
