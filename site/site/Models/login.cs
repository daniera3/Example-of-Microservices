using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class Login
    {

        [Required]
        [RegularExpression("^[0-9,a-z,A-Z]{9}$", ErrorMessage = "pls enter 9 digits")]
        public string user { get; set; }
        [Required]
        public string password { get; set; }
    }
}