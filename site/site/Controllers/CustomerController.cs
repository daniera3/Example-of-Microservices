using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using site.BinderModel;
using site.Models;

namespace site.Views.Home
{
    public class CustomerController : Controller
    {
        // GET: Customer
        public ActionResult CustomerDetals()
        {
            Customer c = new Customer
            {
                FirstName = "dani",
                Lastname = "rabi",
                ID = "2056056",
                Avereng = 5648
            };

            return View(c);
        }

        public ActionResult addCustomer()
        {
            return View(new Customer());
        }
        public ActionResult Submit(Customer obj)// or [ModelBinder(typeof(CustomrBinder))]Customer obj
        {
           /* Customer obj = new Customer
            {
                FirstName = Request.Form["fn"],
                Lastname = Request.Form["ln"],
                Avereng= int.Parse(Request.Form["Avereng"]),
                ID = Request.Form["id"]

            };*/
            if(ModelState.IsValid)
                return View("CustomerDetals", obj);
            return View("addCustomer", obj);
        }

    }
}