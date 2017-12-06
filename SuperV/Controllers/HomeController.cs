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
            return View();
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
            var model = new PanelDetailVM();

            return PartialView("_panelPartial");
        }
    }

    public class PanelDetailVM
    {
        public int ID { get; set; }
        public string Name { get; set; }
    }

}