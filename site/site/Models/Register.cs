using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class Register
    {
        public string User { get; set; }
        [Required]
        public string Time { get; set; }
        [Required]
        [MinLength(5)]
        public string Name { get; set; }
    }
}