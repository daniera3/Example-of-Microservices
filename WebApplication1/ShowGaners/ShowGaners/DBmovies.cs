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
        
        private void GetMovie(Ganers a, string sqlCon)
        {

            //string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
            string query = "SELECT top 3 * FROM [dbo].[genre] WHERE [Namegenre]=@Namegenre ";
            using (SqlConnection connection = new SqlConnection(sqlCon))
            using (SqlCommand command = new SqlCommand(query, connection))
            {
            //a shorter syntax to adding parameters
            command.Parameters.AddWithValue("@Namegenre", a.NameGaner);
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
                        query = "SELECT * FROM [dbo].[movieimg]  WHERE [idimg]=@idimg ";
                        using (SqlConnection connection2 = new SqlConnection(sqlCon))
                        using (SqlCommand command2 = new SqlCommand(query, connection2))
                        {
                            //a shorter syntax to adding parameters
                            command2.Parameters.AddWithValue("@idimg", Reader1.GetInt32(2));
                            //make sure you open and close(after executing) the connection
                            connection2.Open();
                            SqlDataReader Reader2 = command2.ExecuteReader();
                            while (Reader2.Read())
                                a.NMAndIMG.Add(new NameMoviesAndIMG(Reader.GetInt32(1), Reader1.GetString(1), Reader2.GetString(1)));
                        }
                    }
                }
            }
            
            }

        }

    private void GetGaner(List<Ganers> a, string sqlCon)
    {

        //string sqlCon = "Data Source=(localdb)\\MSSQLLocalDB;AttachDbFilename=|DataDirectory|aspnet-WebApplication1-20181211112737.mdf;Integrated Security=True";
        string query = "SELECT DISTINCT [Namegenre] FROM [dbo].[genre]";
        using (SqlConnection connection = new SqlConnection(sqlCon))
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            //a shorter syntax to adding parameters
            //make sure you open and close(after executing) the connection
            connection.Open();
            SqlDataReader Reader = command.ExecuteReader();
            while (Reader.Read())
            {
                Ganers ganer = new Ganers(Reader.GetString(0), 1);
                Arr.Add(ganer);
            }
            foreach (Ganers g in Arr)
            {
                GetMovie(g, sqlCon);
            }
        }

    }
}
