using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Register_Data
    {
        [Required(ErrorMessage = "Please enter your First Name")]
        public string First_Name { get; set; }
        [Required(ErrorMessage = "Please enter your Second Name")]
        public string Second_Name { get; set; }
        [Required(ErrorMessage = "Please enter your First Surname")]
        public string First_Surname { get; set; }
        [Required(ErrorMessage = "Please enter your Second Surname")]
        public string Second_Surname { get; set; }
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter the Date")]
        public DateTime Date_In { get; set; }
        [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Repeat your Password")]
        public string RePassword { get; set; }


    }
}