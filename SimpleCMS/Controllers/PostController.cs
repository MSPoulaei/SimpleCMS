using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleCMS.DataLayer;

namespace SimpleCMS.Controllers
{
    public class PostController : Controller
    {
        SimpleCMSContext context;
        IGenericRepository<Post> PostRepository;
        public PostController()
        {
            context = new SimpleCMSContext();
            PostRepository = new GenericRepository<Post>(context);
        }
        // GET: Post
        [Route("Post/{id}")]
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var post = PostRepository.GetById(id.Value);
            if (post == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound);
            }
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
            switch (System.Globalization.CultureInfo.CurrentCulture.Name)
            {
                case "fa-IR"://farsi
                case "af"://Afghanistan
                    ViewBag.PersianCalendar = true;//Shamsi
                    break;
                default:
                    ViewBag.PersianCalendar = false;
                    break;

            }
            ViewBag.ShowDescriptionInPost = true;
            post.VisitsCount += 1;
            PostRepository.Update(post);
            PostRepository.Save();
            return View(post);
        }
        [ChildActionOnly]
        public ActionResult RelatedPosts()
        {
            return PartialView(PostRepository.GetAll());
        }
        [Route("Search")]
        public ActionResult Search(string q)
        {
            return View("~/Views/Shared/Index.cshtml", context.Posts.Where(p =>
                p.Title.Contains(q) ||
                p.Description.Contains(q) ||
                p.Author.User.FirstName.Contains(q) ||
                p.Author.User.LastName.Contains(q) ||
                p.Tags.Contains(q)
            ).Select(p=>p));
        }
    }
}