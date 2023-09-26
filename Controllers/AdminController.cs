using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace HalisElektronik.Controllers
{
    
    public class AdminController : Controller
    {
        [HttpGet]
        public ActionResult Index(string adminuser,string adminpassword)
        {
            HalisElektronikEntities DbAdmin = new HalisElektronikEntities();
            var adminusers = DbAdmin.AdminUsers.FirstOrDefault(x=>x.AdminUserName == adminuser && x.AdminPassword == adminpassword);
            if (adminusers == null)
            { return RedirectToAction("Index","Login"); }
            else
            {
                FormsAuthentication.SetAuthCookie(adminusers.AdminUserName, true);
                Session["AdminUserName"] = adminusers.AdminUserName;
                return RedirectToAction("AdminIndex");
            }
        }
        [Authorize]
        public ActionResult AdminIndex()
        {
            return View();
        }
        //[Authorize]
        //public ActionResult AdminIndex()
        //{
        //    return View();
        //}

        // GET: Admin/Details/5
        //[Authorize]
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        //// GET: Admin/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Admin/Create
        //[HttpPost]
        //public ActionResult Create(FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add insert logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Admin/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/Edit/5
        //[HttpPost]
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add update logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: Admin/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: Admin/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
