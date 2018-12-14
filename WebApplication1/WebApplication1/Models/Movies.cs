using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Movies
    {
        public string id { get; set; }
        public Movies()
        {
            id = " ";
        }
        public Movies (string A)
        {
            id = A;
        }

    }
}