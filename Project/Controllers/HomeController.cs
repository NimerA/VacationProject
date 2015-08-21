﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project.Models;
using Project.ServiceReference;

namespace Project.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult index()
        {
            Service1Client client = new Service1Client();
            client.AddEstatus_Descrption("Desc. es Mueble");
            client.Close();
            return View();
        }

        public ActionResult page_register()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login_Data LD)
        {
            return View("Home",LD);
        }
    }
}