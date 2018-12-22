using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                string path = @"D:\Example-of-Microservices\WebApplication1\WebApplication1\App_Data\allGaners.json";
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    List<Ganers> Ganer = JsonConvert.DeserializeObject<List<Ganers>>(json);
                    TempData["GanersList"] = Ganer;
                }
                path = @"D:\Example-of-Microservices\WebApplication1\WebApplication1\App_Data\allMovies.json";
                using (StreamReader r = new StreamReader(path))
                {
                    string json = r.ReadToEnd();
                    List<Movies> Movie = JsonConvert.DeserializeObject<List<Movies>>(json);
                    TempData["MovieList"] = Movie;
                }
            }
            catch (Exception) { return View(); }
                return View();
            
        }


    }
}