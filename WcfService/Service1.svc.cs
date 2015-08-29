using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using MySql.Data.MySqlClient;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public List<tbl_roles> GetRolList()
        {
            vsystem_ndcEntities db = new vsystem_ndcEntities();
            List<tbl_roles> list = db.tbl_roles.ToList();
            return list;
        }
        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public void PostRol(tbl_roles rol)
        {
            vsystem_ndcEntities db = new vsystem_ndcEntities();
            tbl_roles Rol = new tbl_roles();
            Rol.rolesid = rol.rolesid;
            Rol.descripcion = rol.descripcion;
            Rol.activo = rol.activo;
            db.tbl_roles.Add(Rol);
            db.SaveChanges();
        }

        public void PostDepartmento(tbl_departamento departamento) 
        {
            vsystem_ndcEntities db = new vsystem_ndcEntities();
            tbl_departamento Departamento = new tbl_departamento();
            Departamento.departamentoid = departamento.departamentoid;
            Departamento.descripcion = departamento.descripcion;
            Departamento.activo = departamento.activo;
            db.tbl_departamento.Add(departamento);
            db.SaveChanges();
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
            string server = "104.236.126.219";
            string database = "vsystem_ndc";
            string uid = "ndc";
            string password = "ndc01";
            string connectionString;
            connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

            try
            {

                MySqlConnection connection = new MySqlConnection(connectionString);
                string query = "SELECT email FROM tbl_usuarios";

                connection.Open();
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();
                while (dataReader.Read())
                {
                    string user = LD.Email;
                    string users_db = dataReader["email"].ToString();
                    if (users_db.Equals(user))
                    {
                        dataReader.Close();
                        connection.Close();
                        return true;
                    }
                }
                dataReader.Close();
                connection.Close();
            }

            catch (Exception ex) 
            {
                if (ex is MySqlException || ex is System.TimeoutException) 
                {
                    Console.WriteLine("Exception Ocuured");
                    return false;
                }
            }
            return false;
        }

        public bool InsertRegistrationData(UserData UD)
        {
            try
            {
                vsystem_ndcEntities db = new vsystem_ndcEntities();
                tbl_usuarios usuario = new tbl_usuarios();
                usuario.talento_humano = UD.User_Id;
                usuario.primer_nombre = UD.First_Name;
                usuario.segundo_nombre = UD.Second_Name;
                usuario.primer_apellido = UD.First_Surname;
                usuario.segundo_apellido = UD.Second_Surname;
                usuario.email = UD.Email;
                usuario.fecha_ingreso = UD.Date_In;
                usuario.password = UD.Password;
                usuario.activo = false;
                usuario.fecha_creacion = DateTime.Now;
                db.tbl_usuarios.Add(usuario);
                db.SaveChanges();

                return true;
            }
            catch (SystemException) 
            {
                return false;
            }
        }
    }
}
