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
        [Display(Name = "Descripcion")]

        public string Descripcion_Pelicula { get; set; }
        [Required]
        [Display(Name = "Duracion")]

        public int Duracion { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public int Estado { get; set; }
    }
}