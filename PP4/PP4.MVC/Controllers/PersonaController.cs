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
    public class PersonaController : Controller
    {
        #region Dropdown
        // GET: Persona
        //public ActionResult Index()
        //{
        //    List<ViewPersona> Lst = null;  //con foreach para sacar la lista de personas 
        //    using (DBCPP4 DB = new DBCPP4())
        //    {
        //        Lst = (from d in DB.Persona
        //               select new ViewPersona
        //               {
        //                   ID_Persona = d.ID_Persona,
        //                   Nombre = d.Nombre,
        //                   Cedula = d.Cedula,
        //                   correo = d.correo

        //               }).ToList();
        //    }
        //    List<SelectListItem> items = Lst.ConvertAll(d =>    // el SelectListItem me permite llenar un dropdownlist // por edio de una expresion landa
        //    {
        //        return new SelectListItem() //los atributos dentro de la lista
        //        {
        //            Text = d.Nombre.ToString(),
        //            Value = d.ID_Persona.ToString(),
        //            Selected = false


        //        };
        //    });

        //    ViewBag.items = items; //el viewbag sirve como un diccionario que le puedo enviar cualquier tipo de cosa, es muy dinamico entonces le envio la lista 
        //    return View();
        //    //Persona_CRUD lst = new Persona_CRUD();

        //    //return View(lst.Get());

        //}
        #endregion

        public ActionResult About()
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
                   contraseña=item.contraseña,
                   tipo_perfil =item.tipo_perfil
                });


            return View(lista);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(ViewPersona model)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Persona per = new Persona();
            per.Nombre = model.Nombre;
            per.Cedula = model.Cedula;
            per.correo = model.correo;
            per.contraseña = model.correo;
            per.tipo_perfil = model.tipo_perfil;
            try
            {
                if (ModelState.IsValid)
                {
                    client.AgregaPersona(per);

                    return Redirect("~/Persona/About");
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
            var item = client.Getbyid(id);
            ViewPersona model = new ViewPersona();

            model.ID_Persona = item.ID_Persona;
            model.Nombre = item.Nombre;
            model.Cedula = item.Cedula;
            model.contraseña = item.contraseña;
            model.tipo_perfil = item.tipo_perfil;

            return View(model); //acá lo voy a devolver 

        }

        [HttpPost]
        public ActionResult Editar(ViewPersona item)
        {
            ServicioSoapClient client = new ServicioSoapClient();

            Persona model = new Persona();

            model.ID_Persona = item.ID_Persona;
            model.Nombre = item.Nombre;
            model.Cedula = item.Cedula;
            model.contraseña = item.contraseña;
            model.tipo_perfil = item.tipo_perfil;
            try
            {
                if (ModelState.IsValid)
                {
                    client.ActualizarPersona(model);

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
            ServicioSoapClient client = new ServicioSoapClient();
            client.EliminarPersona(id);

            return Redirect("~/Pelicula/Index/");

        }
    }
}
