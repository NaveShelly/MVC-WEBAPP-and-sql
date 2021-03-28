using Networking312190796_318855038.DalFolder;
using Networking312190796_318855038.Models;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Web.Mvc;

namespace Networking312190796_318855038.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Signup()
        {
            return View("Signup");
        }
        public ActionResult HomePage()
        {
            return View("HomePage");
        }
        public ActionResult Submit(Users tmp)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    tmp.role = "User";
                    Dal dal = new Dal();
                    dal.users.Add(tmp);
                    dal.SaveChanges();
                    Session["Result"] = "Register Complete!";
                }
                catch (DbUpdateException e)
                        when (e.InnerException?.InnerException is SqlException sqlEx &&
                           (sqlEx.Number == 2601 || sqlEx.Number == 2627))
                {
                    Session["Result"] = "There Was An Error try To Sign Up Agian!...";
                }
            }
            return View("../Home/index");
        }
        public ActionResult ShopingCart()
        {
            return View("ShopingCart");
        }
    }
}