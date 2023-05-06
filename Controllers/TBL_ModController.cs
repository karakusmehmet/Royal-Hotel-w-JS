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
    public class TBL_ModController : Controller
    {
        private Otel_RezervasyonEntities db = new Otel_RezervasyonEntities();

        // GET: TBL_Mod
        public ActionResult Index()
        {
            return View(db.TBL_Mod.ToList());
        }

        // GET: TBL_Mod/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Mod tBL_Mod = db.TBL_Mod.Find(id);
            if (tBL_Mod == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Mod);
        }

        // GET: TBL_Mod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_Mod/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Mod")] TBL_Mod tBL_Mod)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Mod.Add(tBL_Mod);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Mod);
        }

        // GET: TBL_Mod/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Mod tBL_Mod = db.TBL_Mod.Find(id);
            if (tBL_Mod == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Mod);
        }

        // POST: TBL_Mod/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Mod")] TBL_Mod tBL_Mod)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Mod).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Mod);
        }

        // GET: TBL_Mod/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Mod tBL_Mod = db.TBL_Mod.Find(id);
            if (tBL_Mod == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Mod);
        }

        // POST: TBL_Mod/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Mod tBL_Mod = db.TBL_Mod.Find(id);
            db.TBL_Mod.Remove(tBL_Mod);
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
