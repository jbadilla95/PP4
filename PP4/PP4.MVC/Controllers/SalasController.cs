using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.MVC.Models;
using PP4.MVC;

namespace PP4.MVC.Controllers
{
    public class SalasController : Controller
    {
        // GET: Salas
        public ActionResult Index()
        {
            return View();
        }
    }
}