using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoyalHotel.Models;
using System.Linq.Dynamic.Core;
namespace RoyalHotel.Controllers
{
    public class UyeController : Controller
    {
        // GET: Uye
        public ActionResult Index(string sort = "Uye_Ad", string sortdir = "asc",string search = "")

        {
            int totalRecord = 0;
            var data = GetUye_Bilgisi(search, sort, sortdir, out totalRecord);
            ViewBag.TotalRows = totalRecord;
            ViewBag.search = search;
            return View(data);
        }

        public List<Uye_Bilgi>GetUye_Bilgisi(string search, string sort, string sortdir, out int totalRecord)

        {
            
            using (Uye_GosterEntities db = new Uye_GosterEntities())
            {
                var v = (from a in db.Uye_Bilgi

                         where a.Uye_Ad.Contains(search) ||
                         a.Uye_Soyad.Contains(search) ||
                         a.Uye_Adres.Contains(search)

                         select a
                );

                totalRecord = v.Count();
                v = v.OrderBy(sort + " " + sortdir);
                return v.ToList();
            }
        }

        public ActionResult List()
        {
            var uyeler = new List<Uye_Bilgi>();
            using (Uye_GosterEntities db = new Uye_GosterEntities())
            {
                uyeler = db.Uye_Bilgi.ToList();

            }
            return View(uyeler);
        }


    }
}