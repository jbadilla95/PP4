using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models
{
    public class ViewSala
    {
        public int ID_SCantidad { get; set; }
        public int ID_Asiento { get; set; }

        [Required]
        [Display(Name = "Capacidad de Sala")]
        public int Cantidad_total { get; set; }
        public int Cantidad_disponible { get; set; }

        

       



    }
}