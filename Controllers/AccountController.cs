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
        public ActionResult RegisterAccount()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
                //kiem tra da kich hoat
            if (Session["userrole"]==null)
                {
                    return RedirectToAction("Login", "Account");
                }
                if (  int.Parse(Session["userrole"].ToString()) == 0)
                {
                  
                    return RedirectToAction("Index", "Admins/Admin");
                }
                else 
                {
                    return RedirectToAction("Index", "Agency/Agency", new { userid = int.Parse(Session["userid"].ToString()) });
                }
               

               
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
                        return RedirectToAction("Index", "Agency/Agency", new { userid = userdetail.ID });
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
            return Redirect("/");
        }

        	 [HttpGet]
        public ActionResult ChangePassword()
        {
            int id = int.Parse(Session["userid"].ToString());
            var userdetail = db.USERs.Where(x => x.ID == id);
            return View();
        }

        [HttpPost]
        public ActionResult ChangePassword(string oldpass, string newpass, string conpass)
        {
            int id = int.Parse(Session["userid"].ToString());
            var userdetail = db.USERs.Find(id);
            if (userdetail.ID == id)
            {
                if (userdetail.Password == oldpass)
                {
                    if (newpass == conpass)
                    {
                        userdetail.Password = newpass;
                        db.SaveChanges();
                        ViewBag.mess = "success";
                        return View("Index");
                    }
                    ViewBag.mess = "mat khau xac nhan khong dung";
                }
                ViewBag.mess = "mat khau cu khong dung";
            }
            return RedirectToAction("Index", "Agency", new { userid = int.Parse(Session["userid"].ToString())});
        }

    }
}
