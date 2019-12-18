using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace PP4.DAL
{
    public class Asientos
    {
        //Propiedades
        [Key]
        
        public int ID_Asientos { get; set; }
        public string Desc_Asientos { get; set; } //descripcion de Asientos 
        public int Precio { get; set; }


        

    }
}
