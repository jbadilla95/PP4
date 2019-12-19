using PP4.MVC.Models.ViewsModels;
using PP4.MVC.ServicioP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PP4.MVC.Controllers
{
    public class TandaController : Controller
    {
        // GET: Tanda
        public ActionResult Index()
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var listatanda = client.GetAllTandas();
            List<ViewTanda> lista = new List<ViewTanda>();

            foreach (Tanda item in listatanda)
                lista.Add(new ViewTanda()
                {
                    ID_pelicula=item.ID_pelicula,
                    ID_sala=item.ID_sala,
                    ID_tanda=item.ID_tanda
                });


            return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ViewTanda model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Tanda item = new Tanda();
            
            item.ID_pelicula = model.ID_pelicula;
            item.ID_sala = model.ID_sala;
            
            try
            {
                if (ModelState.IsValid)
                {
                    client.AgregaTanda(item);

                    return Redirect("~/Tanda/Index");
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
            var model = client.GetTandabyID(id);
            ViewTanda item = new ViewTanda();

           
            item.ID_pelicula = model.ID_pelicula;
            item.ID_sala = model.ID_sala;
            item.ID_tanda = model.ID_tanda;

            return View(item); //acá lo voy a devolver 

        }

        [HttpPost]
        public ActionResult Editar(ViewTanda model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Tanda item = new Tanda();
            
            item.ID_pelicula = model.ID_pelicula;
            item.ID_sala = model.ID_sala;
            item.ID_tanda = model.ID_tanda;
            try
            {
                if (ModelState.IsValid)
                {
                    client.ActualizarTanda(item);

                    return Redirect("~/Tanda/Index/");
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
            client.EliminarTanda(id);

            return Redirect("~/Tanda/Index/");
        }

    }
}