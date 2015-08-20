using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Project.Models
{
    public class Login_Data
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}