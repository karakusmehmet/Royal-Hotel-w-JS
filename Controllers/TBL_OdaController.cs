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
    public class TBL_OdaController : Controller
    {
        private Otel_OdaEntities db = new Otel_OdaEntities();

        // GET: TBL_Oda
        public ActionResult Index()
        {
            var tBL_Oda = db.TBL_Oda.Include(t => t.TBL_Kategori);
            return View(tBL_Oda.ToList());
        }

        // GET: TBL_Oda/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Oda tBL_Oda = db.TBL_Oda.Find(id);
            if (tBL_Oda == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Oda);
        }

        // GET: TBL_Oda/Create
        public ActionResult Create()
        {
            ViewBag.Kategori = new SelectList(db.TBL_Kategori, "ID", "Kategori");
            return View();
        }

        // POST: TBL_Oda/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OdaID,OdaAd,OdaOzellik,OdaFiyat,Kategori")] TBL_Oda tBL_Oda)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Oda.Add(tBL_Oda);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Kategori = new SelectList(db.TBL_Kategori, "ID", "Kategori", tBL_Oda.Kategori);
            return View(tBL_Oda);
        }

        // GET: TBL_Oda/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Oda tBL_Oda = db.TBL_Oda.Find(id);
            if (tBL_Oda == null)
            {
                return HttpNotFound();
            }
            ViewBag.Kategori = new SelectList(db.TBL_Kategori, "ID", "Kategori", tBL_Oda.Kategori);
            return View(tBL_Oda);
        }

        // POST: TBL_Oda/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OdaID,OdaAd,OdaOzellik,OdaFiyat,Kategori")] TBL_Oda tBL_Oda)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Oda).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Kategori = new SelectList(db.TBL_Kategori, "ID", "Kategori", tBL_Oda.Kategori);
            return View(tBL_Oda);
        }

        // GET: TBL_Oda/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Oda tBL_Oda = db.TBL_Oda.Find(id);
            if (tBL_Oda == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Oda);
        }

        // POST: TBL_Oda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Oda tBL_Oda = db.TBL_Oda.Find(id);
            db.TBL_Oda.Remove(tBL_Oda);
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
