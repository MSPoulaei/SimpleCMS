using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCMS.DataLayer;

namespace SimpleCMS.Controllers
{
    public class CommentController : Controller
    {
        IGenericRepository<Comment> commentRepository;
        IGenericRepository<SubComment> subcommentRepository;
        SimpleCMSContext db;
        public CommentController()
        {
            db = new SimpleCMSContext();
            commentRepository = new GenericRepository<Comment>(db);
            subcommentRepository = new GenericRepository<SubComment>(db);
        }
        // GET: Comment
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ShowComments(int id)
        {
            ViewBag.PersianCalendar = true;
            return PartialView(db.Comments.Where(c => c.PostId == id));
        }
        public ActionResult AddComment(int id,string name,string email,string subject, string message)
        {
            Comment newComment = new Comment()
            {
                Name = name,
                Email = email,
                Title = subject,
                Text = message,
                IsAnonymous = true,
                PostId = id,
                DateCreated = DateTime.Now,
                UserId = 2
            };
            commentRepository.Insert(newComment);
            commentRepository.Save();
            ViewBag.PersianCalendar = true;
            return PartialView("ShowComments", db.Comments.Where(c => c.PostId == id));
        }
        
        public ActionResult AddSubComment(int id,string name,string email,string subject, string message,int maincommentId)
        {
            SubComment newSubComment = new SubComment()
            {
                Name = name,
                Email = email,
                Title = subject,
                Text = message,
                IsAnonymous = true,
                PostId = id,
                DateCreated = DateTime.Now,
                UserId = 2,
                MainCommentId=maincommentId
            };
            subcommentRepository.Insert(newSubComment);
            subcommentRepository.Save();
            ViewBag.PersianCalendar = true;
            return PartialView("ShowComments", db.Comments.Where(c => c.PostId == id));
        }
    }
}