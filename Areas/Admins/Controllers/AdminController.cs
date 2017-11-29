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
        public ActionResult Edit(int id)
        {
            var product = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.Type = model.PROPERTY_TYPE.ToList();
            ReadList();
            return View(product);
        }
        public void ReadList()
        {
            ViewBag.ptype = model.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.ward = model.WARDs.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.district = model.DISTRICTs.OrderByDescending(x => x.ID).Where(y => y.ID >= 31 && y.ID <= 54).ToList();
            ViewBag.street = model.STREETs.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.status = model.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();

        }

        [HttpPost]
        public ActionResult Edit(int id, PROPERTY p)
        {
            ReadList();
            var en = model.PROPERTies.Find(p.ID);

            //single image
            var PROPERTY = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.Type = model.PROPERTY_TYPE.ToList();
            if (p.AvatarFile != null && p.AvatarFile.ContentLength > 0)
            {
                if(Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".jpg"
                    || Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".png"
                    || Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".gif"
                    || Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".jpeg")
               {
                string filename = Path.GetFileNameWithoutExtension(p.AvatarFile.FileName);
                string extention = Path.GetExtension(p.AvatarFile.FileName);

                filename = filename + DateTime.Now.ToString("yymmfff") + extention;
                p.Avatar = filename;

                filename = Path.Combine(Server.MapPath("~/Images"), filename);

                p.AvatarFile.SaveAs(filename);
                PROPERTY.Avatar = p.Avatar;
            }
            }

            PROPERTY.ID = p.ID;
            PROPERTY.PropertyName = p.PropertyName;
            PROPERTY.PropertyType_ID = p.PropertyType_ID;
            PROPERTY.Content = p.Content;
            PROPERTY.Street_ID = p.Street_ID;
            PROPERTY.WARD = p.WARD;
            PROPERTY.District_ID = p.District_ID;
            PROPERTY.Price = p.Price;
            PROPERTY.UnitPrice = p.UnitPrice;
            PROPERTY.Area = p.Area;
            PROPERTY.BedRoom = p.BedRoom;
            PROPERTY.BathRoom = p.BathRoom;
            PROPERTY.PackingPlace = p.PackingPlace;
            PROPERTY.UserID = p.UserID;
            PROPERTY.Status_ID = p.Status_ID;
            PROPERTY.Note = p.Note;
            PROPERTY.Updated_at = DateTime.Now;
            PROPERTY.Sale_ID = p.Sale_ID;

            model.SaveChanges();
            int ID = id;
            return RedirectToAction("ViewProperty", "Admin", new { id = ID});

        }
       
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
