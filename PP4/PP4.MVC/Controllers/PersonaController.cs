using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PP4.DAL;
using PP4.BL;
using PP4.MVC.Models;
using PP4.MVC.Models.ViewsModels;
using PP4.MVC.ServicioPP4;
using Persona = PP4.DAL.Persona;

namespace PP4.MVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<ViewPersona> Lst = null;  //con foreach para sacar la lista de personas 
            using (DBCPP4 DB = new DBCPP4())
            {
                Lst = (from d in DB.Persona
                       select new ViewPersona
                       {
                           ID_Persona = d.ID_Persona,
                           Nombre = d.Nombre,
                           Cedula = d.Cedula,
                           correo = d.correo

                       }).ToList();
            }
            List<SelectListItem> items = Lst.ConvertAll(d =>    // el SelectListItem me permite llenar un dropdownlist // por edio de una expresion landa
            {
                return new SelectListItem() //los atributos dentro de la lista
                {
                    Text = d.Nombre.ToString(),
                    Value = d.ID_Persona.ToString(),
                    Selected = false


                };
            });

            ViewBag.items = items; //el viewbag sirve como un diccionario que le puedo enviar cualquier tipo de cosa, es muy dinamico entonces le envio la lista 
            return View();
            //Persona_CRUD lst = new Persona_CRUD();

            //return View(lst.Get());

        }

        public ActionResult About()
        {
            List<ViewPersona> lst;
            using (DBCPP4 DB = new DBCPP4())
            {
                lst = (from d in DB.Persona
                       select new ViewPersona
                       {
                           ID_Persona = d.ID_Persona,
                           Nombre = d.Nombre,
                           Cedula = d.Cedula,
                           correo = d.correo

                       }).ToList();

            }


            return View(lst);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ViewModelTabla model)
        {


            Persona_CRUD per = new Persona_CRUD();

            try
            {
                if (ModelState.IsValid)
                {

                    var oTabla = new Persona();
                    oTabla.Nombre = model.Nombre;
                    oTabla.Cedula = model.Cedula;
                    oTabla.correo = model.correo;
                    oTabla.contraseña = model.contraseña;
                    oTabla.tipo_perfil = model.tipo_perfil;
                    per.Insert(oTabla);
                    //Necesito activar un servicio pero no se cual
                    //ServiceClient client = new ServiceClient();

                    //// Use the 'client' variable to call operations on the service.
                    //persona_Service.Nombre = model.Nombre;
                    //persona_Service.Cedula = model.Cedula;
                    //persona_Service.correo = model.correo;
                    //persona_Service.contraseña = model.contraseña;
                    //persona_Service.tipo_perfil = model.tipo_perfil;
                    //client.NuevaPersona(persona_Service);
                    //// Always close the client.
                    //client.Close();



                    return Redirect("~/Persona/");
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
            ViewModelTabla model = new ViewModelTabla();
            using (DBCPP4 DB = new DBCPP4())
            {
                var oTabla = DB.Persona.Find(id); //estoy buscando el id de la persona seleccionada , recuerde que esto es llamado por la vista y en ella porogramé que se guardara el id de la persona seleccionada
                model.Nombre = oTabla.Nombre;
                model.correo = oTabla.correo;
                model.Cedula = oTabla.Cedula;
                model.tipo_perfil = oTabla.tipo_perfil;
                model.ID_Persona = oTabla.ID_Persona; //justo acá irá seleccionado 
            }
            return View(model); //acá lo voy a devolver 
        }

        [HttpPost]
        public ActionResult Editar(ViewModelTabla model)
        {
            Persona_CRUD per = new Persona_CRUD();
            try
            {
                if (ModelState.IsValid) //solo valido si el modelo es valido , un poco de redundancia y seguridad de que todos los datos estén completos 
                {
                    using (DBCPP4 DB = new DBCPP4())
                    {
                        var oTabla = DB.Persona.Find(model.ID_Persona);

                        oTabla.Nombre = model.Nombre;
                        oTabla.Cedula = model.Cedula;
                        oTabla.correo = model.correo;
                        oTabla.contraseña = model.contraseña;
                        oTabla.tipo_perfil = model.tipo_perfil;
                        //DB.Entry(oTabla).State = System.Data.Entity.EntityState.Modified; // esta es otra forma de hacerlo de forma directa , pero es una herramienta directa de MVC
                        per.Update(oTabla);
                    }

                    return Redirect("~/Persona/"); //me redirecciona a la raiz es decir en mi caso a persona 
                }

                return View(model); //si no es correcto me devuelve el modelo sin hacer nada 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);

            }
        }


        [HttpGet]
        public ActionResult Eliminar(int id)
        {
            Persona_CRUD per = new Persona_CRUD();
            per.Delete(id);

            return Redirect("~/Persona/");
        }
    }
}
