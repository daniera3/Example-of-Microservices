using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



    class Program
    {
        static int Main(string[] args)
        {
        string DataBacePath = "";
        try
            {
            int i;
            
            for (i = 0; i < args.Length - 1; i++)
                DataBacePath += args[i]+" ";
            

                DBmovies r = new DBmovies(DataBacePath);

                string json = JsonConvert.SerializeObject(r.Arr.ToArray());

                //write string to file
                System.IO.File.WriteAllText(args[args.Length-1], json);
            }
            catch (Exception ex  )
            {
           
            Console.WriteLine(args[args.Length-1]);
            Console.WriteLine(DataBacePath);
        }
            return 0;
        }
    }

