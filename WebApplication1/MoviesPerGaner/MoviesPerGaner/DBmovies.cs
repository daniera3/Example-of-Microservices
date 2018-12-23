using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;




public class DBmovies
{
    public List<Movies> Arr { get; set; }
    public DBmovies(string sqlCon, string GanerName)
    {
        Arr = new List<Movies>();
        GetMovie(GanerName, sqlCon);

    }

    private void GetMovie(string a, string sqlCon)
    {

        //string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
        string query = "SELECT * FROM [dbo].[genre] WHERE [Namegenre]=@Namegenre ";
        using (SqlConnection connection = new SqlConnection(sqlCon))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            //a shorter syntax to adding parameters
            command.Parameters.AddWithValue("@Namegenre", a);
            //make sure you open and close(after executing) the connection
            connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                query = "SELECT  * FROM [dbo].[Movie]  WHERE [idmovie]=@idmovie ";
                using (SqlConnection connection1 = new SqlConnection(sqlCon))
                using (SqlCommand command1 = new SqlCommand(query, connection1))
                {
                    //a shorter syntax to adding parameters
                    command1.Parameters.AddWithValue("@idmovie", Reader.GetInt32(1));
                    //make sure you open and close(after executing) the connection
                    connection1.Open();
                    SqlDataReader Reader1 = command1.ExecuteReader();
                    while (Reader1.Read())
                    {
                        Movies movie = new Movies(Reader1.GetInt32(0), Reader1.GetString(1), Reader1.GetInt32(2), Reader1.GetString(3), Reader1.GetInt32(4), Reader1.GetString(5), Reader1.GetString(6));
                        Getimg(movie, sqlCon);
                        Getsars(movie, sqlCon);
                        GetDirector(movie, sqlCon);
                        GetGaner(movie, sqlCon);
                        Arr.Add(movie);
                    }

                }

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
            if (Reader.Read())
                a.Img = new Imge(Reader.GetInt32(0), Reader.GetString(1), Reader.GetString(2), Reader.GetString(3), Reader.GetString(4), Reader.GetString(5));
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

