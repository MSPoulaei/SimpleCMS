using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCMS.DataLayer;

namespace SimpleCMS.Controllers
{
    public class AuthorController : Controller
    {
        IGenericRepository<Author> authorRepository;
        SimpleCMSContext db;
        public AuthorController()
        {
            db = new SimpleCMSContext();
            authorRepository = new GenericRepository<Author>(db);
        }
        // GET: Author
        public ActionResult Index()
        {
            return View();
        }
        [Route("author/{id}")]
        public ActionResult AuthorPosts(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            return View("Index", authorRepository.GetById(id.Value).Posts);
        }
    }
}