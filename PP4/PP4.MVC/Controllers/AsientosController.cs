using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using PP4.MVC.Models;
using PP4.MVC.Models.ViewsModels;
using PP4.MVC.ServicioPP4;

namespace PP4.MVC.Controllers
{
    public class AsientosController : Controller
    {
        // GET: Asientos
        public ActionResult Index()
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var catalogoasientos = client.GetAllAsientos();
            List<ViewAsiento> lista = new List<ViewAsiento>();

            foreach (Asientos item in catalogoasientos)
                lista.Add(new ViewAsiento()
                {
                    ID_Asientos = item.ID_Asientos,
                    Desc_Asientos = item.Desc_Asientos,
                    Precio=item.Precio
                });


            return View(lista);
            
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ViewAsiento model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Asientos asiento = new Asientos();
            asiento.ID_Asientos = model.ID_Asientos;
            asiento.Desc_Asientos = model.Desc_Asientos;
            asiento.Precio = model.Precio;
            try
            {
                if (ModelState.IsValid)
                {
                    client.AgregaAsiento(asiento);

                    return Redirect("~/Asientos/Index");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public ActionResult Editar(int id)
        {

            ServicioSoapClient client = new ServicioSoapClient();
            var item = client.GetAsientosbyid(id);
            ViewAsiento model = new ViewAsiento();

            model.ID_Asientos = item.ID_Asientos;
            model.Desc_Asientos = item.Desc_Asientos;
            model.Precio = item.Precio;
         

            return View(model); //acá lo voy a devolver 

        }

        [HttpPost]
        public ActionResult Editar(ViewAsiento item)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Asientos model = new Asientos();
            model.ID_Asientos = item.ID_Asientos;
            model.Desc_Asientos = item.Desc_Asientos;
            model.Precio = item.Precio;
            try
            {
                if (ModelState.IsValid)
                {
                    client.ActualizarAsiento(model);

                    return Redirect("~/Asientos/Index/");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }

        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {

            ServicioSoapClient client = new ServicioSoapClient();
            client.EliminarAsientos(id);

            return Redirect("~/Asientos/Index/");
        }

    }
}