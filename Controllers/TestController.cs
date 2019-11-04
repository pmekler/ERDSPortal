using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERDSPortal.Controllers
{
    public class TestController : Controller
    {
        // 
        // GET: /Test/ 

        public ActionResult Index()
        {
            return View();
        }


        // 
        // GET: /Test/Welcome/ 

        public string Welcome()
        {
            return "This is the Welcome action method...";
        }
    }
}