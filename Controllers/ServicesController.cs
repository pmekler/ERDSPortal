using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERDSPortal.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Teams
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MBTech()
        {
            ViewBag.Message = "MBTech's service page.";

            return View();
        }
        public ActionResult PortfolioManagement()
        {
            ViewBag.Message = "SO/RTE Portfolio Management's service page.";

            return View();
        }
        public ActionResult ModelBasedPLM()
        {
            ViewBag.Message = "SO/RTE Model Based PLM's service page.";

            return View();
        }
        public ActionResult RegulatoryClinical()
        {
            ViewBag.Message = "SO/RTE Regulatory & Clinical's service page.";

            return View();
        }
        public ActionResult MaintainedServices()
        {
            ViewBag.Message = "SO Maintained Services's service page.";

            return View();
        }
        public ActionResult SoftwareMedDevice()
        {
            ViewBag.Message = "SO/RTO Software as a Medical Devices' service page.";

            return View();
        }
        public ActionResult CAx()
        {
            ViewBag.Message = "SO/RTO CAx's service page.";

            return View();
        }
        public ActionResult AppMaintenance()
        {
            ViewBag.Message = "SO Application Maintenance's service page.";

            return View();
        }
    }
}