﻿using System;
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
                var user = model.PROPERTies.OrderBy(x => x.USER.ID == id).ToList();
                return View(user);
            }
            else
            {
                return View();
            }
        }
        public ActionResult Details(int id)
        {
            var project = model.PROPERTies.FirstOrDefault(x => x.ID == id);
            return RedirectToAction("Details","Agency");
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
            var IDUser = (int)Session["userid"];

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
            PROPERTY.WARD = p.WARD;
            PROPERTY.District_ID = p.District_ID;
            PROPERTY.Price = p.Price;

            PROPERTY.UnitPrice = p.UnitPrice;
            PROPERTY.Area = p.Area;
            PROPERTY.BedRoom = p.BedRoom;
            PROPERTY.BathRoom = p.BathRoom;
            PROPERTY.PackingPlace = p.PackingPlace;
            PROPERTY.UserID = IDUser;
            PROPERTY.Status_ID = p.Status_ID;
            PROPERTY.Note = p.Note;
            PROPERTY.Updated_at = DateTime.Now;
            PROPERTY.Sale_ID = p.Sale_ID;

            model.SaveChanges();
            int ID = id;
            return RedirectToAction("Index", "Agency");

        }
        public ActionResult Delete(int id)
        {
            var db = model.PROPERTies.Find(id);
            model.PROPERTies.Remove(db);
            model.SaveChanges();
            int ID = id;
            return RedirectToAction("Index", "Agency", new { id = ID });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PROPERTY pROPERTY, List<HttpPostedFileBase> files)
        {
            ReadList();
            var product = new PROPERTY();
            var IDUser = (int)Session["userid"];

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
            product.PropertyName = pROPERTY.PropertyName;
            product.PropertyType_ID = pROPERTY.PropertyType_ID;
            product.Content = pROPERTY.Content;
            product.Street_ID = pROPERTY.Street_ID;
            product.WARD = pROPERTY.WARD;
            product.District_ID = pROPERTY.District_ID;
            product.Price = pROPERTY.Price;
            product.UnitPrice = pROPERTY.UnitPrice;
            product.Area = pROPERTY.Area;
            product.BedRoom = pROPERTY.BedRoom;
            product.BathRoom = pROPERTY.BathRoom;
            product.PackingPlace = pROPERTY.PackingPlace;
            product.UserID = IDUser;
            model.SaveChanges();
            return RedirectToAction("Index", "Agency");
        }
    }
}