using site.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace site.Controllers
{
    public class AccController : Controller
    {
   


        public ActionResult Login(Login obj)
        {
            return View(obj);
        }

        public ActionResult IsRegister(Login obj)
        {
            Signin d = new Signin();
            string Message = d.Check(obj);
            if (Message == "true")
                return RedirectToAction("Index", "Home");
            ViewBag.error = Message;
            return View("Login", obj);

        }

        public ActionResult Register(Register obj)
        {
            if (obj.password == obj.Check && !(obj.password is null))
            {
                AddNowUser d = new AddNowUser();
               string Message = d.NowUser(obj);
                if (Message == "true")
                    return RedirectToAction("Login", new Login { user = obj.User });
                else
                {
                    ViewBag.error = Message;
                    return View(new Register());
                }
                /*
                 *try
                 {
                     String query = "INSERT INTO [dbo].[user] ([userID], [password]) VALUES (@userID,@password)";
                     using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Example-of-Microservices\\site\\site\\App_Data\\MyData.mdf;Integrated Security=True"))
                     using (SqlCommand command = new SqlCommand(query, connection))
                     {
                         //a shorter syntax to adding parameters
                         command.Parameters.AddWithValue("@userID", obj.User);

                         command.Parameters.AddWithValue("@password", obj.password);
                         //make sure you open and close(after executing) the connection
                         connection.Open();
                         command.ExecuteNonQuery();
                         connection.Close();
                     }


                 return RedirectToAction("Index","Home");
                  }
                 catch (SqlException ex)
                 {
                     ViewBag.error = ex.Message;
                     return View(new Register());
                 }
                 */
            }
            else if(obj.password != obj.Check)
            {
                ViewBag.error ="password no something";
            }
            return View(new Register { User = obj.User });
        }
    }
}