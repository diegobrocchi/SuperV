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
                machinesData = ctx.MachineStatus
                    .Where(x => x.Machines.DepartmantID == 2)
                    .Select(x => new ViewModels.MachineData()
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
            DateTime queryDateFrom;
            DateTime queryDateTo;
            if (!From.HasValue)
                queryDateFrom = DateTime.Now.AddMonths(-1).Date;
            else
                queryDateFrom = From.Value;

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

        //public ActionResult MachinePh1(int ID)
        //{

        //    ViewBag.ph1 = "AA " + DateTime.Now.Millisecond;
        //    return PartialView();
        //}

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

            return PartialView("_GridViewPartial", model.WorkItems);
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


            return PartialView("_PivotGridPartial", model.WorkItems);
        }

        public ActionResult GetProcessingStepsTable(int ID, DateTime From, DateTime To, string Code)
        {
            var model = new List<MachineProcessingStepsVM>();
            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                model = ctx.ProcessingSteps
                    .Where(ps => ps.MachineID == ID)
                    .GroupBy(g => g.MachineStates)
                    .Select(x => new MachineProcessingStepsVM()
                    {
                        Name = x.Key.Name,
                        TotalMinutes = x.Sum(g => g.Works
                        .Where(f => f.Code == Code)
                        .Where(f => f.Start.HasValue)
                        .Where(f => f.Finish.HasValue)
                        .Sum(f => System.Data.Entity.DbFunctions.DiffMinutes(f.Start.Value, f.Finish.Value).Value)),
                        Waste = x.Sum(g => g.Works.Where(f => f.Code == Code).Where(f => f.Waste.HasValue).Select(f => f.Waste.Value).Sum())
                    })
                    .OrderBy(x => x.Name)
                    .ToList();
            }
            ViewData["Code"] = Code;

            return PartialView("_partialFasiTable", model);
        }

        public ActionResult GetAttrezzaggiTable(int ID, DateTime From, DateTime To, string Code)
        {
            var model = new List<MachineSetUpsVM>();
            using (var ctx = new SuperVCore.Context.EnoplasticEntities())
            {
                model = ctx.SetUpPartsLog
                    .Where(s => s.Works.MachineID == ID)
                    .Where(s => s.Works.Code == Code)
                    .Where(x => x.Works.Start.HasValue)
                    .Where(x => x.Works.Finish.HasValue)
                    .Where(x => x.Works.Start >= From)
                    .Where(x => x.Works.Finish <= To)
                    .Where(x => x.Value.HasValue)
                    .GroupBy(x => new { @name = x.SetUpParts.Description })
                    .Select(x => new ViewModels.MachineSetUpsVM()
                    {
                        Name = x.Key.name,
                        Quantity = x.Sum(g => g.Value.Value)
                    })
                    .OrderBy(x => x.Name)
                    .ToList();
            }
            ViewData["Code"] = Code;
            ViewData["ID"] = ID;
            ViewData["From"] = From;
            ViewData["To"] = To;
            return PartialView("_partialAttrezzaggiTable", model);
        }

        public ActionResult GetFermiTable(int ID, DateTime From, DateTime To, string Code)
        {
            ViewData["Code"] = Code;
            var model = new List<Test>();
            model.Add(new Controllers.Test()
            {
                Name = "AAAA"
            });
            model.Add(new Controllers.Test()
            {
                Name = "BBB"
            });
            return PartialView("_partialFermiTable", model);
        }

        public ActionResult Dashboard()
        {
            return View();

        }

        public ActionResult Report()
        {
            return View();

        }

        XtraReport1 report = new XtraReport1();

        public ActionResult DocumentViewerPartial()
        {
            return PartialView("_DocumentViewerPartial", report);
        }

        public ActionResult DocumentViewerPartialExport()
        {
            return DocumentViewerExtension.ExportTo(report, Request);
        }

        public ActionResult ExportDetails()
        {
            return View();
        }


        [ValidateInput(false)]
        public ActionResult GridViewExpPartial()
        {

            SuperVCore.Context.EnoplasticEntities db = new SuperVCore.Context.EnoplasticEntities();
            var model = db.SP_ReportWorks_StartDate_EndDate_MachineID(DateTime.Now.AddDays(-365), DateTime.Now, 29 ).ToList();
            return PartialView("_GridViewExpPartial", model.ToList());
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewExpPartialAddNew([ModelBinder(typeof(DevExpressEditorsBinder))] SuperVCore.Context.Works item)
        {
            SuperVCore.Context.EnoplasticEntities db = new SuperVCore.Context.EnoplasticEntities();

            var model = db.Works;
            if (ModelState.IsValid)
            {
                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewExpPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewExpPartialUpdate([ModelBinder(typeof(DevExpressEditorsBinder))] SuperVCore.Context.Works item)
        {
            SuperVCore.Context.EnoplasticEntities db = new SuperVCore.Context.EnoplasticEntities();

            var model = db.Works;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.ID == item.ID);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewExpPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewExpPartialDelete(System.Int32 ID)
        {
            SuperVCore.Context.EnoplasticEntities db = new SuperVCore.Context.EnoplasticEntities();

            var model = db.Works;
            if (ID >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.ID == ID);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewExpPartial", model.ToList());
        }
    }

    public class Test
    {
        public string Code { get; set; }
        public string Minutes { get; set; }
        public string Name { get; set; }
    }
    //public class PanelDetailVM
    //{
    //    public int ID { get; set; }
    //    public string Name { get; set; }
    //}

}