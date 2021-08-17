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
    public class SubCommentController : Controller
    {
        private SimpleCMSContext db = new SimpleCMSContext();

        // GET: Admin/SubComment
        public ActionResult Index()
        {
            var subComments = db.SubComments.Include(s => s.MainComment).Include(s => s.Post).Include(s => s.User);
            return View(subComments.ToList());
        }

        // GET: Admin/SubComment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubComment subComment = db.SubComments.Find(id);
            if (subComment == null)
            {
                return HttpNotFound();
            }
            return View(subComment);
        }

        // GET: Admin/SubComment/Create
        public ActionResult Create()
        {
            ViewBag.MainCommentId = new SelectList(db.Comments, "CommentId", "Title");
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Title");
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName");
            return View();
        }

        // POST: Admin/SubComment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubCommentId,UserId,PostId,Title,Text,DateCreated,MainCommentId")] SubComment subComment)
        {
            if (ModelState.IsValid)
            {
                db.SubComments.Add(subComment);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MainCommentId = new SelectList(db.Comments, "CommentId", "Title", subComment.MainCommentId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Title", subComment.PostId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", subComment.UserId);
            return View(subComment);
        }

        // GET: Admin/SubComment/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubComment subComment = db.SubComments.Find(id);
            if (subComment == null)
            {
                return HttpNotFound();
            }
            ViewBag.MainCommentId = new SelectList(db.Comments, "CommentId", "Title", subComment.MainCommentId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Title", subComment.PostId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", subComment.UserId);
            return View(subComment);
        }

        // POST: Admin/SubComment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubCommentId,UserId,PostId,Title,Text,DateCreated,MainCommentId")] SubComment subComment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subComment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MainCommentId = new SelectList(db.Comments, "CommentId", "Title", subComment.MainCommentId);
            ViewBag.PostId = new SelectList(db.Posts, "PostId", "Title", subComment.PostId);
            ViewBag.UserId = new SelectList(db.Users, "UserId", "FirstName", subComment.UserId);
            return View(subComment);
        }

        // GET: Admin/SubComment/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubComment subComment = db.SubComments.Find(id);
            if (subComment == null)
            {
                return HttpNotFound();
            }
            return View(subComment);
        }

        // POST: Admin/SubComment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubComment subComment = db.SubComments.Find(id);
            db.SubComments.Remove(subComment);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
