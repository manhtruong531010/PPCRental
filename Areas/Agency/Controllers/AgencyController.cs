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
        public static int idd;
        Team33Entities model = new Team33Entities();
        // GET: /Admin/ProductAdmin/
        public ActionResult Index(int? userid)
        {
            if (Session["userid"] != null)
            {
                idd = int.Parse(Session["userid"].ToString());
                var user = model.PROPERTies.Where(x => x.UserID == userid).OrderByDescending(x => x.ID).ToList();
                return View(user);
            }
            else
            {
                return View();
            }
        }
        public JsonResult GetStreet(int did)
        {
            var db = new Team33Entities();
            var streets = db.STREETs.Where(s => s.District_ID == did);
            return Json(streets.Select(s => new
            {
                id = s.ID,
                text = s.StreetName
            }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetWard(int did)
        {
            var db = new Team33Entities();
            var wards = db.WARDs.Where(s => s.District_ID == did);
            return Json(wards.Select(s => new
            {
                id = s.ID,
                text = s.WardName
            }), JsonRequestBehavior.AllowGet);
        }
        public ActionResult DetailsAgency(int id)
        {
            int ID = id;
            var project = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultiImages"))
                            .Select(fn => "~/MultiImages/" + Path.GetFileName(fn));
            //return RedirectToAction("DetailsAgency", "Agency", new { id = ID });
            return View(project);
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
        public ActionResult Edit(int id, int StaId)
        {
            if (StaId == 2)
            {
            var product = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.Type = model.PROPERTY_TYPE.ToList();
            ReadList();
            return View(product);
            }
            else
            {
                return RedirectToAction("Index","Agency", new { userid = idd});
            }
       
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
        public ActionResult Edit(int id, PROPERTY p, string submit)
        {
            int ID = id;
           
                ReadList();
                var en = model.PROPERTies.Find(p.ID);

                //single image
                var PROPERTY = model.PROPERTies.FirstOrDefault(x => x.ID == id);
                ViewBag.Type = model.PROPERTY_TYPE.ToList();
                if (p.AvatarFile != null && p.AvatarFile.ContentLength > 0)
                {
                    if (Path.GetExtension(p.AvatarFile.FileName).ToLower() == ".jpg"
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
                PROPERTY.Ward_ID = p.Ward_ID;
                PROPERTY.District_ID = p.District_ID;
                PROPERTY.Price = p.Price;
                PROPERTY.Area = p.Area;
                PROPERTY.BedRoom = p.BedRoom;
                PROPERTY.BathRoom = p.BathRoom;
                PROPERTY.PackingPlace = p.PackingPlace;
                if (submit == "Post") 
                {
                    PROPERTY.Status_ID = 1;
                }
                else if (submit == "Draf") 
                {
                    PROPERTY.Status_ID = 2;
                }
                
                PROPERTY.Note = p.Note;
                model.SaveChanges();
                return RedirectToAction("Index", "Agency", new { userid = idd });


            
        }
        public ActionResult Delete(int id)
        {
            var db = model.PROPERTies.Find(id);
            model.PROPERTies.Remove(db);
            model.SaveChanges();
            return RedirectToAction("Index", "Agency", new { userid = idd });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PROPERTY pROPERTY, List<HttpPostedFileBase> files, string submit)
        {
            ReadList();
           
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
                pROPERTY.Create_post = DateTime.Parse(DateTime.Now.ToShortDateString());
                pROPERTY.UnitPrice = "Vnd";

                if (submit == "Post")
                {
                    pROPERTY.Status_ID = 1;
                }
                else if (submit == "Draf")
                {
                    pROPERTY.Status_ID = 2;
                }
                
                pROPERTY.UserID = idd;
                var modelCr = new XulyModels();
                if (ModelState.IsValid)
                {
                    long id = modelCr.Insert(pROPERTY);
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
                        return RedirectToAction("Index", "Agency", new { userid = idd });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create khong thanh cong");
                    }
                }


            }
            catch
            {
                pROPERTY.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                pROPERTY.Create_post = DateTime.Parse(DateTime.Now.ToShortDateString());

                if (submit == "Post")
                {
                    pROPERTY.Status_ID = 1;
                }
                else if (submit == "Draf")
                {
                    pROPERTY.Status_ID = 2;
                }

                pROPERTY.UserID = idd;
                var modelCr = new XulyModels();
                if (ModelState.IsValid)
                {
                    long id = modelCr.Insert(pROPERTY);
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
                        return RedirectToAction("Index", "Agency", new { userid = idd });
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create khong thanh cong");
                    }
                }
            }
          
            return RedirectToAction("Index", "Agency", new { userid = idd });
        }
    }
}
