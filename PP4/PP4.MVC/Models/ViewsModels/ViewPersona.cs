using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models
{
    public class ViewPersona
    {
        public int ID_Persona { get; set; }
        public string Nombre { get; set; }
        public int Cedula { get; set; }
        public string correo { get; set; }
        public string contraseña { get; set; }
        public Boolean tipo_perfil { get; set; }
    }
}