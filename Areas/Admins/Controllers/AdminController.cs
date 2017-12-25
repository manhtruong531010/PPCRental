﻿using System;
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
        public static int idd;
       Team33Entities model = new Team33Entities();
       public static int UserID;
        // GET: /Admin/ProductAdmin/
        public ActionResult Index()
        {
            var product = model.USERs.ToList();
            return View(product);
        }
        public ActionResult ViewProperty(int id)
        {
            //ViewBag.Type = model.PROPERTY_TYPE.ToList();
            UserID = id;
            idd = id;
            var product = model.PROPERTies.Where(x => x.USER.ID == id && x.Status_ID != 2 ).OrderByDescending(x => x.ID).ToList();
            return View(product);
        }
        public ActionResult ViewListallProperty()
        {
            var product = model.PROPERTies.Where(x => x.Status_ID != 2).OrderByDescending(x => x.ID).ToList();
            return View(product);
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

        public ActionResult Create(PROPERTY pROPERTY, List<HttpPostedFileBase> files, string submit)
        {
            //validate
            var checkName = model.PROPERTies.Where(x => x.PropertyName == pROPERTY.PropertyName).ToList();
            //validate
            if (pROPERTY.PropertyName == null)
            {
                ModelState.AddModelError("PropertyName", "PropertyName can't empty!");
            }
            else if (pROPERTY.PropertyName.Length > 150 || pROPERTY.PropertyName.Length < 5)
            {
                ModelState.AddModelError("PropertyName", "PropertyName must between 5 and 150");
            }
            else if (checkName.Count() > 0)
            {
                ModelState.AddModelError("PropertyName", "PropertyName is exist!");
            }
            //avatar
            //if (pROPERTY.ImageFile2 == null)
            //{
            //    ModelState.AddModelError("Avatar", "Avatar can't Empty!");
            //}
            ////image
            //if (pROPERTY.Images == null)
            //{
            //    ModelState.AddModelError("Images", "Images can't Empty!");
            //}
            //propertytype
            if (pROPERTY.PropertyType_ID == null)
            {
                ModelState.AddModelError("PropertyType", "PropertyType can't Empty!");
            }
            //content
            if (pROPERTY.Content == null)
            {
                ModelState.AddModelError("Content", "Content can't Empty!");
            }
            else if (pROPERTY.Content.Length > 150 || pROPERTY.Content.Length < 50)
            {
                ModelState.AddModelError("Content", "Content must between 50 and 150");
            }

            ////feature
            //if (pROPERTY.PROPERTY_FEATURE == null)
            //{
            //    ModelState.AddModelError("FEATURE", "FEATURE can't Empty!");
            //}
            //street
            if (pROPERTY.Street_ID == null)
            {
                ModelState.AddModelError("Street", "Street can't Empty!");
            }
            if (pROPERTY.Ward_ID == null)
            {
                ModelState.AddModelError("Ward", "Ward can't Empty!");
            }
            if (pROPERTY.District_ID == null)
            {
                ModelState.AddModelError("District", "District can't Empty!");
            }
            //price
            if (pROPERTY.Price == null)
            {
                ModelState.AddModelError("Price", "Price can't Empty!");
            }
            //?rea
            if (pROPERTY.Area == null)
            {
                ModelState.AddModelError("Area", "Area can't Empty!");
            }
            //bathroom
            if (pROPERTY.BathRoom == null)
            {
                ModelState.AddModelError("BathRoom", "BathRoom can't Empty!");
            }
            //bedroom
            if (pROPERTY.BedRoom == null)
            {
                ModelState.AddModelError("BedRoom", "BedRoom can't Empty!");
            }
            //packingplace
            if (pROPERTY.PackingPlace == null)
            {
                ModelState.AddModelError("PackingPlace", "PackingPlace can't Empty!");
            }
            idd = int.Parse(Session["userid"].ToString());
            ReadList();
            var ImagesName = "";

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
                }
                else
                {
                    pROPERTY.AvatarFile.SaveAs(filename);
                }

                pROPERTY.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                pROPERTY.Create_post = DateTime.Parse(DateTime.Now.ToShortDateString());
                pROPERTY.UnitPrice = "Vnd";
                pROPERTY.Status_ID = 3;
                pROPERTY.UserID = idd;
                pROPERTY.Sale_ID = idd;
                var modelCr = new XulyModels();
                if (ModelState.IsValid)
                {
                    long id = modelCr.Insert(pROPERTY);
                    var path = "";
                    var Features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var fea in Features)
                    {
                        var ids = int.Parse(fea.Split('_')[1]);
                        if (Request.Form[fea].StartsWith("true"))
                        {
                            model.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                            {
                                Property_ID = (int)id,
                                Feature_ID = ids
                            });
                        }
                    }
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
                                    if (ImagesName != "")
                                    {
                                        ImagesName = ImagesName + "," + (string)path0;
                                    }
                                    else
                                    {
                                        ImagesName = (string)path0;
                                    }
                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }
                    var proAddImage = model.PROPERTies.FirstOrDefault(x => x.ID == id);
                    proAddImage.Images = (string)ImagesName;
                    model.SaveChanges();
                    if (id > 0)
                    {
                        return RedirectToAction("ViewListallProperty", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create khong thanh cong");
                    }
                }

            }
            catch (NullReferenceException)
            {
                pROPERTY.Created_at = DateTime.Parse(DateTime.Now.ToShortDateString());
                pROPERTY.Create_post = DateTime.Parse(DateTime.Now.ToShortDateString());
                pROPERTY.Status_ID = 3;
                pROPERTY.UserID = idd;
                pROPERTY.Sale_ID = idd;
                var modelCr = new XulyModels();
                if (ModelState.IsValid)
                {
                    long id = modelCr.Insert(pROPERTY);
                    var path = "";
                    var Features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
                    foreach (var fea in Features)
                    {
                        var ids = int.Parse(fea.Split('_')[1]);
                        if (Request.Form[fea].StartsWith("true"))
                        {
                            model.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                            {
                                Property_ID = (int)id,
                                Feature_ID = ids
                            });
                        }
                    }
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
                                    if (ImagesName != "")
                                    {
                                        ImagesName = ImagesName + "," + (string)path0;
                                    }
                                    else
                                    {
                                        ImagesName = (string)path0;
                                    }
                                    item.SaveAs(path);
                                    ViewBag.UploadSuccess = true;

                                }
                            }
                        }
                    }
                    var proAddImage = model.PROPERTies.FirstOrDefault(x => x.ID == id);
                    proAddImage.Images = (string)ImagesName;
                    model.SaveChanges();
                    if (id > 0)
                    {
                        return RedirectToAction("ViewListallProperty", "Admin");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Create khong thanh cong");
                    }
                }
            }
            //return RedirectToAction("ViewListallProperty", "Admin");
            return View();
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
            var fedb = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id).ToList();
            foreach (var feitem in fedb)
            {
                model.PROPERTY_FEATURE.Remove(feitem);

            }
            model.SaveChanges();
            return RedirectToAction("ViewListallProperty", "Admin");
        }
        public void ReadList()
        {
            ViewBag.ptype = model.PROPERTY_TYPE.OrderByDescending(x => x.ID).ToList();
            ViewBag.ward = model.WARDs.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.district = model.DISTRICTs.OrderByDescending(x => x.ID).Where(y => y.ID >= 31 && y.ID <= 54).ToList();
            ViewBag.street = model.STREETs.OrderByDescending(x => x.ID).Where(y => y.District_ID >= 31 && y.District_ID <= 54).ToList();
            ViewBag.status = model.PROJECT_STATUS.OrderByDescending(x => x.ID).ToList();
            ViewBag.Feature_ID = model.FEATUREs.ToList();


        }
        private string UpIma(PROPERTY p)
        {
            string filename;
            string extension;
            string s = "";
            string b;
            foreach (var file in p.MultiImage)
            {
                if (file != null)
                {
                    filename = Path.GetFileNameWithoutExtension(file.FileName);
                    extension = Path.GetExtension(file.FileName);
                    filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                    p.Images = filename;
                    b = p.Images;
                    if (s == "")
                    {
                        s = b;
                    }
                    else
                    {
                        s = s + "," + b;
                    }
                    //s = string.Concat(s, b, ",");
                    filename = Path.Combine(Server.MapPath("~/MultiImages"), filename);
                    file.SaveAs(filename);
                }
            }
            return s;
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
            //Edit Multiimage
            if (UpIma(p) != "")
            {
                PROPERTY.Images = UpIma(p);
            }
            //Edit Feature
            var Features = Request.Form.AllKeys.Where(k => k.StartsWith("Feature_"));
            foreach (var fea in Features)
            {
                var ids = int.Parse(fea.Split('_')[1]);
                if (Request.Form[fea].StartsWith("true"))
                {
                    var feIDcheck = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id && x.Feature_ID == ids).ToList();
                    if (feIDcheck.Count() == 0)
                    {
                        model.PROPERTY_FEATURE.Add(new PROPERTY_FEATURE
                        {
                            Property_ID = (int)id,
                            Feature_ID = ids
                        });
                    }

                }
                else
                {
                    var feIDdb = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id && x.Feature_ID == ids).ToList();
                    foreach (var feitem in feIDdb)
                    {
                        model.PROPERTY_FEATURE.Remove(feitem);

                    }
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
            PROPERTY.UnitPrice = "Vnd";
            PROPERTY.Area = p.Area;
            PROPERTY.BedRoom = p.BedRoom;
            PROPERTY.BathRoom = p.BathRoom;
            PROPERTY.PackingPlace = p.PackingPlace;
            PROPERTY.Status_ID = p.Status_ID;
            PROPERTY.Note = p.Note;
            PROPERTY.Updated_at = DateTime.Now;
            PROPERTY.Sale_ID = int.Parse(Session["userid"].ToString());

            model.SaveChanges();
            return RedirectToAction("ViewListallProperty", "Admin");

        }
       
        public ActionResult Details(int id)
        {
            int ID = id;
            var project = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultiImages"))
                            .Select(fn => "~/MultiImages/" + Path.GetFileName(fn));
            ViewBag.features = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id).ToList();
            ViewBag.Countt = model.PROPERTY_FEATURE.Where(x => x.Property_ID == id).Count();
            ViewBag.fea = model.FEATUREs.ToList();
            return View(project);

        }

        public ActionResult CreatePropertyType()
        {
            PROPERTY_TYPE cre = new PROPERTY_TYPE();
            return View(cre);
        }
        [HttpPost]
        public ActionResult CreatePropertyType(PROPERTY_TYPE p)
        {
            ReadList();
            PROPERTY_TYPE cre = new PROPERTY_TYPE();
            cre.ID = p.ID;
            cre.CodeType = p.CodeType;
            cre.Description = p.Description;
            cre.Status = p.Status;
            var test = model.PROPERTY_TYPE.Where(x => x.CodeType == cre.CodeType && x.Description == cre.Description);
            if (test.Count() == 0)
            {

                model.PROPERTY_TYPE.Add(cre);
                model.SaveChanges();
                return RedirectToAction("Index1", new { p.ID });
            }
            else
            {
                ViewBag.CreateError = "Đã tồn tại";
                return View(cre);
            }

        }

        [HttpGet]
        public ActionResult EditPropetyType(int id)
        {
            var product = model.PROPERTY_TYPE.FirstOrDefault(x => x.ID == id);
            ViewBag.Type = model.PROPERTY_TYPE.ToList();
            ReadList();
            return View(product);
        }
        [HttpPost]
        public ActionResult EditPropetyType(int id, PROPERTY_TYPE p)
        {
            ReadList();
            var en = model.PROPERTY_TYPE.Find(p.ID);
            var Type = model.PROPERTY_TYPE.FirstOrDefault(x => x.ID == id);

            Type.ID = p.ID;
            Type.CodeType = p.CodeType;
            Type.Description = p.Description;
            Type.Status = p.Status;
            model.SaveChanges();
            int ID = id;
            return RedirectToAction("Index1", new { id = ID });

        }
   }

}
