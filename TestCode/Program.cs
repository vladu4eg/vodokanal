using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace TestCode
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataSet = new DataSet();
            dataSet.ReadXml("C:\\1.xml");
            int i = 0;
            foreach (DataTable t in dataSet.Tables)
            {
                foreach (DataRow r in t.Rows)
                {
                    foreach (DataColumn c in t.Columns)
                    {
                        Console.WriteLine(r.Table + "\n"); // Например выводим все данные в консоль
                        Console.WriteLine(r[c] + "\n"); // Например выводим все данные в консоль
                        if(i % 100 == 0)
                        {
                            Console.ReadKey();
                        }
                        i++;
                    }
                }
            }
            Console.ReadKey();
        }
    }
}
