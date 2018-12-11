using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class Register
    {
        [Required]
        [RegularExpression("^[0-9]{9}$", ErrorMessage = "pls enter 9 digits")]
        public string User { get; set; }
        [Required]
        [RegularExpression("^[0-9,a-z]$", ErrorMessage = "pls enter only digite and low ")]
        public string password { get; set; }
        [Required]
        public string Check { get; set; }
    }

   
}