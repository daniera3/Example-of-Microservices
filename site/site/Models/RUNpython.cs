using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics; // Process
using System.IO; // StreamWriter

namespace site
{
    public class RUNpython
    {
        public void Runpy(string uml)
        {
            
            StreamWriter sw = new StreamWriter(uml);
            Process p = new Process(); // create process (i.e., the python program
            p.StartInfo.FileName = "python.exe";
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.UseShellExecute = false; // make sure we can read the output from stdout
            p.StartInfo.Arguments = uml; // start the python program with two parameters
            p.Start(); // start the process (the python program)
            StreamReader s = p.StandardOutput;
            String output = s.ReadToEnd();
            string[] r = output.Split(new char[] { ' ' }); // get the parameter
            Console.WriteLine(r[0]);
            p.WaitForExit();
            Console.ReadLine(); // wait for a key press
        }
    }
}