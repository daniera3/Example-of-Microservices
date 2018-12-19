using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace wecandothis
{
    class Program
    {
        static void Main(string[] args)
        {
            DBmovies r = new DBmovies(args[0]);
            foreach(Movies movie in r.arr)
            {
                movie.printall();
                Console.WriteLine("good");
            }
           
        }
    }
}
