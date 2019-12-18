using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.MVC.Models;
using PP4.MVC;
using PP4.MVC.ServicioPP4;

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

            foreach (Sala item in listasalas)
                lista.Add(new ViewSala()
                {

                ID_Sala = item.ID_Sala,    
                Desc_sala = item.Desc_sala
                });


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

            Sala peli = new Sala();
            peli.Desc_sala = model.Desc_sala;
            try
            {
                if (ModelState.IsValid)
                {
                    client.AgregaSala(peli);

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
            var item = client.GetSalabyid(id);
            ViewSala model = new ViewSala();

            model.ID_Sala = item.ID_Sala;
            model.Desc_sala = item.Desc_sala;
           

            return View(model); //acá lo voy a devolver , en este caso lo estoy enviando al ootro metodo de HTTPPOST

        }

        [HttpPost]
        public ActionResult Editar(ViewSala model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Sala sala = new Sala();
            sala.ID_Sala = model.ID_Sala;
            sala.Desc_sala = model.Desc_sala;
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