﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

    public class Movies
    {
        public Movies(int idmovie, string t, int idimg, string time, int rating, string Certificate, string outline)
        {
            this.Idmovie = idmovie;
            this.Title = t;
            this.Idimg = idimg;
            this.Time = time;
            this.Rating = rating;
            this.Outline = outline;
            this.Certificate = Certificate;

            this.Str = new List<Star>();
            this.Dir = new List<Director>();
            this.Ganer = new List<Ganers>();
        }

        public Imge Img { get; set; }
        public string Outline { get; set; }
        public int Idmovie { get; set; }
        public string Title { get; set; }
        public int Idimg { get; set; }
        public string Time { get; set; }
        public int Rating { get; set; }
        public string Certificate { get; set; }

        public List<Star> Str { get; set; }
        public List<Ganers> Ganer { get; set; }
        public List<Director> Dir { get; set; }

    }

    public class Director
    {
        public int idmovie { get; set; }
        public string NameDirector { get; set; }
        public void printAll()
        {
            Console.Write(NameDirector + " ");

        }
        public Director(string url, int id)
        {
            idmovie = id;
            NameDirector = url;
        }
    }

    public class Ganers
    {
        public int Idmovie { get; set; }
        public string NameGaner { get; set; }
       
        public Ganers(string url, int id)
        {
            Idmovie = id;
            NameGaner = url;
        }
    }

    public class Star
    {
        public int Idmovie { get; set; }
        public string Namestar { get; set; }
       
        public Star(string url, int id)
        {
            Idmovie = id;
            Namestar = url;
        }
    }


    public class Imge
    {
        public int idimg { get; set; }
        public string img { get; set; }
        public string title { get; set; }
        public string alt { get; set; }
        public string width { get; set; }
        public string height { get; set; }
      
        public Imge(int id, string url, string titl, string alt, string width, string height)
        {
            idimg = id;
            img = url;
            title = titl;
            this.alt = alt;
            this.width = width;
            this.height = height;
        }
    }
