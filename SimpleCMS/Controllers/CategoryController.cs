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
        [Route("cat/{id}")]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var subCat_list = db.Categories.Find(id).SubCategories;
            var posts = new HashSet<Post>();
            foreach (var subCat in subCat_list)
            {
                foreach (var post in subCat.Posts)
                {
                    posts.Add(post);
                }
            }
            return View("Index",posts);
        }
        [Route("subcat/{id}")]
        public ActionResult Subcat(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            var subCat_list = db.SubCategories;
            var posts = new HashSet<Post>();
            foreach (var subCat in subCat_list)
            {
                foreach (var post in subCat.Posts)
                {
                    posts.Add(post);
                }
            }
            return View("Index",posts);
        }
        public ActionResult List()
        {
            return PartialView(db.Categories.ToList());
        }
    }
}