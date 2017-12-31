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
            return View();
        }

        //public ActionResult PanelDetail(int ID)
        //{
        //    //var model = new PanelDetailVM();
        //    //model.ID = ID;
        //    //model.Name = ID.ToString() + "-" + ID.ToString();
        //    //return View(model);

        //    return View();
        //}

        public ActionResult PanelPartial()
        {

            System.Threading.Thread.Sleep(3000);

            var model = new PartialPanelVM();
            List<MachineData> machinesData = new List<ViewModels.MachineData>();
            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                machinesData = ctx.MachineStatus.Select(x => new ViewModels.MachineData()
                {
                    MachineID = x.MachineID ,
                    Speed = x.Speed.Value,
                    ProductCode = x.ProductCode,
                    Status = x.MachineStateID.Value,
                    TotalCount = x.Counter.Value,
                    MachineName = x.Machines.Name,
                    WorkOperation = x.MachineStates.Name 
                }).ToList();
            }

            model.MachinesData = machinesData;

            return PartialView("_panelPartial", model);
        }

        public ActionResult MachineDetails(int ID)
        {
            ViewBag.ID = ID;
            return View();
        }

        public ActionResult MachinePh1(int ID)
        {
            System.Threading.Thread.Sleep(3000);

            ViewBag.ph1 = "AA " + DateTime.Now.Millisecond ;
            return PartialView();
        }
    }

    //public class PanelDetailVM
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //}

}