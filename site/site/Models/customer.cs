using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class Customer
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        [RegularExpression("^[0-9]{9}$",ErrorMessage ="pls enter 9 digits")]
        public string ID { get; set; }
        [Required]
        public int Avereng { get; set; }
        public string Color
        {
            get
            {
                if (Avereng > 20000)
                    return "green";
                return "red";
            }
        }
    }
}