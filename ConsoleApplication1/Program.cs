using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlDependency.Start(ConfigurationManager.ConnectionStrings["SupervisoreDB"].ConnectionString);
            var mgr = new MessageRepo();
           Console.WriteLine(string.Join(",", mgr.GetAllMessages()));

            Console.ReadKey();

            SqlDependency.Stop(ConfigurationManager.ConnectionStrings["SupervisoreDB"].ConnectionString);
        }
    }
}
