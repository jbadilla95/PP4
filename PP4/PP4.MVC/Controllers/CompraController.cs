using PP4.MVC.Models;
using PP4.MVC.Models.ViewsModels;
using PP4.MVC.ServicioP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.MVC.Controllers
{
    public class CompraController : Controller
    {
        // GET: Compra
        public ActionResult Index()
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var listapersonas = client.GetAllPersonas();
            List<ViewPersona> lista = new List<ViewPersona>();

            foreach (Persona item in listapersonas)
                lista.Add(new ViewPersona()
                {
                    ID_Persona = item.ID_Persona,
                    Nombre = item.Nombre,
                    Cedula = item.Cedula,
                    correo = item.correo,
                    contraseña = item.contraseña,
                    tipo_perfil = item.tipo_perfil
                });
            List<SelectListItem> items = lista.ConvertAll(d =>
            {
                return new SelectListItem()
                {
                    Text = d.Nombre.ToString(),
                    Value = d.ID_Persona.ToString(),
                    Selected = false
                };

            });

            ViewBag.items = items;

            return View();
        }



        public ActionResult Nuevo(int id)
        {

            ServicioSoapClient client = new ServicioSoapClient();
            var item = client.GetPeliculabyid(id);
            ViewCompra model = new ViewCompra();
            model.ID_sala = item.ID_sala;
            model.Descripcion_peli = item.Descripcion_Pelicula;




            return View(model); //acá lo voy a devolver 

        }

        [HttpPost]
        public ActionResult Nuevo(ViewCompra item)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Compra model = new Compra();
            model.Descripcion_peli = item.Descripcion_peli;
            model.Fecha = item.Fecha;
            model.ID_persona = item.ID_persona;
            model.ID_sala = item.ID_sala;
            model.Total_Pagar = item.Total_Pagar * 3800;
            try
            {
                if (ModelState.IsValid)
                {
                    client.AgregaCompra(model);

                    return Redirect("~/Salas/Index/");
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