﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void AddEstatus_Descrption(String Desccription)
        {
            vsystem_ndcEntities db = new vsystem_ndcEntities();
            tbl_estatus Estatus = new tbl_estatus();
            Estatus.descripcion = Desccription;
            db.tbl_estatus.Add(Estatus);
            db.SaveChanges();

        }

        public bool AuthenticateUser(LoginData LD) 
        {
            /*
            vsystem_ndcEntities db = new vsystem_ndcEntities();
            tbl_usuarios usuario = new tbl_usuarios();
            usuario = db.tbl_usuarios.Find(LD.Email);
            if(usuario != null)
            {
                if (usuario.password == LD.Password) 
                {
                    return true;
                }
            }
            */

            return true;
        }

        public void InsertRegistrationData(UserData UD) 
        {
            vsystem_ndcEntities db = new vsystem_ndcEntities();
            tbl_usuarios usuario = new tbl_usuarios();
            usuario.primer_nombre = UD.First_Name;
            usuario.segundo_nombre = UD.Second_Name;
            usuario.primer_apellido = UD.First_Surname;
            usuario.segundo_apellido = UD.Second_Surname;
            usuario.email = UD.Email;
            usuario.fecha_ingreso = UD.Date_In;
            usuario.password = UD.Password;

            db.tbl_usuarios.Add(usuario);
            db.SaveChanges();

        }
    }
}
