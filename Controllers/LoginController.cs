using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HalisElektronik.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string adminuser, string adminpassword)
        {
            if (String.IsNullOrEmpty(adminuser) || String.IsNullOrEmpty(adminpassword))
            { return RedirectToAction("Index"); }
            else
            {
                return RedirectToAction("Index", "Admin", new {adminuser,adminpassword});
            }
        }
    }
}