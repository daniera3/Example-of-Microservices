using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;




    public class DBmovies
    {
        public List<Movies> arr { get; set; }
        public DBmovies(string sqlCon)
        {
            arr = new List<Movies>();
            Getmovies(sqlCon);
        }
        private string Getmovies(string sqlCon)
        {
            
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
                        Getimg(a, sqlCon);
                        Getsars(a, sqlCon);
                        GetDirector(a, sqlCon);
                        GetGaner(a, sqlCon);
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

        private void Getimg(Movies a, string sqlCon)
        {

            //string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
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
        private void Getsars(Movies a, string sqlCon)
        {

            //string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
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
        private void GetDirector(Movies a, string sqlCon)
        {

            //string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
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
        private void GetGaner(Movies a, string sqlCon)
        {

            //string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
            string query = "SELECT * FROM [dbo].[genre] WHERE [idmovie] = @idmovie ";
            using (SqlConnection connection = new SqlConnection(sqlCon))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //a shorter syntax to adding parameters
                command.Parameters.AddWithValue("@idmovie", a.Idmovie);
                //make sure you open and close(after executing) the connection
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
                while (Reader.Read())
                    a.Ganer.Add(new Ganers(Reader.GetString(0), Reader.GetInt32(1)));
            }

        }
    }
