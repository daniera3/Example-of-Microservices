using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace site.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Movies()
        {
            new ShowMovies().Check();
            return View();
        }
    }
}