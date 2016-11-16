using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GalileePayroll.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is required to login")]
        [Display(Name = "Username")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Password is required to login" )]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}