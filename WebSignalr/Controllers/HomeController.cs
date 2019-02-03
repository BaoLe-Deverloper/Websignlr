using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebSignalr.Models;

namespace WebSignalr.Controllers
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
        [HttpGet]
        public ActionResult Login()
        {
           

            return View();
        }
        [HttpPost]
        public ActionResult Login(string email, string pass)
        {
            DataContext data = new DataContext();

            var acc = data.Accounts.SingleOrDefault(q => q.Account_Email == email);
            if(acc==null)
                return View();
            Session["user"] = acc;
            return RedirectToAction("Index");
        }
        
    }
}