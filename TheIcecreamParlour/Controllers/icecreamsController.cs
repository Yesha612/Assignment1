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
        //private DbModel db = new DbModel();

        IMockIcecreams db;

        //constructors
        // default constructor

        public icecreamsController()
        {
            this.db = new IDataIcecreams();
        }

        public icecreamsController(IMockIcecreams mockdb)
        {
            this.db = mockdb;
        }

        // GET: icecreams
        public ActionResult Index()
        {
            return View("Index", db.icecreams.ToList());
        }

        // GET: icecreams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //icecream icecream = db.icecreams.Find(id);
            icecream icecream = db.icecreams.SingleOrDefault(i => i.FlavourID == id);
            if (icecream == null)
            {
                return HttpNotFound();
            }
            return View("Details", icecream);
        }

        // GET: icecreams/Create
        public ActionResult Create()
        {
            return View("Create");
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
                //db.icecreams.Add(icecream);
                //db.SaveChanges();
                db.Save(icecream);
                return RedirectToAction("Index");
            }

            return View("Create",icecream);
        }

        // GET: icecreams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //icecream icecream = db.icecreams.Find(id);
            icecream icecream = db.icecreams.SingleOrDefault(i => i.FlavourID == id);
            if (icecream == null)
            {
                return HttpNotFound();
            }
            return View("Edit",icecream);
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
                //db.Entry(icecream).State = EntityState.Modified;
                //db.SaveChanges();
                db.Save(icecream);
                return RedirectToAction("Index");
            }
            return View("Edit",icecream);
        }

        // GET: icecreams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //icecream icecream = db.icecreams.Find(id);
            icecream icecream = db.icecreams.SingleOrDefault(i => i.FlavourID == id);
            if (icecream == null)
            {
                return HttpNotFound();
            }
            return View("Delete", icecream);
        }

        // POST: icecreams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //icecream icecream = db.icecreams.Find(id);
            icecream icecream = db.icecreams.SingleOrDefault(i => i.FlavourID == id);
            //db.icecreams.Remove(icecream);
            //db.SaveChanges();
            db.Delete(icecream);
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
