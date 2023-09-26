using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace HalisElektronik.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        HalisElektronikEntities DbContext = new HalisElektronikEntities();
        public ActionResult Index()
        {
            //foreach (var item in DbContext.Category)
            //{
            //    var result = item.CategoryImage.CategoryImg_Title
            //}
            return View(DbContext);
        }
        [HttpGet]
        public ActionResult Index(string search)
        {
            if (String.IsNullOrEmpty(search))
            {
                return Index();
            }
            else
            {
                return View(DbContext.Cards.Where(e => 
                    e.Title.Contains(search)||
                    e.Barcode.Contains(search) || 
                    e.Description.Contains(search)||
                    e.ImgSrc.Title.Contains(search)).ToList());
            }
        }
        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View(DbContext.Cards.Where(e => e.CardsId == id).SingleOrDefault());
        }
        [ChildActionOnly]
        public PartialViewResult _cards()
        {
            return PartialView("_cards");
        }
        [ChildActionOnly]
        public PartialViewResult _noncards()
        {
            return PartialView("_noncards");
        }
    }
}
