using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models.ViewsModels
{
    public class ViewAsiento
    {
        public int ID_Asientos { get; set; }

        [Required]
        [Display(Name = "Descripcion Asientos")]
        public string Desc_Asientos { get; set; } //descripcion de Asientos 

        [Required]
        [Display(Name = " Precio del Asiento")]
        public int Precio { get; set; }
    }
}