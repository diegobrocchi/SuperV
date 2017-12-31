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
                byte[] ID = new byte[1];
                byte []status =  new byte[1];
                rnd.NextBytes(ID) ;
                rnd.NextBytes(status);
                var d = new SuperVCore.Models.UpsertMachineStatus()
                {
                    MachineID = ID[0],
                    AverageSpeed = rnd.Next(1, 10000),
                    Counter = rnd.Next(100,1000),
                    MachineStatus = status[0],
                    ProductCode = "wert" + rnd.Next(23,87),
                    ResettableCounter = rnd.Next(34, 9876),
                    Speed = rnd.Next(100,200)
                };
                Console.WriteLine("Update data dor machine " + ID);
                //SuperVCore.Upsert(d);

                Console.WriteLine("Waiting 500 millisecs...");
                System.Threading.Thread.Sleep(500);
            }

             
        }
    }
}
