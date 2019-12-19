using PP4.MVC.Models;
using PP4.MVC.Models.ViewsModels;
using PP4.MVC.ServicioP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;

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

           var verificasala = client.GetSalabyid(item.ID_sala); //verifico que la sala exista
            if (verificasala != null) {
                var verificauser = client.Getbyid(item.ID_persona); //verifico usuario
                  if (verificauser != null) 
                    {
                    if (item.Total_Pagar<=verificasala.Cantidad_disponible) { //a la cantidad disponible de la sala le rebajo un espacio 
                        verificasala.Cantidad_disponible = (verificasala.Cantidad_disponible - 1);
                        client.ActualizarSala(verificasala);

                        Compra model = new Compra();
                        model.Descripcion_peli = item.Descripcion_peli;
                        model.Fecha = item.Fecha;
                        model.ID_persona = item.ID_persona;
                        model.ID_sala = item.ID_sala;
                        model.Total_Pagar = item.Total_Pagar * 3800;

                        client.AgregaCompra(model);

                        return Redirect("~/Salas/Index/");
                    }

                   }
                    
                }
               
            return View(item);

        }

       

      
        public ActionResult Reporte()
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var listaCompras = client.GetAllCompras();
            List<ViewCompra> lista = new List<ViewCompra>();

            foreach (Compra item in listaCompras)
                lista.Add(new ViewCompra()
                {
                   Descripcion_peli=item.Descripcion_peli,
                   Fecha=item.Fecha,
                   ID_Compra=item.ID_Compra,
                   ID_persona=item.ID_persona,
                   ID_sala=item.ID_sala,
                   Total_Pagar=item.Total_Pagar




                });


            return View(lista);
           
        }

        public ActionResult ReportebyPersona(int id)
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var listapeliculas = client.GetcomprasbyIDPersona(id);
            List<ViewCompra> lista = new List<ViewCompra>();

            foreach (Compra item in listapeliculas)
                lista.Add(new ViewCompra()
                {
                    Descripcion_peli = item.Descripcion_peli,
                    ID_sala=item.ID_sala,
                    ID_persona=item.ID_persona,
                    Fecha = item.Fecha,
                    ID_Compra=item.ID_Compra,
                    Total_Pagar=item.Total_Pagar                                      
                });


            return View(lista);

        }



        public ActionResult ReportebySala(int id)
        {
            ServicioSoapClient client = new ServicioSoapClient();
            var listapeliculas = client.GetcomprasbyIDSala(id);
            List<ViewCompra> lista = new List<ViewCompra>();

            foreach (Compra item in listapeliculas)
                lista.Add(new ViewCompra()
                {
                    Descripcion_peli = item.Descripcion_peli,
                    ID_sala = item.ID_sala,
                    ID_persona = item.ID_persona,
                    Fecha = item.Fecha,
                    ID_Compra = item.ID_Compra,
                    Total_Pagar = item.Total_Pagar


                });


            return View(lista);

        }

        //debe de existir un metodo que me devuelva a la normalidad la cantidad disponible luego de que se acabe el dia de venta
    }
}