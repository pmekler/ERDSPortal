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
    public class FocusAreasController : Controller
    {
        private ERDSPortalDBContext db = new ERDSPortalDBContext();

        // GET: FocusAreas
        public ActionResult Index()
        {
            return View(db.FocusAreas.ToList());
        }

        // GET: FocusAreas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FocusArea focusArea = db.FocusAreas.Find(id);
            if (focusArea == null)
            {
                return HttpNotFound();
            }
            return View(focusArea);
        }

        // GET: FocusAreas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FocusAreas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FocusAreaId,Name,Description,Icon")] FocusArea focusArea)
        {
            if (ModelState.IsValid)
            {
                db.FocusAreas.Add(focusArea);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(focusArea);
        }

        // GET: FocusAreas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FocusArea focusArea = db.FocusAreas.Find(id);
            if (focusArea == null)
            {
                return HttpNotFound();
            }
            return View(focusArea);
        }

        // POST: FocusAreas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FocusAreaId,Name,Description,Icon")] FocusArea focusArea)
        {
            if (ModelState.IsValid)
            {
                db.Entry(focusArea).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(focusArea);
        }

        // GET: FocusAreas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FocusArea focusArea = db.FocusAreas.Find(id);
            if (focusArea == null)
            {
                return HttpNotFound();
            }
            return View(focusArea);
        }

        // POST: FocusAreas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FocusArea focusArea = db.FocusAreas.Find(id);
            db.FocusAreas.Remove(focusArea);
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
