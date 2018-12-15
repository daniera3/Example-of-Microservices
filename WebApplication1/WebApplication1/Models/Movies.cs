using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Movies
    {
        public string id
        {
            get
            {
                return " ";
            }
        }

        public star str { get;  }
        public imge Img { get; }
        public Director dir { get; }



        

        public class Director
        {
            public int idmovie { get; set; }
            public string NameDirector { get; set; }

            public Director(int id, string url)
            {
                idmovie = id;
                NameDirector = url;
            }
        }

        public class star
        {
            public int idmovie { get; set; }
            public string Namestar { get; set; }

            public star(int id, string url)
            {
                idmovie = id;
                Namestar = url;
            }
        }


        public class imge
        {
            public int idimg { get; set; }
            public string img { get; set; }
            public string title { get; set; }
            public string alt { get; set; }
            public string width { get; set; }
            public string height { get; set; }
            public imge(int id,string url, string titl, string alt, string width, string height)
            {
                idimg = id;
                img = url;
                title = titl;
                this.alt = alt;
                this.width = width;
                this.height = height;
            }
        }
    }
}