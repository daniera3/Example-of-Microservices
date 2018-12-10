using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class AddNowUser
    {

        public string NowUser(Register obj)
        {
            try
            {
                String query = "INSERT INTO [dbo].[user] ([userID], [password]) VALUES (@userID,@password)";
                using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nicolro1\\Desktop\\Example-of-Microservices--master\\site\\site\\App_Data\\MyData.mdf;Integrated Security=True"))
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


                return "true";
            }
            catch (SqlException ex)
            {
                return ex.Message;
              
            }
        }
    }
}