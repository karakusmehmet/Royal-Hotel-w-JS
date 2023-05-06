using RoyalHotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoyalHotel.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserProfile objUser)
        {
            if (ModelState.IsValid)
            {
                using (LoginFormEntities db = new LoginFormEntities())
                {
                    var obj = db.UserProfile.Where(a => a.Username.Equals(objUser.Username) &&

                    a.Password.Equals(objUser.Password)).FirstOrDefault();

                    if (obj != null)
                    {
                        Session["UserId"] = obj.UserId.ToString();
                        Session["Username"] = obj.Username.ToString();
                        return RedirectToAction("Anasayfa");
                    }
                }
            }
            return View(objUser);
        }

        public ActionResult Anasayfa()
        {
            return View();
        }
    }
}