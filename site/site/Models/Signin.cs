using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class Signin
    {
        public string Check(Login obj)
        {
            try
            {
                SqlDataReader reader;
                String query = "SELECT [userID] ,[password] FROM [dbo].[user] WHERE [userID] = @userID AND [password]=@password";
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\Example-of-Microservices\\site\\site\\App_Data\\MyData.mdf;Integrated Security=True"))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //a shorter syntax to adding parameters
                    command.Parameters.AddWithValue("@userID", obj.user);
                    command.Parameters.AddWithValue("@password", obj.password);
                    //make sure you open and close(after executing) the connection
                    connection.Open();
                    reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        connection.Close();
                        return "true";
                    }
                    else
                    {
                        connection.Close();
                        return "id / possword no incorrect,try Signup";
                    }
                      
                }


            }
            catch (SqlException ex)
            {
                return ex.Message;

            }
        }
    }
}