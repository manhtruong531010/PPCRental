using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Web.Mvc;
using Website_BĐS.Models;
namespace Website_BĐS.Areas.Admins.Controllers
{

    public class AdminController : Controller
    {
       Team33Entities model = new Team33Entities();
        // GET: /Admin/ProductAdmin/
        public ActionResult Index()
        {
            var product = model.USERs.ToList();
            return View(product);
        }
        public ActionResult ViewProperty(int id)
        {
            ViewBag.Type = model.PROPERTY_TYPE.ToList();
            var product = model.PROPERTies.ToList();
            return View(product);
        }
        [HttpGet]

       
        public ActionResult Details(int id)
        {
            int ID = id;
            return RedirectToAction("Details","Admin", new { id = ID});

        }
        [HttpGet]
       public ActionResult CreateNew()
        { 
            return View();
        }
      [HttpPost]
        public ActionResult CreateNew(PROPERTY p)
        {
            //if(ModelState.IsValid){
            //    model.PROPERTY.Add(p);
            //    model.SaveChanges();
            //    //if (p.AvatarFile != null && p.AvatarFile.ContentLength > 0)
            //    //{
            //    //    if (Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".jpg"
            //    //        || Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".png"
            //    //        || Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".gif"
            //    //        || Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".jpeg")
            //    //    {
            //    //        string filename = Path.GetFileNameWithoutExtension(p.AvatarFile.FileName);
            //    //        string extention = Path.GetExtension(p.AvatarFile.FileName);

            //    //        filename = filename + DateTime.Now.ToString("yymmfff") + extention;
            //    //        p.Avatar = filename;

            //    //        filename = Path.Combine(Server.MapPath("~/Images"), filename);

            //    //        p.AvatarFile.SaveAs(filename);
                       
            //        }
         
            //    return View(p);
            if (ModelState.IsValid)
            {
                model.PROPERTies.Add(p);
                model.SaveChanges();

                return RedirectToAction("ViewProperty", "Admin");
            }
            else
            {
                return View(p);
            }
        }
   }

}
