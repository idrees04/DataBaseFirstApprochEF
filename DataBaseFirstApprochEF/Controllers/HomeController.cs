using DataBaseFirstApprochEF.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;

namespace DataBaseFirstApprochEF.Controllers
{
    public class HomeController : Controller
    {
        DatabaseFirstEFEntities db = new DatabaseFirstEFEntities();
        // GET: Home
        public ActionResult Index()
        {
            var data = db.students.ToList();
            return View(data);
        }
        public ActionResult Create()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Create(student s)
        {
            if (ModelState.IsValid == true)
            {
                db.students.Add(s);
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["InsertMessage"] = "<script>alert('Inserted')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["InsertMessage"] = "<script>alert('Not Inserted')</script>";
                }
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            var row = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }
        [HttpPost]
        public ActionResult Edit(student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State=EntityState.Modified;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["UpdateMessage"] = "<script>alert('Updated')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["UpdateMessage"] = "<script>alert('Not Update')</script>";
                }
            }
            return View();
        }
        public ActionResult Delete(int id)
        {
            var DeletedRow = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(DeletedRow);
        }
        [HttpPost]
        public ActionResult Delete(student s)
        {
            if (ModelState.IsValid == true)
            {
                db.Entry(s).State = EntityState.Deleted;
                int a = db.SaveChanges();
                if (a > 0)
                {
                    TempData["DeleteMessage"] = "<script>alert('Deleted')</script>";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["DeleteMessage"] = "<script>alert('Not Deleted')</script>";
                }
            }
            return View();
        }
        public ActionResult Details(int id)
        {
            var row = db.students.Where(model => model.id == id).FirstOrDefault();
            return View(row);
        }
    }
}