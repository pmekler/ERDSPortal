using ERDSPortal.Data;
using System.Linq;
using System.Web.Mvc;

namespace ERDSPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ERDSPortalDBContext db = new ERDSPortalDBContext();

        public ActionResult Index()
        {
            ViewBag.Accomplishments = db.Accomplishments.ToList();
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
    }
}