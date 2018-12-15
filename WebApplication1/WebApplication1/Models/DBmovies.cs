using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class DBmovies
    {
        public SqlDataReader Reader { get; set; }
        public string getmovies()
        {
            try
            {

                string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
                string query = "SELECT * FROM [dbo].[Movie]";
                //using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nicolro1\\Desktop\\Example-of-Microservices--master\\site\\site\\App_Data\\MyData.mdf;Integrated Security=True"))
                using (SqlConnection connection = new SqlConnection(sqlCon))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //a shorter syntax to adding parameters
                    //make sure you open and close(after executing) the connection
                    try
                    {
                        connection.Open();
                    }
                    catch (Exception ex)
                    {
                        return ex.Message;

                    }
                    Reader = command.ExecuteReader();
                    return "true";
                }
            }
            catch (SqlException ex)
            {
                return ex.Message;

            }
        }
    }
}