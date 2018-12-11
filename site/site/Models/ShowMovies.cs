using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace site.Models
{
    public class ShowMovies
    {
        SqlDataReader reader;
        public SqlDataReader Check()
        {

                string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|MyData.mdf;Integrated Security=True";
                String query = "SELECT * FROM [dbo].[Movies]";
                //using (SqlConnection connection = new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\nicolro1\\Desktop\\Example-of-Microservices--master\\site\\site\\App_Data\\MyData.mdf;Integrated Security=True"))
                using (SqlConnection connection = new SqlConnection(sqlCon))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    //make sure you open and close(after executing) the connection
                    try
                    {
                    connection.Open();
                    reader = command.ExecuteReader();
                     }
                    catch (Exception)
                    {
                    return null;
                    }
                    return reader;
                }



        }
    }
}