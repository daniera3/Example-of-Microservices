using site.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace site.Controllers
{
    public class StudentController : Controller
    {
        public ActionResult StudentDetals(Register obj)
        {
            if (ModelState.IsValid)
                return View(obj);
            return View("Register", obj);
        }
        public ActionResult Login()
        {
            return View(new Login());
        }
        public ActionResult Register(Login obj)
        {
            Register a = new Register();
            if ((obj.user == "37412555" && obj.password == "111aaa") || (obj.user == "11111111" && obj.password == "222bbb") || (obj.user == "22222222" && obj.password == "333ccc"))
            {
                return View(new Register { User = obj.user });
            }
            ViewBag.error = "id/possword no incorrect";
            return View("Login",obj);

        }
    }
}