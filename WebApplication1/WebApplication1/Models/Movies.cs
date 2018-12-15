using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Movies
    {
        public string id { get; set; }
        public Movies() { id = " "; }
        public Movies(int idmovie,string t, int idimg , string time, int rating , string outline, string Certificate )
        {
            this.idmovie = idmovie;
            this.title = t;
            this.idimg = idimg;
            this.time = time;
            this.rating = rating;
            this.outline = outline;
            this.Certificate = Certificate;
            this.str = new ArrayList();
            this.dir = new ArrayList();
            this.Ganer = new ArrayList();
        }
        public string outline { get; set; }
        public int idmovie { get; set; }
        public string title { get; set; }
        public int idimg { get; set; }
        public string time { get; set; }
        public imge Img { get; set; }
        public int rating { get; set; }
        public string Certificate { get; set; }

        public ArrayList str { get; }
        public ArrayList Ganer { get; set; }
        public ArrayList dir { get;}
        
    }

    public class Director
    {
        public int idmovie { get; set; }
        public string NameDirector { get; set; }

        public Director(string url,int id)
        {
            idmovie = id;
            NameDirector = url;
        }
    }

    public class star
    {
        public int idmovie { get; set; }
        public string Namestar { get; set; }

        public star(string url,int id )
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
        public imge(int id, string url, string titl, string alt, string width, string height)
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