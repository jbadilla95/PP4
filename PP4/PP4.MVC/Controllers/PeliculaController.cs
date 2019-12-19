using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using PP4.MVC.Models;
using PP4.MVC.Models.ViewsModels;
using PP4.MVC.ServicioP;



namespace PP4.MVC.Controllers
{
    public class PeliculaController : Controller
    {
        // GET: Pelicula
        ServicioSoapClient client1 = new ServicioSoapClient();
        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ViewPelicula model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Pelicula peli = new Pelicula();
             peli.Descripcion_Pelicula= model.Descripcion_Pelicula;
            peli.Duracion = model.Duracion;
            peli.Estado = model.Estado;
            peli.horario = model.horario;
            peli.ID_sala = model.ID_sala;



            try
            {
                if (ModelState.IsValid)
                {
                    client.AgregaPelicula(peli);

                    return Redirect("~/Pelicula/Index");
                }

                return View(model);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }

        public ActionResult Index()
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var listapeliculas = client.GetAllPeliculas();
            List<ViewPelicula> lista = new List<ViewPelicula>();

            foreach (Pelicula item in listapeliculas)
            lista.Add(new ViewPelicula()
            {
                ID_Pelicula = item.ID_Pelicula,
                Descripcion_Pelicula =item.Descripcion_Pelicula,
                Duracion = item.Duracion,
                Estado = item.Estado,
                horario = item.horario,
                ID_sala=item.ID_sala



            });
        

            return View(lista);
        }

        public ActionResult Editar(int id)
        {
            var item = client1.GetPeliculabyid(id);
            ViewPelicula model = new ViewPelicula();

            model.ID_Pelicula = item.ID_Pelicula;
            model.Descripcion_Pelicula = item.Descripcion_Pelicula;
            model.Duracion = item.Duracion;
            model.Estado = item.Estado;
            model.ID_sala = item.ID_sala;


            return View(model); //acá lo voy a devolver 
            
        }

        [HttpPost]
        public ActionResult Editar(ViewPelicula model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Pelicula peli = new Pelicula();
            peli.Descripcion_Pelicula = model.Descripcion_Pelicula;
            peli.Duracion = model.Duracion;
            peli.Estado = model.Estado;
            peli.ID_Pelicula = model.ID_Pelicula;
            peli.ID_sala = model.ID_sala;
            try
            {
                if (ModelState.IsValid)
                {
                    client.ActualizarPelicula(peli);

                    return Redirect("~/Pelicula/Index/");
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
            client1.EliminarPelicula(id);

            return Redirect("~/Pelicula/Index/");
        }

       
        public ActionResult Verifica_peli(int id)
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var listapeliculas = client.GetsalabyidPelicula(id);
            List<ViewPelicula> lista = new List<ViewPelicula>();
            
            foreach (Pelicula item in listapeliculas)
                lista.Add(new ViewPelicula()
                {
                    ID_Pelicula = item.ID_Pelicula,
                    Descripcion_Pelicula = item.Descripcion_Pelicula,
                    Duracion = item.Duracion,
                    Estado = item.Estado,
                    horario = item.horario,
                    ID_sala = item.ID_sala



                });


            return View(lista);
        }
    }
}

