using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace WebApplication1.Models
{
    public class DBmovies
    {
        public ArrayList arr { get; set; }
        public DBmovies()
        {
            arr = new ArrayList();
            Getmovies();
        }
        private string Getmovies()
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
                SqlDataReader Reader = command.ExecuteReader();
                    while (Reader.Read())
                    {
                        Movies a = new Movies(Reader.GetInt32(0), Reader.GetString(1), Reader.GetInt32(2), Reader.GetString(3), Reader.GetInt32(4), Reader.GetString(5), Reader.GetString(6));
                        Getimg(a);
                        Getsars(a);
                        GetDirector(a);
                        arr.Add(a);
                    }
                    return "true";

                }
                catch (Exception ex)
                {
                    return ex.Message;
                }
            }


        }

        private void Getimg(Movies a)
        {

            string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
            string query = "SELECT * FROM [dbo].[movieimg] WHERE [idimg] = @idimg ";
            using (SqlConnection connection = new SqlConnection(sqlCon))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //a shorter syntax to adding parameters
                command.Parameters.AddWithValue("@idimg", a.Idimg);
                //make sure you open and close(after executing) the connection
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                if(Reader.Read())
                    a.Img=new Imge(Reader.GetInt32(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetString(5));
            }

        }
        private void Getsars(Movies a)
        {

            string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
            string query = "SELECT * FROM [dbo].[star] WHERE [idmovie] = @idmovie ";
            using (SqlConnection connection = new SqlConnection(sqlCon))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //a shorter syntax to adding parameters
                command.Parameters.AddWithValue("@idmovie", a.Idmovie);
                //make sure you open and close(after executing) the connection
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                {
                    Star v = new Star(Reader.GetString(0), Reader.GetInt32(1));
                    a.Str.Add(v);
                }
            }

        }
        private void GetDirector(Movies a)
        {

            string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
            string query = "SELECT * FROM [dbo].[Director] WHERE [idmovie] = @idmovie ";
            using (SqlConnection connection = new SqlConnection(sqlCon))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //a shorter syntax to adding parameters
                command.Parameters.AddWithValue("@idmovie", a.Idmovie);
                //make sure you open and close(after executing) the connection
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                    a.Dir.Add(new Director(Reader.GetString(0), Reader.GetInt32(1)));
            }

        }
    }
}