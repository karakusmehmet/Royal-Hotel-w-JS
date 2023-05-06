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
    public class TBL_SecController : Controller
    {
        private Otel_RezervasyonEntities db = new Otel_RezervasyonEntities();

        // GET: TBL_Sec
        public ActionResult Index()
        {
            return View(db.TBL_Sec.ToList());
        }

        // GET: TBL_Sec/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Sec tBL_Sec = db.TBL_Sec.Find(id);
            if (tBL_Sec == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Sec);
        }

        // GET: TBL_Sec/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TBL_Sec/Create
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Oda")] TBL_Sec tBL_Sec)
        {
            if (ModelState.IsValid)
            {
                db.TBL_Sec.Add(tBL_Sec);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tBL_Sec);
        }

        // GET: TBL_Sec/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Sec tBL_Sec = db.TBL_Sec.Find(id);
            if (tBL_Sec == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Sec);
        }

        // POST: TBL_Sec/Edit/5
        // Aşırı gönderim saldırılarından korunmak için, bağlamak istediğiniz belirli özellikleri etkinleştirin, 
        // daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Oda")] TBL_Sec tBL_Sec)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tBL_Sec).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tBL_Sec);
        }

        // GET: TBL_Sec/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TBL_Sec tBL_Sec = db.TBL_Sec.Find(id);
            if (tBL_Sec == null)
            {
                return HttpNotFound();
            }
            return View(tBL_Sec);
        }

        // POST: TBL_Sec/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TBL_Sec tBL_Sec = db.TBL_Sec.Find(id);
            db.TBL_Sec.Remove(tBL_Sec);
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
