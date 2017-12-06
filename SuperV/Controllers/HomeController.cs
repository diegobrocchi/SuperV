using SuperV.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperV.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Panel()
        {
            var mg = new SQLDependencyManager();
            mg.RegisterSQLDependencyOnTableMachineStatus();

            using (var ctx = new SuperVCore.Context.SupervisoreDBEntities())
            {
                var db = ctx.MachineStatus.Select(x => new ViewModels.MachineData()
                {
                    MachineID = x.MachineID,
                    PartialCount = x.ResettableCounter,
                    ProductCode = x.ProductCode,
                    Status = x.MachineStateID,
                    TotalCount = x.Counter
                }).ToList();
            }

                var model = new ViewModels.PartialPanelVM();
            model.MachinesData.Add(new ViewModels.MachineData()
            {
                MachineID =1,
                PartialCount = 124,
                ProductCode = "XYZ-009",
                Status = 1,
                TotalCount = 1098
            });
            model.MachinesData.Add(new ViewModels.MachineData()
            {
                MachineID = 2,
                PartialCount = 345,
                ProductCode = "POL-098",
                Status = 2,
                TotalCount = 23456
            });
            return View(model);
        }

        public ActionResult PanelDetail(int ID)
        {
            var model = new PanelDetailVM();
            model.ID = ID;
            model.Name = ID.ToString() + "-" + ID.ToString();
            return View(model);
        }

        public ActionResult PanelPartial()
        {
            var model = new PartialPanelVM();
            List<MachineData> machinesData = new List<ViewModels.MachineData>();
            using (var ctx = new SuperVCore.Context.SupervisoreDBEntities())
            {
                machinesData = ctx.MachineStatus.Select(x => new ViewModels.MachineData()
                {
                    MachineID = x.MachineID,
                    PartialCount = x.ResettableCounter,
                    ProductCode = x.ProductCode,
                    Status = x.MachineStateID,
                    TotalCount = x.Counter
                }).ToList();
            }

            model.MachinesData = machinesData;
            
            return PartialView("_panelPartial", model);
        }
    }

    public class PanelDetailVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

}