using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class Movie
    {
        static int x=9999;
        [Required]
        public string title { get; set; }
        [Required]
        [RegularExpression("^[0-9,.]{2}$", ErrorMessage = "pls enter 2 digits")]
        public float rating { get; set; }
        [Required]
        public string Id {
            get {
                x = x + 1;
                return x.ToString();
                }
        }
        [Required]
        public string director { get; set; }

    }
}