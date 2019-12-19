using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models
{
    public class ViewPelicula
    {
        
        public int ID_Pelicula { get; set; }
        [Required]
        [Display(Name = "Nombre de Pelicula")]
        public string Descripcion_Pelicula { get; set; }

        [Required]
        [Display(Name = "Duracion en horas")]
        public int Duracion { get; set; }

        [Required]
        [Display(Name = "Disposicion")]
        public int Estado { get; set; }

        [Required]
        [Display(Name = "Horario")]
        public int horario { get; set; }

        [Required]
        [Display(Name = "ID sala proyeccion")]
        public int ID_sala { get; set; }
    }
}