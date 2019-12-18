using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models.ViewsModels
{
    public class ViewTanda
    {
        public int ID_tanda { get; set; }
        public int ID_sala { get; set; }
        public int ID_horario { get; set; }
        public int ID_pelicula { get; set; }
    }
}