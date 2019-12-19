using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.MVC.Models;
using PP4.MVC;
using PP4.MVC.ServicioP;

namespace PP4.MVC.Controllers
{
    public class SalasController : Controller
    {
        // GET: Salas
        public ActionResult Index()
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var listasalas = client.GetAllSalas();
            List<ViewSala> lista = new List<ViewSala>();

            foreach (Sala_Cantidad item in listasalas)
                lista.Add(new ViewSala()
                {
                    ID_SCantidad = item.ID_SCantidad,
                    ID_Asiento=item.ID_Asiento,
                    Cantidad_disponible=item.Cantidad_disponible,
                    Cantidad_total=item.Cantidad_total,
                   

                }) ;

            return View(lista);
            
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ViewSala model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Sala_Cantidad item = new Sala_Cantidad();
            item.ID_SCantidad = model.ID_SCantidad;
            item.ID_Asiento = 1;
            item.Cantidad_disponible = model.Cantidad_disponible;
            item.Cantidad_total = model.Cantidad_total;
          
            try
            {
                if (ModelState.IsValid)
                {
                    client.AgregaSala(item);

                    return Redirect("~/Salas/Index");
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
            var model = client.GetSalabyid(id);
            ViewSala item = new ViewSala();

            item.ID_SCantidad = model.ID_SCantidad;
            item.ID_Asiento = model.ID_Asiento;
            item.Cantidad_disponible = model.Cantidad_disponible;
            item.Cantidad_total = model.Cantidad_total;
          


            return View(model); //acá lo voy a devolver , en este caso lo estoy enviando al ootro metodo de HTTPPOST

        }

        [HttpPost]
        public ActionResult Editar(ViewSala model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Sala_Cantidad sala = new Sala_Cantidad();
           
            try
            {
                if (ModelState.IsValid)
                {
                    client.ActualizarSala(sala);

                    return Redirect("~/Salas/Index/");
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
            client.EliminarSala(id);

            return Redirect("~/Salas/Index/");
        }

        
    }
}