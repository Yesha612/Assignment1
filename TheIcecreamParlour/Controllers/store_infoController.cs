using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TheIcecreamParlour.Models;

namespace TheIcecreamParlour.Controllers
{
    public class store_infoController : Controller
    {
        private dbModel db = new dbModel();

        // GET: store_info
        public ActionResult Index()
        {
            var store_info = db.store_info.Include(s => s.icecream);
            return View(store_info.ToList());
        }

        // GET: store_info/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            store_info store_info = db.store_info.Find(id);
            if (store_info == null)
            {
                return HttpNotFound();
            }
            return View(store_info);
        }

        // GET: store_info/Create
        public ActionResult Create()
        {
            ViewBag.FlavourID = new SelectList(db.icecreams, "FlavourID", "Flavour");
            return View();
        }

        // POST: store_info/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "StoreLocationId,StoreName,FlavourID,Flavour,Address,City")] store_info store_info)
        {
            if (ModelState.IsValid)
            {
                db.store_info.Add(store_info);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.FlavourID = new SelectList(db.icecreams, "FlavourID", "Flavour", store_info.FlavourID);
            return View(store_info);
        }

        // GET: store_info/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            store_info store_info = db.store_info.Find(id);
            if (store_info == null)
            {
                return HttpNotFound();
            }
            ViewBag.FlavourID = new SelectList(db.icecreams, "FlavourID", "Flavour", store_info.FlavourID);
            return View(store_info);
        }

        // POST: store_info/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "StoreLocationId,StoreName,FlavourID,Flavour,Address,City")] store_info store_info)
        {
            if (ModelState.IsValid)
            {
                db.Entry(store_info).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.FlavourID = new SelectList(db.icecreams, "FlavourID", "Flavour", store_info.FlavourID);
            return View(store_info);
        }

        // GET: store_info/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            store_info store_info = db.store_info.Find(id);
            if (store_info == null)
            {
                return HttpNotFound();
            }
            return View(store_info);
        }

        // POST: store_info/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            store_info store_info = db.store_info.Find(id);
            db.store_info.Remove(store_info);
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
