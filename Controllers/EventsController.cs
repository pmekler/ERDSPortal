using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;

namespace ERDSPortal.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Event()
        {
            List<Models.Events> events = new List<Models.Events>();
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/Content/events.xml"));

            foreach (XmlElement element in doc.DocumentElement.SelectNodes("EVENT[ID='1']"))
            {
                Console.Out.WriteLine(doc.OuterXml);
                /*events.Add(new Models.Events
                {
                    EventID = int.Parse(node["ID"].InnerText),
                    Title = node["TITLE"].InnerText,
                    Date = node["DATE"].InnerText,
                    Location = node["LOCATION"].InnerText,
                    Details = node["DETAILS"].InnerText
                });*/
            }
            return View();
        }
    }
}