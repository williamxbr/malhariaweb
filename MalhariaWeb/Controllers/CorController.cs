using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MalhariaWeb.Models;
using MalhariaWeb.Roles;

namespace MalhariaWeb.Controllers
{
    public class CorController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /Cor/
        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View(db.COR.ToList());
        }

        //
        // GET: /Cor/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            COR cor = db.COR.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        //
        // GET: /Cor/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Cor/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(COR cor)
        {
            if (ModelState.IsValid)
            {
                db.COR.Add(cor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cor);
        }

        //
        // GET: /Cor/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            COR cor = db.COR.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        //
        // POST: /Cor/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(COR cor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cor);
        }

        //
        // GET: /Cor/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            COR cor = db.COR.Find(id);
            if (cor == null)
            {
                return HttpNotFound();
            }
            return View(cor);
        }

        //
        // POST: /Cor/Delete/5

        [HttpPost, ActionName("Delete")]
        [Filtro(Roles = "PCP")]
        public ActionResult DeleteConfirmed(int id)
        {
            COR cor = db.COR.Find(id);
            db.COR.Remove(cor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [Filtro(Roles = "PCP")]
        public JsonResult DeleteCor(int ID)
        {
             COR cor = db.COR.Find(ID);
             db.COR.Remove(cor);
             db.SaveChanges();
            return Json(true, JsonRequestBehavior.AllowGet);
        }



    }
}