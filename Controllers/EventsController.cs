using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;

namespace ERDSPortal.Controllers
{
    public class EventsController : Controller
    {
        // GET: Events
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Event(int? id)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(Server.MapPath("~/Content/events.xml"));
            XmlNode eventInstance = doc.SelectSingleNode("/EVENTLIST/EVENT[@id='" + id + "']");
            Models.EventInstance EventInstance = new Models.EventInstance()
             {
                    EventID = int.Parse(eventInstance["ID"].InnerText),
                    Title = eventInstance["TITLE"].InnerText,
                    //Photo = eventInstance["PHOTO"].InnerText,
                    Date = eventInstance["DATE"].InnerText,
                    Location = eventInstance["LOCATION"].InnerText,
                    Details = eventInstance["DETAILS"].InnerText
             };
            
            return View(EventInstance);
        }
    }
}