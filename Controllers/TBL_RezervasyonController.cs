using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using RoyalHotel.Models;

namespace RoyalHotel.Controllers
{
    public class TBL_RezervasyonController : Controller
    {
        private Otel_RezervasyonEntities db = new Otel_RezervasyonEntities();

        // GET: TBL_Rezervasyon
        public ActionResult Index()
        {
            var tBL_Rezervasyon = db.TBL_Rezervasyon.Include(t => t.TBL_Mod).Include(t => t.TBL_Sec);
            return View(tBL_Rezervasyon.ToList());
        }

        // GET: TBL_Rezervasyon/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Rezervasyon tBL_Rezervasyon = db.TBL_Rezervasyon.Find(id);
            if (tBL_Rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Rezervasyon);
        }

        // GET: TBL_Rezervasyon/Create
        public ActionResult Create()
        {
            ViewBag.RezervasyonModID = new SelectList(db.TBL_Mod, "ID", "Mod");
            ViewBag.RezervasyonSecID = new SelectList(db.TBL_Sec, "ID", "Oda");
            return View();
        }

        // POST: TBL_Rezervasyon/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RezervasyonID,RezervasyonAd,RezervasyonSecID,RezervasyonTel,RezervasyonKisi,RezervasyonGece,RezervasyonModID")] TBL_Rezervasyon tBL_Rezervasyon)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Rezervasyon.Add(tBL_Rezervasyon);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RezervasyonModID = new SelectList(db.TBL_Mod, "ID", "Mod", tBL_Rezervasyon.RezervasyonModID);
            ViewBag.RezervasyonSecID = new SelectList(db.TBL_Sec, "ID", "Oda", tBL_Rezervasyon.RezervasyonSecID);
            return View(tBL_Rezervasyon);
        }

        // GET: TBL_Rezervasyon/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Rezervasyon tBL_Rezervasyon = db.TBL_Rezervasyon.Find(id);
            if (tBL_Rezervasyon == null)
            {
                return HttpNotFound();
            }
            ViewBag.RezervasyonModID = new SelectList(db.TBL_Mod, "ID", "Mod", tBL_Rezervasyon.RezervasyonModID);
            ViewBag.RezervasyonSecID = new SelectList(db.TBL_Sec, "ID", "Oda", tBL_Rezervasyon.RezervasyonSecID);
            return View(tBL_Rezervasyon);
        }

        // POST: TBL_Rezervasyon/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RezervasyonID,RezervasyonAd,RezervasyonSecID,RezervasyonTel,RezervasyonKisi,RezervasyonGece,RezervasyonModID")] TBL_Rezervasyon tBL_Rezervasyon)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Rezervasyon).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RezervasyonModID = new SelectList(db.TBL_Mod, "ID", "Mod", tBL_Rezervasyon.RezervasyonModID);
            ViewBag.RezervasyonSecID = new SelectList(db.TBL_Sec, "ID", "Oda", tBL_Rezervasyon.RezervasyonSecID);
            return View(tBL_Rezervasyon);
        }

        // GET: TBL_Rezervasyon/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Rezervasyon tBL_Rezervasyon = db.TBL_Rezervasyon.Find(id);
            if (tBL_Rezervasyon == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Rezervasyon);
        }

        // POST: TBL_Rezervasyon/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Rezervasyon tBL_Rezervasyon = db.TBL_Rezervasyon.Find(id);
            db.TBL_Rezervasyon.Remove(tBL_Rezervasyon);
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
