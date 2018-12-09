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
   

        public ActionResult Submit(Register obj)
        {
            if (ModelState.IsValid)
                return View(obj);
            return View("Register", obj);
        }

        public ActionResult Login()
        {
            return View(new Login());
        }
        public ActionResult IsRegister(Login obj)
        {
            
            if ((obj.user == "37412555" && obj.password == "111aaa") || (obj.user == "11111111" && obj.password == "222bbb") || (obj.user == "22222222" && obj.password == "333ccc") || (obj.user == "" && obj.password == ""))
            {
                return View(new Register { User = obj.user });
            }
            ViewBag.error = "id/possword no incorrect";
            return View("Login", obj);

        }
        public ActionResult Register(Register obj)
        {
            if (obj.password == obj.Check && !(obj.password is null))
            {
                try
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
            }
            else if(obj.password != obj.Check)
            {
                ViewBag.error ="password no something";
            }
            return View(new Register { User = obj.User });
        }
    }
}