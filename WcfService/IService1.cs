using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        string GetData(int value);
        [OperationContract]
        bool AuthenticateUser(LoginData LD);
        [OperationContract]
        void AddEstatus_Descrption(String Desccription);
        [OperationContract]
        bool InsertRegistrationData(UserData UD);
        [OperationContract]
        List<tbl_roles> GetRolList();
        [OperationContract]
        void PostDepartmento(tbl_departamento departamento);
        [OperationContract]
        void PostRol(tbl_roles rol);

        // TODO: Add your service operations here
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class UserData
    {
        int id = 0;
        string fname = string.Empty;
        string sname = string.Empty;
        string fsurname = string.Empty;
        string ssurname = string.Empty;
        string email = string.Empty;
        DateTime date;
        string pass = string.Empty;

        [DataMember]
        public int User_Id
        {
            get { return id; }
            set { id = value; }
        }
        [DataMember]
        public string First_Name
        {
            get { return fname; }
            set { fname = value; }
        }

        [DataMember]
        public string Second_Name
        {
            get { return sname; }
            set { sname = value; }
        }

        [DataMember]
        public string First_Surname
        {
            get { return fsurname; }
            set { fsurname = value; }
        }

        [DataMember]
        public string Second_Surname
        {
            get { return ssurname; }
            set { ssurname = value; }
        }

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public DateTime Date_In
        {
            get { return date; }
            set { date = value; }
        }

        [DataMember]
        public string Password
        {
            get { return pass; }
            set { pass = value; }
        }
    }
    [DataContract]
    public class LoginData
    {
        string email = string.Empty;
        string password = string.Empty;

        [DataMember]
        public string Email
        {
            get { return email; }
            set { email = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }

}

