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
    public class icecreamsController : Controller
    {
        private dbModel db = new dbModel();

        // GET: icecreams
        public ActionResult Index()
        {
            return View(db.icecreams.ToList());
        }

        // GET: icecreams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            icecream icecream = db.icecreams.Find(id);
            if (icecream == null)
            {
                return HttpNotFound();
            }
            return View(icecream);
        }

        // GET: icecreams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: icecreams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FlavourID,Flavour,Calories,Gluten_Free,Dairy_Free")] icecream icecream)
        {
            if (ModelState.IsValid)
            {
                db.icecreams.Add(icecream);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(icecream);
        }

        // GET: icecreams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            icecream icecream = db.icecreams.Find(id);
            if (icecream == null)
            {
                return HttpNotFound();
            }
            return View(icecream);
        }

        // POST: icecreams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "FlavourID,Flavour,Calories,Gluten_Free,Dairy_Free")] icecream icecream)
        {
            if (ModelState.IsValid)
            {
                db.Entry(icecream).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(icecream);
        }

        // GET: icecreams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            icecream icecream = db.icecreams.Find(id);
            if (icecream == null)
            {
                return HttpNotFound();
            }
            return View(icecream);
        }

        // POST: icecreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            icecream icecream = db.icecreams.Find(id);
            db.icecreams.Remove(icecream);
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
