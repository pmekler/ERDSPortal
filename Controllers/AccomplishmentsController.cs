using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ERDSPortal.Data;
using ERDSPortal.Models;

namespace ERDSPortal.Controllers
{
    public class AccomplishmentsController : Controller
    {
        private ERDSPortalDBContext db = new ERDSPortalDBContext();

        // GET: Accomplishments
        public ActionResult Index()
        {
            Console.WriteLine("test");
            return View(db.Accomplishments.Include(a=>a.ValueDrivers).ToList());
        }

        // GET: Accomplishments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomplishment accomplishment = db.Accomplishments.Find(id);
            if (accomplishment == null)
            {
                return HttpNotFound();
            }
            return View(accomplishment);
        }

        // GET: Accomplishments/Create
        public ActionResult Create()
        {
            ERDSPortalDBContext dbContext = new ERDSPortalDBContext();
            ViewData["ValueDrivers"] = dbContext.ValueDrivers.ToList<ValueDriver>();
            return View();
        }

        // POST: Accomplishments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AccomplishmentId,Date,TeamName,Title,Details,ValueDriversSelection")] Accomplishment accomplishment)
        {

            if (ModelState.IsValid)
            {
                List<ValueDriver> valueDrivers = new List<ValueDriver>();
                if (accomplishment.ValueDriversSelection != null)
                    if (accomplishment.ValueDriversSelection.Contains(","))
                    {
                        List<string> vdList = accomplishment.ValueDriversSelection.Split(',').ToList<string>();
                        foreach(string vdID in vdList)
                        {
                            if (vdID.Length > 0)
                            {
                                valueDrivers.Add(db.ValueDrivers.Find(Int32.Parse(vdID)));
                            }
                        }
                    }

                accomplishment.ValueDrivers = valueDrivers;
                db.Accomplishments.Add(accomplishment);




                db.SaveChanges();
                ViewData["test"] = accomplishment.ValueDriversSelection;

                return RedirectToAction("Index");
            }

            return View(accomplishment);
        }

        // GET: Accomplishments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomplishment accomplishment = db.Accomplishments.Find(id);
            if (accomplishment == null)
            {
                return HttpNotFound();
            }
            return View(accomplishment);
        }

        // POST: Accomplishments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AccomplishmentId,Date,TeamName,Title, Details")] Accomplishment accomplishment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(accomplishment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(accomplishment);
        }

        // GET: Accomplishments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Accomplishment accomplishment = db.Accomplishments.Find(id);
            if (accomplishment == null)
            {
                return HttpNotFound();
            }
            return View(accomplishment);
        }

        // POST: Accomplishments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Accomplishment accomplishment = db.Accomplishments.Find(id);
            db.Accomplishments.Remove(accomplishment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

    }
}
