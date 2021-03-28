using Networking312190796_318855038.DalFolder;
using Networking312190796_318855038.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Networking312190796_318855038.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Submit()
        {
            Dal dal = new Dal();
            string searchID = Request.Form["uname"].ToString();
            string searchPassword = Request.Form["password"].ToString();
            List<Users> user = (from x in dal.users where x.ID.Contains(searchID) && x.password.Contains(searchPassword) select x).ToList<Users>();
            if(user.Count==0)
            {
                @Session["Result"] = "No User Found!";
                return View("login");
            }
            if (user[0].role.Equals("User"))
            {
                return View("../Users/HomePage");
            }
            if (user[0].role.Equals("Admin"))
            {
                return View("../Admin/HomePage");
            }
            return View("login");
        }
        public ActionResult Login()
        {
            Session["login"] = "ok";
            return View("login");
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
}