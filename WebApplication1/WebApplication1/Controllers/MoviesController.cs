﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Movie()
        {
            return View();
        }
    }
}