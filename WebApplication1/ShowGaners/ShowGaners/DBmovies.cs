using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;




    public class DBmovies
    {
        public List<Ganers> Arr { get; set; }
        public DBmovies(string sqlCon)
        {
            Arr = new List<Ganers>();
            GetGaner(Arr, sqlCon);
      
        }
        private void getimg(Ganers g, string sqlCon)
        {
        string query = "SELECT  * FROM [dbo].[Movie]  WHERE [idmovie]=@idmovie ";
        using (SqlConnection connection = new SqlConnection(sqlCon))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            //a shorter syntax to adding parameters
            command.Parameters.AddWithValue("@idmovie", g.Idmovie);
            //make sure you open and close(after executing) the connection
            connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                g.NMAndIMG.NameMovies = Reader.GetString(1);
                query = "SELECT * FROM [dbo].[movieimg]  WHERE [idimg]=@idimg ";
                using (SqlConnection connections = new SqlConnection(sqlCon))
                using (SqlCommand commands = new SqlCommand(query, connections))
                {
                    //a shorter syntax to adding parameters
                    commands.Parameters.AddWithValue("@idimg",Reader.GetString(2) );
                    //make sure you open and close(after executing) the connection
                    connections.Open();
                    SqlDataReader Readers = commands.ExecuteReader();
                    while (Readers.Read())
                        g.NMAndIMG.NameIMG = Readers.GetString(1);
                }
            }
        }
    }
        private void GetGaner(List<Ganers> a, string sqlCon)
        {

            //string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
            string query = "SELECT * FROM [dbo].[genre]";
            using (SqlConnection connection = new SqlConnection(sqlCon))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
                //a shorter syntax to adding parameters
                //make sure you open and close(after executing) the connection
                connection.Open();
                SqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Ganers ganer = new Ganers(Reader.GetString(0), Reader.GetInt32(1));
                Arr.Add(ganer);
            }
                foreach(Ganers g in Arr)
            {
                getimg(g, sqlCon);
            }
            }

        }
    }
