using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RoyalHotel.Models;
using RoyalHotel.Models;

namespace RoyalHotel.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        For_DropdownEntities1 db = new For_DropdownEntities1();
        Class1 cs = new Class1();
        public ActionResult Dropdown()
        {
            cs.OdaTuru = new SelectList(db.TBL_Tur, "id", "ad");
            cs.Oda = new SelectList(db.TBL_O, "odaid", "odaad");

            return View(cs);


        }

        public JsonResult odagetir(int p)
        {
            var odalar = (from x in db.TBL_O
                          join y in db.TBL_Tur on x.TBL_Tur.id equals y.id
                          where x.TBL_Tur.id == p

                          select new
                          {
                              Text = x.odaad,
                              Value = x.odaid.ToString()
                          }).ToList();
            return Json(odalar, JsonRequestBehavior.AllowGet);
        }
        
    }
}