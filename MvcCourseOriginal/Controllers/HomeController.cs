using MvcCourseOriginal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCourseOriginal.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Signin()
        {
            return View();
        }


        DB_SiteEntities db = new DB_SiteEntities();

        [HttpPost]
        public ActionResult Register(Registration user)
        {
            try
            {
                db.Registrations.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            catch 
            {

                return View();
            }

        }


        [HttpPost]
        public ActionResult Signin(Registration user)
        {
            bool result = IsValid(user.EMAIL, user.PASSWORD);

            if (result)
            {
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.message = "Login is Failed !";

            }
            return View(user);

        }

        private bool IsValid(string email,string pass)
        {
            bool IsValid = false;

            var user = db.Registrations.FirstOrDefault(o => o.EMAIL == email);

            if (user !=null)
            {
                if (user.PASSWORD==pass)
                {
                    IsValid = true;
                }
            }
            return IsValid;
        }

    }
}