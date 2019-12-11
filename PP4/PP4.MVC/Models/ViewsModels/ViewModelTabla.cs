using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models.ViewsModels
{
    public class ViewModelTabla
    {
        public int ID_Persona { get; set; }
        [Required]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }
        [Required]
        [Display(Name = "Cedula")]
        public int Cedula { get; set; }
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string correo { get; set; }
        [Required]
        [DataType(DataType.Password)] //en este anotation cuando vaya a editar el pass no aparecerá ya que este es quien lo cubre 
        [Display(Name = "Contraseña")]
        public string contraseña { get; set; }
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "tipo de perfil")]
        public Boolean tipo_perfil { get; set; }
    }
}