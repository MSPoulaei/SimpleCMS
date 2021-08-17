using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCMS.DataLayer;
namespace SimpleCMS.Controllers
{
    public class CategoryController : Controller
    {
        SimpleCMSContext db = new SimpleCMSContext();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return PartialView(db.Categories.ToList());
        }
    }
}