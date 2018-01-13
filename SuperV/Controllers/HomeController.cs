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

        /// <summary>
        /// Recupera i dati dal DB e prepara la view pannello con tutte le macchine.
        /// </summary>
        /// <returns></returns>
        public ActionResult PanelPartial()
        {
            var model = new PartialPanelVM();
            List<MachineData> machinesData = new List<ViewModels.MachineData>();
            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                machinesData = ctx.MachineStatus.Select(x => new ViewModels.MachineData()
                {
                    MachineID = x.MachineID,
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

        /// <summary>
        /// Recupera dal DB i dati di lavorazione della macchina indiviaduata dal ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult MachineDetails(int ID, DateTime From, DateTime To)
        {
            ViewBag.ID = ID;
            var model = new MachineDataDetailsVM();
            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                model.WorkItems = ctx.Works.Where(x => x.MachineID == ID)
                    .Where(x => x.Start .HasValue )
                    .Where(x => x.Finish.HasValue )
                    .Where(x => x.Start >= From)
                    .Where(x => x.Finish <= To)
                    .GroupBy(x => new { @code = x.Code, @um = x.UnitOfMeasure })
                    .Select(x => new ViewModels.MachineWorkItemVM()
                {
                    Code = x.Key.code ,
                     IDs = x.Select(d=> d.ID),
                     Minutes = x.Sum(f => System.Data.Entity.DbFunctions.DiffMinutes(f.Start.Value, f.Finish.Value   ).Value),
                     
                    Start = x.Min(d => d.Start),
                    Finish = x.Max(d => d.Finish) 

                }).ToList();
            }

            return View(model);
        }

        public ActionResult MachinePh1(int ID)
        {

            ViewBag.ph1 = "AA " + DateTime.Now.Millisecond;
            return PartialView();
        }

        public ActionResult GridViewPartial()
        {
            var model = new List<Test>();
            model.Add(new Test()
            {
                Code = "Primo C1",
                Minutes  = "Primo C2"
            });
            model.Add(new Test()
            {
                Code = "Secondo C1",
                Minutes = "Secondo C2"
            });
            return PartialView("_GridViewPartial", model);
        }
    }

    public class Test
    {
        public string Code { get; set; }
        public string Minutes { get; set; }
    }
    //public class PanelDetailVM
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //}

}