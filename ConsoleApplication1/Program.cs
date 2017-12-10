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
            var SuperVCore = new SuperVCore.BusinessLogic.MachineStatusManager();

            Random rnd = new Random();
            while (true)
            {
                int ID = rnd.Next(1, 5);
                var d = new SuperVCore.Models.UpsertMachineStatus()
                {
                    MachineID = ID,
                    AverageSpeed = rnd.Next(1, 10000),
                    Counter = rnd.Next(100,1000),
                    MachineStatus = rnd.Next(1,3)-1,
                    ProductCode = "wert" + rnd.Next(23,87),
                    ResettableCounter = rnd.Next(34, 9876),
                    Speed = rnd.Next(100,200)
                };
                Console.WriteLine("Update data dor machine " + ID);
                SuperVCore.Upsert(d);

                Console.WriteLine("Waiting 2 secs...");
                System.Threading.Thread.Sleep(2000);
            }

            //SqlDependency.Start(ConfigurationManager.ConnectionStrings["SupervisoreDB"].ConnectionString);
            //var mgr = new MessageRepo();
            //Console.WriteLine(string.Join(",", mgr.GetAllMessages()));

            //Console.ReadKey();

            //SqlDependency.Stop(ConfigurationManager.ConnectionStrings["SupervisoreDB"].ConnectionString);
        }
    }
}
