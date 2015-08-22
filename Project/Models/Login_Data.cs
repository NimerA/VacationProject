using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Login_Data
    {
        [Required(ErrorMessage = "Please enter your Email")]
        public string Email { get; set; }
         [Required(ErrorMessage = "Please enter your Password")]
        public string Password { get; set; }
    }
}