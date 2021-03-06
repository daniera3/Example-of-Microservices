﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace wecandothis
{
    class Program
    {
        static int Main(string[] args)
        {
            try
            {
                int i;
                string DataBacePath = "";
                for (i = 0; i < args.Length - 1; i++)
                    DataBacePath += args[i] + " ";
                //string DataBacePath = @"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=D:\Example-of-Microservices\WebApplication1\WebApplication1\App_Data\aspnet-WebApplication1-20181211112737.mdf;Initial Catalog=aspnet-WebApplication1-20181211112737;Integrated Security=True";

                DBmovies r = new DBmovies(DataBacePath);

                string json = JsonConvert.SerializeObject(r.arr.ToArray());

                //write string to file
                System.IO.File.WriteAllText(args[args.Length-1], json);
            }
            catch (Exception )
            {
                Console.WriteLine(args[args.Length - 1]);
            }
            return 0;
        }
    }
}
