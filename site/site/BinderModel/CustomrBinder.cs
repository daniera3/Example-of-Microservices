using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using site.Models;

namespace site.BinderModel
{
    public class CustomrBinder : IModelBinder
    {
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            HttpContextBase objContext = controllerContext.HttpContext;
            Customer obj = new Customer
            {
                FirstName = objContext.Request.Form["fn"],
                Lastname = objContext.Request.Form["ln"],
                Avereng = int.Parse(objContext.Request.Form["Avereng"]),
                ID = objContext.Request.Form["id"]

            };
            return (obj);
        }
    }
}