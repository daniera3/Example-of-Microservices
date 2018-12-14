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
                string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MyData.mdf;Integrated Security=True";
                SqlDataReader reader;
                String query = "SELECT COUNT([userID]) FROM [dbo].[user] WHERE [userID] = @userID AND [password]=@password";
                //using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nicolro1\\Desktop\\Example-of-Microservices--master\\site\\site\\App_Data\\MyData.mdf;Integrated Security=True"))
                using (SqlConnection connection = new SqlConnection(sqlCon))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //a shorter syntax to adding parameters
                    command.Parameters.AddWithValue("@userID", obj.user);
                    command.Parameters.AddWithValue("@password", obj.password);
                    //make sure you open and close(after executing) the connection
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;

                    }
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
            catch (SqlException)
            {
                return "this acount hes it";

            }
        }
    }
}