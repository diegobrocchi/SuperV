using SuperVCore.Context;
using SuperVCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperVCore.BusinessLogic
{
    public class MachineStatusManager
    {
        /// <summary>
        /// Aggiunge lo stato per la macchina, oppure aggiorna quello esistente.
        /// </summary>
        /// <param name="current"></param>
        public void Upsert(UpsertMachineStatus current)
        {
            using (var ctx = new SupervisoreDBEntities())
            {
                var dbStatus = ctx.MachineStatus.Where(x => x.MachineID == current.MachineID).SingleOrDefault();
                if (dbStatus == null)
                {
                    //insert
                    MachineStatus toInsert = new Context.MachineStatus();
                    toInsert.MachineID = current.MachineID;
                    toInsert.MachineStateID = current.MachineStatus;
                    toInsert.Speed = current.Speed;
                    toInsert.Counter = current.Counter;
                    toInsert.ProductCode = current.ProductCode;
                    toInsert.ResettableCounter = current.ResettableCounter;
                    toInsert.AverageSpeed = current.AverageSpeed;

                    ctx.MachineStatus.Add(toInsert);
                }
                else
                {
                    //update
                    dbStatus.MachineStateID = current.MachineStatus;
                    dbStatus.Speed = current.Speed;
                    dbStatus.Counter = current.Counter;
                    dbStatus.ProductCode = current.ProductCode ;
                    dbStatus.ResettableCounter = current.ResettableCounter;
                    dbStatus.AverageSpeed = current.ResettableCounter;
                }

                ctx.SaveChanges();
            }
        }
    }
}
