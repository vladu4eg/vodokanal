using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic.FileIO;

namespace Create1k
{
    class Program
    {
        static void Main(string[] args)
        {
            Csv csv = new Csv();
            csv.FileOpen("c:\\file1.csv");
        }
    }
}
