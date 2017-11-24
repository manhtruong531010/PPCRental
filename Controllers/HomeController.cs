using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Website_BĐS.Models;
namespace Website_BĐS.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> type, district, ward, street, bedroom, baths;
        DemoPPCRentalEntities model = new DemoPPCRentalEntities();
        public void Function()
        {
            
            type = new List<SelectListItem>();
            district = new List<SelectListItem>();
            ward = new List<SelectListItem>();
            street = new List<SelectListItem>();
            bedroom = new List<SelectListItem>();
            baths = new List<SelectListItem>();
           
            var typ = model.PROPERTY_TYPE.ToList();
            var dist = model.DISTRICT.ToList();
            var war = model.WARD.ToList().OrderBy(x => x.WardName);
            var stree = model.STREET.ToList().OrderBy(x => x.StreetName);
            var bedroo = model.PROPERTY.ToList();
            var bat = model.PROPERTY.ToList();
          
            foreach (var n in typ)
            {
                type.Add(new SelectListItem { Text = n.Description, Value = n.Description });
            }
            ViewData["LoaiDA"] = type;

            /*---------Quận------------*/
            foreach (var n in dist)
            {
                district.Add(new SelectListItem { Text = n.DistrictName, Value = n.DistrictName });
            }
            ViewData["Quan"] = district;
            /*---------Phường------------*/
            foreach (var n in war)
            {
                ward.Add(new SelectListItem { Text = n.WardName, Value = n.WardName });
            }
            ViewData["Phuong"] = ward;
            /*---------Đường------------*/
            foreach (var n in stree)
            {
                street.Add(new SelectListItem { Text = n.StreetName, Value = n.StreetName });
            }
            ViewData["Duong"] = street;
            /*---------Phòng ngủ------------*/
            foreach (var n in bedroo)
            {
                bedroom.Add(new SelectListItem { Text = n.BedRoom.ToString(), Value = n.BedRoom.ToString() });
            }
            ViewData["PNgu"] = bedroom;
            /*---------Phòng tắm------------*/
            foreach (var n in bat)
            {
                baths.Add(new SelectListItem { Text = n.BathRoom.ToString(), Value = n.BathRoom.ToString() });
            }
            ViewData["PTam"] = baths;
        }
        public ActionResult Index()
        {
            Function();
            var property = model.PROPERTY.ToList().OrderByDescending(x => x.ID);
            return View(property);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
       
        [HttpGet]
        public ActionResult Search(string loaiDA, string quan, string phuong, string duong, int pNgu, int pTam)
        {
            Function();
            var search = model.PROPERTY.ToList().Where(x => x.DISTRICT.DistrictName == quan || x.WARD.WardName == phuong || x.STREET.StreetName == duong || x.BathRoom == pTam || x.BedRoom == pNgu || x.PROPERTY_TYPE.Description == loaiDA);

            

            return View(search);
        }
    }
}