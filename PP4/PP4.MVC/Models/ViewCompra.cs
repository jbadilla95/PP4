using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models
{
    public class ViewCompra
    {
        public int ID_Compra { get; set; }
        [Required]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        [Required]
        [Display(Name = "Cantidad de Entradas")]
        public int Total_Pagar { get; set; }
        [Required]
        [Display(Name = "Usuario Registrado")]
        public int ID_persona { get; set; }

        [Required]
        [Display(Name = "Nombre de la Pelicula")]
        public string Descripcion_peli { get; set; }

        [Required]
        [Display(Name = "Sala de Proyeccion")]
        public int ID_sala { get; set; }
    }
}