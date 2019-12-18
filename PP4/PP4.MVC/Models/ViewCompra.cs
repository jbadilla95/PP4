using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PP4.MVC.Models
{
    public class ViewCompra
    {
        public int ID_Compra { get; set; }
        public DateTime Fecha { get; set; }
        public int ID_tanda { get; set; }
        public int Total_Pagar { get; set; }
        public int ID_persona { get; set; }
    }
}