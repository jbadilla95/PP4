﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PP4.MVC;
using PP4.MVC.Models;
using PP4.MVC.ServicioP;



namespace PP4.MVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
           
         
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}