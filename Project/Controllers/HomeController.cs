using System;
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
            Index_Data ID = new Index_Data();
            string sessionname = "No Session";
            if (Session["Email"] != null) 
            {
                sessionname = Session["Email"].ToString();
            }

            ID.Email = sessionname;

            return View("index",ID);
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
                userdata.First_Name = RD.First_Name;
                userdata.Second_Name = RD.Second_Name;
                userdata.First_Surname = RD.First_Surname;
                userdata.Second_Surname = RD.Second_Surname;
                userdata.Email = RD.Email;
                userdata.Date_In = RD.Date_In;
                userdata.Password = RD.Password;
                client.InsertRegistrationData(userdata);
                client.Close();
                return View("index", RD);
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
            return View();
        }
        [HttpPost]
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