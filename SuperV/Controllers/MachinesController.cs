using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperV.Controllers
{
    public class MachinesController : Controller
    {
        // GET: Panel
        public ActionResult Index()
        {
            var mg =   SQLDependencyManager.Instance ;
            mg.RegisterSQLDependencyOnTableMachineStatus();

            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                var db = ctx.MachineStatus.Select(x => new ViewModels.MachineData()
                {
                    MachineID = x.MachineID,
                    Speed = x.ResettableCounter.Value,
                    ProductCode = x.ProductCode,
                    Status = x.MachineStateID.Value,
                    TotalCount = x.Counter.Value
                }).ToList();
            }

            return View();
        }
    }
}