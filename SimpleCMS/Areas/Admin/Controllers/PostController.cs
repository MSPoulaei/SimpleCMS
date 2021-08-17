using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SimpleCMS.DataLayer;

namespace SimpleCMS.Areas.Admin.Controllers
{
    public class PostController : Controller
    {
        private SimpleCMSContext db;
        IGenericRepository<Post> PostRepository;
        public PostController()
        {
            db = new SimpleCMSContext();
            PostRepository = new GenericRepository<Post>(db);
        }
        // GET: Admin/Posts
        public ActionResult Index()
        {
            var posts = db.Posts.Include(p => p.Author);
            return View(posts.ToList());
        }

        // GET: Admin/Posts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = PostRepository.GetById(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // GET: Admin/Posts/Create
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorId");
            return View();
        }

        // POST: Admin/Posts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PostId,AuthorId,Title,Description,Text,VisitsCount,ImageName,DateCreated")] Post post)
        {
            if (ModelState.IsValid)
            {
                //db.Posts.Add(post);
                //db.SaveChanges();
                PostRepository.Insert(post);
                PostRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorId", post.AuthorId);
            return View(post);
        }

        // GET: Admin/Posts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = PostRepository.GetById(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorId", post.AuthorId);
            return View(post);
        }

        // POST: Admin/Posts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PostId,CategoryId,AuthorId,Title,Description,Text,VisitsCount,ImageName,DateCreated,Tags")] Post post)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(post).State = EntityState.Modified;
                //db.SaveChanges();
                PostRepository.Update(post);
                PostRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "AuthorId", post.AuthorId);
            return View(post);
        }

        // GET: Admin/Posts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Post post = PostRepository.GetById(id.Value);
            if (post == null)
            {
                return HttpNotFound();
            }
            return View(post);
        }

        // POST: Admin/Posts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //Post post = PostRepository.GetById(id);
            //db.Posts.Remove(post);
            //db.SaveChanges();
            PostRepository.Delete(id);
            PostRepository.Save();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                PostRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
