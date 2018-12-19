using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace wecandothis
{
    class Program
    {
        static void Main(string[] args)
        {
            DBmovies r = new DBmovies(args[0]);

            string json = JsonConvert.SerializeObject(r.arr.ToArray());
            
            //write string to file
            System.IO.File.WriteAllText(args[1], json);

        }
    }
}
