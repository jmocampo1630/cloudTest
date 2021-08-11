using cloudTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cloudTest.Controllers
{
    public class HomeController : Controller
    {
        //serves as DB
        public static List<Discussion> Discussions = new List<Discussion>();

        public static string user;
        
        public HomeController() {
            if (Discussions.Count() <= 0) Discussions.Add(new Discussion
            {
                ID = Discussions.Count() + 1,
                Observer = "Mike",
                Date = DateTime.Now,
                Subject = "Sample Discussion",
                Coleague = "John, joe, jeff",
                Location = "Somewhere",
                Outcome = "Sample Discussion Outcome",
                CreatedBy = "Mike",
            });
        }
        public ActionResult Index()
        {
            if (string.IsNullOrEmpty(user)) return View("SignIn");
            return View(Discussions.Where(x => x.CreatedBy.ToLower() == user.ToLower()).ToList());
        }
        public ActionResult SignIn(SignInDto data)
        {
            if (!ModelState.IsValid) return View("SignIn");
            user = data.User;
            return Redirect("Index");
        }
        public ActionResult Logout()
        {
            user = null;
            return Redirect("Index");
        }
        public ActionResult ViewDetails(Discussion discussion)
        {
            return View("AddDiscussion", discussion);
        }
        [HttpGet]
        public ActionResult AddDiscussion()
        {
            if (string.IsNullOrEmpty(user)) return View("SignIn");
            return View();
        }
        [HttpPost]
        public ActionResult SaveDiscussion(Discussion discussion)
        {
            var saveData = Discussions.FirstOrDefault(x => x.ID == discussion.ID);
            if (saveData != null)
            {
                saveData.Observer = discussion.Observer;
                saveData.Subject = discussion.Subject;
                saveData.Coleague = discussion.Coleague;
                saveData.Location = discussion.Location;
                saveData.Outcome = discussion.Outcome;
            } 
            else
            {
                Discussions.Add(new Discussion
                {
                    ID = Discussions.Count() + 1,
                    Observer = discussion.Observer,
                    Date = discussion.Date,
                    Subject = discussion.Subject,
                    Coleague = discussion.Coleague,
                    Location = discussion.Location,
                    Outcome = discussion.Outcome,
                    CreatedBy = user,
                });
            }
            
            return Redirect("Index");
        }
    }
}