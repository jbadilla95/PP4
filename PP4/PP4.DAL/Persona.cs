using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Persona
    {
        //Propiedades
        [Key]
        public int ID_Persona { get; set; }
        public string Nombre { get; set; }
        public int Cedula { get; set; }
        public string correo  { get; set; }
        public string contraseña { get; set; }
        public Boolean tipo_perfil { get; set; }


        //Relaciones
    }
}
