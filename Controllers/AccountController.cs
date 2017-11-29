using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BĐS.Models;

namespace Website_BĐS.Controllers
{
    public class AccountController : Controller
    {
        Team33Entities db = new Team33Entities();
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string email, string password) 
        {

            var userdetail = db.USERs.Where(x => x.Email.Equals(email)).FirstOrDefault();
            if (userdetail != null)
            {
                //kiem tra password
                if (userdetail.Password.Equals(password))
                {
                    //kiem tra da kich hoat
                    if (userdetail.Status == true && int.Parse(userdetail.Role) == 0) 
                    {
                        Session["username"] = userdetail.FullName;
                        Session["userrole"] = userdetail.Role;
                        Session["userid"] = userdetail.ID;
                        return RedirectToAction("Index", "Admins/Admin");
                    }
                    else if(userdetail.Status == true && int.Parse(userdetail.Role) == 1)
                    {
                        Session["username"] = userdetail.FullName;
                        Session["userrole"] = userdetail.Role;
                        Session["userid"] = userdetail.ID;
                        return RedirectToAction("Index", "Agency/Agency");
                    }
                }
            }
            return View();
            
        }

        public ActionResult Logout() 
        {
            Session["username"] = null;
            Session["userrole"] = null;
            Session["userid"] = null;
            return RedirectToAction("Login", "Account");
        }
	}
}