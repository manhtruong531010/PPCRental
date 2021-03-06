﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BĐS.Models;
namespace Website_BĐS.Controllers
{
    public class HomeController : Controller
    {
        //List<SelectListItem> type, district, street;
      public  Team33Entities model = new Team33Entities();
        //public void Function()
        //{
            
        //    type = new List<SelectListItem>();
        //    district = new List<SelectListItem>();
        //    street = new List<SelectListItem>();
           
        //    var typ = model.PROPERTY_TYPE.ToList();
        //    var dist = model.DISTRICTs.ToList();
        //    var stree = model.STREETs.ToList().OrderBy(x => x.StreetName);

          
        //    foreach (var n in typ)
        //    {
        //        type.Add(new SelectListItem { Text = n.Description, Value = n.Description });
        //    }
        //    ViewData["LoaiDA"] = type;

        //    /*---------Quận------------*/
        //    foreach (var n in dist)
        //    {
        //        district.Add(new SelectListItem { Text = n.DistrictName, Value = n.DistrictName });
        //    }
        //    ViewData["Quan"] = district;
        //    /*---------Đường------------*/
        //    foreach (var n in stree)
        //    {
        //        street.Add(new SelectListItem { Text = n.StreetName, Value = n.StreetName });
        //    }
        //    ViewData["Duong"] = street;
        //}
        public ActionResult Index()
        {
            //Function();
            var property = model.PROPERTies.ToList().OrderByDescending(x => x.ID).Where(x => x.Status_ID == 3);
            return View(property);
        }
        public JsonResult GetStreet(int did)
        {
            var db = new Team33Entities();
            var streets = db.STREETs.Where(s => s.District_ID== did);
            return Json(streets.Select(s => new
            {
                id = s.ID,
                text = s.StreetName
            }), JsonRequestBehavior.AllowGet);
        }

        public ActionResult About()
        {
            var about = model.ABOUTUS.FirstOrDefault(x => x.ID == 1);
            return View(about);
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
       
        [HttpPost]
        public ActionResult Search(int? loaiDA, int? Quan, int? Duong, string txtSearch, string txtmin, string txtmax)
        {
            var pro = model.PROPERTies.Where(x => x.Status_ID == 3).ToList();
            if (loaiDA != null)
            {
                pro = pro.Where(x => x.PropertyType_ID == loaiDA).ToList();
            }
            if (Quan != null)
            {
                pro = pro.Where(x => x.District_ID == Quan).ToList();
            }
            if (Duong != null)
            {
                pro = pro.Where(x => x.STREET.ID == Duong).ToList();
            }

            if (txtSearch != "Tên dự án")
            {
                pro = pro.Where(x => x.PropertyName.Contains(txtSearch)).ToList();
            }
            try
            {
                if (txtmin != "Từ")
                {
                    pro = pro.Where(x => x.Price >= int.Parse(txtmin)).ToList();
                }
            }
            catch (FormatException)
            {
            }
            try
            {
                if (txtmax != "Đến")
                {
                    pro = pro.Where(x => x.Price <= int.Parse(txtmax)).ToList();
                }
            }
            catch (FormatException)
            {
            }

            //if (!(String.IsNullOrEmpty(txtSearch)) || !(String.IsNullOrWhiteSpace(txtSearch)))
            //{
            //    pro = pro.Where(x => x.PropertyName.Contains(txtSearch)).ToList();
            //}
            //try
            //{
            //    if (txtmin != null || !(String.IsNullOrEmpty(txtmin)) || !(String.IsNullOrWhiteSpace(txtmin)) || !(txtmin.Equals("")))
            //    {
            //        pro = pro.Where(x => x.Price >= int.Parse(txtmin)).ToList();
            //    }
            //}
            //catch(FormatException)
            //{
            //}
            //try
            //{
            //    if (txtmax != null || !(String.IsNullOrEmpty(txtmax)) || !(String.IsNullOrWhiteSpace(txtmax)) || !(txtmax.Equals("")))
            //    {
            //        pro = pro.Where(x => x.Price <= int.Parse(txtmax)).ToList();
            //    }
            //}
            //catch (FormatException)
            //{
            //}
            //Function();
            //var search = model.PROPERTies.ToList().Where(x => x.DISTRICT.DistrictName == quan || x.STREET.StreetName == duong || x.PROPERTY_TYPE.Description == loaiDA);
            return View(pro);
        }
    }
}