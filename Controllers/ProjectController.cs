using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using Website_BĐS.Models;

namespace Website_BĐS.Controllers
{
    public class ProjectController : Controller
    {
        //
        // GET: /Project/
        Team33Entities db = new Team33Entities();
        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Project/Details/5
        public ActionResult Details(int id)
        {
            int ID = id;
            var project = db.PROPERTies.FirstOrDefault(x => x.ID == id);
            ViewBag.Images = Directory.EnumerateFiles(Server.MapPath("~/MultiImages"))
                            .Select(fn => "~/MultiImages/" + Path.GetFileName(fn));
            ViewBag.features = db.PROPERTY_FEATURE.Where(x => x.Property_ID == id).ToList();
            ViewBag.Countt = db.PROPERTY_FEATURE.Where(x => x.Property_ID == id).Count();
            ViewBag.fea = db.FEATUREs.ToList();
            return View(project);
        }

        //
        // GET: /Project/Create
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Project/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Project/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Project/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Project/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
