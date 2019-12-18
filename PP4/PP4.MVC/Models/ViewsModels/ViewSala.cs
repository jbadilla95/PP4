using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models
{
    public class ViewSala
    {
        public int ID_Sala { get; set; }

        [Required]
        [Display(Name = "Descripcion de la sala")]
        public string Desc_sala { get; set; }
    }
}