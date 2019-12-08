using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.MVC;
using PP4.BL;
using PP4.DAL;



namespace PP4.MVC.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            Persona_CRUD lst = new Persona_CRUD();
            
            return View(lst.Get());

        }
    }
}