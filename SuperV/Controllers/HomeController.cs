using DevExpress.Web.Mvc;
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
            return RedirectToAction("Panel");
        }


        public ActionResult Panel()
        {
            return View();
        }


        /// <summary>
        /// Recupera i dati dal DB e prepara la view pannello con tutte le macchine.
        /// Il risultato è una partial view.
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
        /// Recupera dal DB i dati di lavorazione della macchina individuata dal ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public ActionResult MachineDetails(int ID, int Status, DateTime? From, DateTime? To)
        {
            //Inizializza le date nel caso manchino
            DateTime  queryDateFrom;
            DateTime queryDateTo;
            if (!From.HasValue)
                queryDateFrom = DateTime.Now.AddMonths(-1).Date;
            else
                queryDateFrom = From.Value ;

            if (!To.HasValue)
                queryDateTo = DateTime.Now.Date;
            else
                queryDateTo = To.Value;

            ViewBag.ID = ID;

            ViewData["ID"] = ID;
            ViewData["Status"] = Status;
            ViewData["From"] = queryDateFrom.ToString("o");
            ViewData["To"] = queryDateTo.ToString("o");

            var model = new MachineDataDetailsVM();
            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                var actualStatusMachine = ctx.MachineStatus.Where(x => x.MachineID == ID).SingleOrDefault();
                
                model.ID = ID;
                model.MachineName = actualStatusMachine.Machines.Name;
                model.StatusName = actualStatusMachine.MachineStates.Name;
                model.ProductCode = actualStatusMachine.ProductCode;
                model.Speed = actualStatusMachine.Speed.HasValue ? actualStatusMachine.Speed.Value : 0;
                model.From = queryDateFrom;
                model.To = queryDateTo;
                model.Status = Status;
                model.WorkItems = ctx.Works.Where(x => x.MachineID == ID)
                    .Where(x => x.Start.HasValue)
                    .Where(x => x.Finish.HasValue)
                    .Where(x => x.Start >= queryDateFrom)
                    .Where(x => x.Finish <= queryDateTo)
                    .GroupBy(x => new { @code = x.Code, @um = x.UnitOfMeasure })
                    .Select(x => new ViewModels.MachineWorkItemVM()
                    {
                        Code = x.Key.code,
                        IDs = x.Select(d => d.ID),
                        Minutes = x.Sum(f => System.Data.Entity.DbFunctions.DiffMinutes(f.Start.Value, f.Finish.Value).Value),
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

        public ActionResult GridViewPartial(int ID, int Status, DateTime From, DateTime To)
        {
            var model = new MachineDataDetailsVM();
            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                var actualStatusMachine = ctx.MachineStatus.Where(x => x.MachineID == ID).SingleOrDefault();

                ViewData["ID"] = ID;
                ViewData["Status"] = Status;
                ViewData["From"] = From.ToString("o");
                ViewData["To"] = To.ToString("o");

                model.WorkItems = ctx.Works.Where(x => x.MachineID == ID)
                    .Where(x => x.Start.HasValue)
                    .Where(x => x.Finish.HasValue)
                    .Where(x => x.Start >= From)
                    .Where(x => x.Finish <= To)
                    .GroupBy(x => new { @code = x.Code, @um = x.UnitOfMeasure })
                    .Select(x => new ViewModels.MachineWorkItemVM()
                    {
                        Code = x.Key.code,
                        IDs = x.Select(d => d.ID),
                        Minutes = x.Sum(f => System.Data.Entity.DbFunctions.DiffMinutes(f.Start.Value, f.Finish.Value).Value),
                        Start = x.Min(d => d.Start),
                        Finish = x.Max(d => d.Finish)

                    }).ToList();
            }

            return PartialView("_GridViewPartial", model.WorkItems );
        }

        [ValidateInput(false)]
        public ActionResult PivotGridPartial(int ID, int Status, DateTime From, DateTime To)
        {

            var model = new MachineDataDetailsVM();
            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                var actualStatusMachine = ctx.MachineStatus.Where(x => x.MachineID == ID).SingleOrDefault();

                ViewData["ID"] = ID;
                ViewData["Status"] = Status;
                //model.MachineName = actualStatusMachine.Machines.Name;
                //model.StatusName = actualStatusMachine.MachineStates.Name;
                //model.ProductCode = actualStatusMachine.ProductCode;
                //model.Speed = actualStatusMachine.Speed.HasValue ? actualStatusMachine.Speed.Value : 0;
                ViewData["From"] = From.ToString("o");
                ViewData["To"] = To.ToString("o");
                model.WorkItems = ctx.Works.Where(x => x.MachineID == ID)
                    .Where(x => x.Start.HasValue)
                    .Where(x => x.Finish.HasValue)
                    .Where(x => x.Start >= From )
                    .Where(x => x.Finish <= To)
                    .GroupBy(x => new { @code = x.Code, @um = x.UnitOfMeasure })
                    .Select(x => new ViewModels.MachineWorkItemVM()
                    {
                        Code = x.Key.code,
                        IDs = x.Select(d => d.ID),
                        Minutes = x.Sum(f => System.Data.Entity.DbFunctions.DiffMinutes(f.Start.Value, f.Finish.Value).Value),
                        Start = x.Min(d => d.Start),
                        Finish = x.Max(d => d.Finish)

                    }).ToList();
            }

             
            return PartialView("_PivotGridPartial", model.WorkItems );
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