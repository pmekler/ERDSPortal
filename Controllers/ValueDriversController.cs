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
    public class ValueDriversController : Controller
    {
        private ERDSPortalDBContext db = new ERDSPortalDBContext();

        // GET: ValueDrivers
        public ActionResult Index()
        {
            return View(db.ValueDrivers.ToList());
        }

        // GET: ValueDrivers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueDriver valueDriver = db.ValueDrivers.Find(id);
            if (valueDriver == null)
            {
                return HttpNotFound();
            }
            return View(valueDriver);
        }

        // GET: ValueDrivers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ValueDrivers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ValueDriverId,Name,Description")] ValueDriver valueDriver)
        {
            if (ModelState.IsValid)
            {
                db.ValueDrivers.Add(valueDriver);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(valueDriver);
        }

        // GET: ValueDrivers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueDriver valueDriver = db.ValueDrivers.Find(id);
            if (valueDriver == null)
            {
                return HttpNotFound();
            }
            return View(valueDriver);
        }

        // POST: ValueDrivers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ValueDriverId,Name,Description")] ValueDriver valueDriver)
        {
            if (ModelState.IsValid)
            {
                db.Entry(valueDriver).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(valueDriver);
        }

        // GET: ValueDrivers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ValueDriver valueDriver = db.ValueDrivers.Find(id);
            if (valueDriver == null)
            {
                return HttpNotFound();
            }
            return View(valueDriver);
        }

        // POST: ValueDrivers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ValueDriver valueDriver = db.ValueDrivers.Find(id);
            db.ValueDrivers.Remove(valueDriver);
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
