using PP4.MVC.Models;
using PP4.MVC.Models.ViewsModels;
using PP4.MVC.ServicioPP4;
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



        public ActionResult Nuevo()
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

        [HttpPost]
        public ActionResult Nuevo(ViewCompra model)
        {

            ServicioSoapClient client = new ServicioSoapClient();

            
            model.Total_Pagar= model.Total_Pagar * 3800;
            Compra item = new Compra();
            item.Fecha = model.Fecha;
            item.ID_tanda = 2;
            item.ID_persona = model.ID_persona;
            item.Total_Pagar = model.Total_Pagar;



            try
            {
                if (ModelState.IsValid)
                {
                    client.AgregaCompra(item);

                    return Redirect("~/Tanda/Index");
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