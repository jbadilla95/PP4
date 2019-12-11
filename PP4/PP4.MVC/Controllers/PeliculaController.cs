using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.BL;
using PP4.DAL;
using PP4.MVC.Models;
using PP4.MVC.Models.ViewsModels;
using PP4.MVC.ServicioPP4;

namespace PP4.MVC.Controllers
{
    public class PeliculaController : Controller
    {
        // GET: Pelicula

        public ActionResult Index()
        {
            List<Models.ViewPelicula> Lst = null;  //con foreach para sacar la lista de personas 
            using (DBCPP4 DB = new DBCPP4())
            {
                Lst = (from d in DB.Pelicula
                       select new ViewPelicula
                       {
                           ID_Pelicula = d.ID_Pelicula,
                           Descripcion_Pelicula = d.Descripcion_Pelicula,
                           Duracion = d.Duracion,
                           Estado = d.Estado

                       }).ToList();
            }
            List<SelectListItem> items = Lst.ConvertAll(d =>    // el SelectListItem me permite llenar un dropdownlist // por edio de una expresion landa
            {
                return new SelectListItem() //los atributos dentro de la lista
                {
                    Text = d.Descripcion_Pelicula.ToString(),
                    Value = d.ID_Pelicula.ToString(),
                    Selected = false


                };
            });

            ViewBag.items = items; //el viewbag sirve como un diccionario que le puedo enviar cualquier tipo de cosa, es muy dinamico entonces le envio la lista 
            return View();
            

        }
        public ActionResult About()
        {
            List<ViewPelicula> lst;
            using (DBCPP4 DB = new DBCPP4())
            {
                lst = (from d in DB.Pelicula
                       select new ViewPelicula
                       {
                           ID_Pelicula = d.ID_Pelicula,
                           Descripcion_Pelicula = d.Descripcion_Pelicula,
                           Duracion = d.Duracion,
                           Estado= d.Estado

                       }).ToList();

            }


            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ViewPelicula model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            

            try
            {
                if (ModelState.IsValid)
                {
                


                    return Redirect("~/Pelicula/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }
    }
}