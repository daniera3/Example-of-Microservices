using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace site.Models
{
    public class AddNowUser
    {

        public string NowUser(Movies obj)
        {

            try
            {
                string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MyData.mdf;Integrated Security=True";
                String query = "INSERT INTO [dbo].[user] ([userID], [password]) VALUES (@userID,@password)";
                using (SqlConnection connection = new SqlConnection(sqlCon))
                //using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nicolro1\\Desktop\\Example-of-Microservices--master\\site\\site\\App_Data\\MyData.mdf;Integrated Security=True"))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //a shorter syntax to adding parameters
                    //command.Parameters.AddWithValue("@userID", obj);

                    //command.Parameters.AddWithValue("@password", obj);
                    //make sure you open and close(after executing) the connection
                    try
                    {
                        connection.Open();
                    }
                    catch (SqlException ex )
                    {
                        /*  string uml = "D:\\Example-of-Microservices\\site\\site\\Models\\movies.py";
                          RUNpython x = new RUNpython();
                          x.Runpy(uml);*/
                        return ex.Message;
                    }
                    command.ExecuteNonQuery();
                    connection.Close();
                }


                return "true";
            }
            catch (SqlException ex)
            {
                return ex.Message;
              
            }
        }
    }
}