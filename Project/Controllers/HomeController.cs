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
        public PartialViewResult _Roles() 
        {
            return PartialView("_Roles");
        }
        public PartialViewResult _Usuarios()
        {
            return PartialView("_Usuarios");
        }
        public PartialViewResult _Departamentos()
        {
            return PartialView("_Departamentos");
        }

        public ViewResult index()
        {
            Index_Data ID = new Index_Data();
            if (Session["Email"] != null) 
            {
                ID.Email = Session["Email"].ToString();
                return View("index", ID);
            }
            return View("page_500");
            
        }

        public ViewResult page_500() 
        {
            return View();
        }

        public ViewResult page_404()
        {
            return View();
        }

        [HttpGet]
        public ActionResult page_register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult page_register(Register_Data RD)
        {
            if (ModelState.IsValid)
            {
                
                Service1Client client = new Service1Client();
                UserData userdata = new UserData();
                userdata.User_Id = RD.User_Id;
                userdata.First_Name = RD.First_Name;
                userdata.Second_Name = RD.Second_Name;
                userdata.First_Surname = RD.First_Surname;
                userdata.Second_Surname = RD.Second_Surname;
                userdata.Email = RD.Email;
                userdata.Date_In = RD.Date_In;
                userdata.Password = RD.Password;
                if (client.InsertRegistrationData(userdata)) 
                {
                    client.Close();
                    return Login();
                }
                
                client.Close();
                return page_500();
            }
            else 
            {
                return View();
            }

        }

        [HttpGet]
        public ActionResult Login()
        {
            Session.Abandon();
            Session["Email"] = null;
            
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login_Data LD)
        {
            
            if (ModelState.IsValid)
            {
                
                Service1Client client = new Service1Client();
                LoginData auth = new LoginData();
                auth.Email = LD.Email;
                auth.Password = LD.Password;
                if (client.AuthenticateUser(auth))
                {
                    Session["Email"] = LD.Email;
                    return index();
                }
                else
                {
                    string error_message = "Wrong Email or Password";
                    ViewBag.LoginError = error_message;
                    return View();
                }
                

            }
            else 
            {
                return View();
            }
        }
    }
}