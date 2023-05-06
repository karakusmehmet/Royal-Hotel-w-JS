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
    public class TBL_KategoriController : Controller
    {
        private Otel_OdaEntities db = new Otel_OdaEntities();

        // GET: TBL_Kategori
        public ActionResult Index()
        {
            return View(db.TBL_Kategori.ToList());
        }

        // GET: TBL_Kategori/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Kategori tBL_Kategori = db.TBL_Kategori.Find(id);
            if (tBL_Kategori == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Kategori);
        }

        // GET: TBL_Kategori/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_Kategori/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Kategori")] TBL_Kategori tBL_Kategori)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Kategori.Add(tBL_Kategori);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Kategori);
        }

        // GET: TBL_Kategori/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Kategori tBL_Kategori = db.TBL_Kategori.Find(id);
            if (tBL_Kategori == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Kategori);
        }

        // POST: TBL_Kategori/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Kategori")] TBL_Kategori tBL_Kategori)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Kategori).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Kategori);
        }

        // GET: TBL_Kategori/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Kategori tBL_Kategori = db.TBL_Kategori.Find(id);
            if (tBL_Kategori == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Kategori);
        }

        // POST: TBL_Kategori/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Kategori tBL_Kategori = db.TBL_Kategori.Find(id);
            db.TBL_Kategori.Remove(tBL_Kategori);
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
