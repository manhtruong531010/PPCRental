using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Website_BĐS.Models;
namespace Website_BĐS.Areas.Agency.Controllers
{
    public class AgencyController : Controller
    {
        Team33Entities model = new Team33Entities();
        // GET: /Admin/ProductAdmin/
        public ActionResult Index()
        {
            if (Session["userid"] != null)
            {
                var id = (int)Session["userid"];
                var user = model.PROPERTies.Where(x => x.USER.ID == id).ToList();
                return View(user);
            }
            else
            {
                return View();
            }
        }
    }
}