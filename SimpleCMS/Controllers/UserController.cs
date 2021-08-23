using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleCMS.DataLayer;
using System.Web.Security;
namespace SimpleCMS.Controllers
{
    public class UserController : Controller
    {
        SimpleCMSContext db;
        IGenericRepository<User> userRepository;
        public UserController()
        {
            db = new SimpleCMSContext();
            userRepository = new GenericRepository<User>(db);
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel newUser,string RedirectTo="/")
        {
            if (ModelState.IsValid)
            {
                if (db.Users.Any(u => u.UserName == newUser.UserName && u.Password == newUser.Password)) { 
                    FormsAuthentication.SetAuthCookie("simplecms",newUser.RememberMe);
                    return Redirect(RedirectTo);
            }}
            else
            {
                ModelState.AddModelError("UserName", "Not Found");

            }
            return View(newUser);
        }
    }
}