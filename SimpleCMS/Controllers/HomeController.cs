using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCMS.DataLayer;

namespace SimpleCMS.Controllers
{
    public class HomeController : Controller
    {
        SimpleCMSContext context;
        IGenericRepository<Post> PostRepository;
        public HomeController()
        {
            context = new SimpleCMSContext();
            PostRepository = new GenericRepository<Post>(context);
        }
        public ActionResult Index()
        {
            return View(PostRepository.GetAll());
        }

        [Route("About")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        [Route("Contact")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}