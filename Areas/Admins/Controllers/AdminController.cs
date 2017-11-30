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
            //ViewBag.Type = model.PROPERTY_TYPE.ToList();
            var product = model.PROPERTies.Where(x => x.USER.ID == id).ToList();
            return View(product);
        }
        public ActionResult Create()
        {
            ReadList();
            return View();
        }
        public class XulyModels
        {
            Team33Entities db = new Team33Entities();
            public long Insert(PROPERTY entytiy)
            {
                db.PROPERTies.Add(entytiy);
                db.SaveChanges();
                return entytiy.ID;
            }
        }
        [HttpPost]
     
        public ActionResult Create(PROPERTY pROPERTY, List<HttpPostedFileBase> files)
        {
            ReadList();
            var product = new PROPERTY();

            try
            {

                string filename = Path.GetFileNameWithoutExtension(pROPERTY.AvatarFile.FileName);
                string extension = Path.GetExtension(pROPERTY.AvatarFile.FileName);
                filename = filename + "checkcheck" + DateTime.Now.ToString("yymmssfff") + extension;
                pROPERTY.Avatar = filename;
                filename = Path.Combine(Server.MapPath("~/Images"), filename);
                // Avatar

                if (Path.GetFileNameWithoutExtension(pROPERTY.AvatarFile.FileName) == null)
                {
                    string s2 = "~/Images/ImagesNull.png";
                    pROPERTY.AvatarFile.SaveAs(s2);
                    //property.ImageFile2.SaveAs(filename2);
                }
                else
                {
                    //property.ImageFile2.SaveAs(filename2);
                    pROPERTY.AvatarFile.SaveAs(filename);
                }

                pROPERTY.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                var model = new XulyModels();
                if (ModelState.IsValid)
                {
                    long id = model.Insert(pROPERTY);
                    var path = "";
                    foreach (var item in files)
                    {
                        if (item != null)
                        {
                            if (item.ContentLength > 0)
                            {
                                if (Path.GetExtension(item.FileName).ToLower() == ".jpg"
                                    || Path.GetExtension(item.FileName).ToLower() == ".png"
                                    || Path.GetExtension(item.FileName).ToLower() == ".gif"
                                    || Path.GetExtension(item.FileName).ToLower() == ".jpeg")
                                {
                                    var path0 = id + item.FileName;
                                    path = Path.Combine(Server.MapPath("~/MultiImages"), path0);

                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }
                    if (id > 0)
                    {
                        return RedirectToAction("Index", "Agency");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create khong thanh cong");
                    }
                }


            }
            catch
            {

            }


            return View(pROPERTY);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var product = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.Type = model.PROPERTY_TYPE.ToList();
            ReadList();
            return View(product);
        }
        public ActionResult Delete(int id)
        {
            var db = model.PROPERTies.Find(id);
            model.PROPERTies.Remove(db);
            model.SaveChanges();
            int ID = id;
            return RedirectToAction("Index", "Agency", new { id= ID});
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
            return RedirectToAction("Details","Home", new { id = ID});

        }
        
            
        
   }

}
