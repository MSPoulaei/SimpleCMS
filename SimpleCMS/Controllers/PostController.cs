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
            //System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("fa-IR");
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
            return View(post);
        }
        [ChildActionOnly]
        public ActionResult RelatedPosts()
        {
            return PartialView(PostRepository.GetAll());
        }
    }
}