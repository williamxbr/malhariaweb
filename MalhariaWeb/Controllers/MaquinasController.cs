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
    public class MaquinasController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /Maquinas/
        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View(db.MAQUINAS.ToList());
        }

        //
        // GET: /Maquinas/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            MAQUINAS maquinas = db.MAQUINAS.Find(id);
            if (maquinas == null)
            {
                return HttpNotFound();
            }
            return View(maquinas);
        }

        //
        // GET: /Maquinas/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Maquinas/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(MAQUINAS maquinas)
        {
            if (ModelState.IsValid)
            {
                db.MAQUINAS.Add(maquinas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(maquinas);
        }

        //
        // GET: /Maquinas/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            MAQUINAS maquinas = db.MAQUINAS.Find(id);
            if (maquinas == null)
            {
                return HttpNotFound();
            }
            return View(maquinas);
        }

        //
        // POST: /Maquinas/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(MAQUINAS maquinas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(maquinas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(maquinas);
        }

        //
        // GET: /Maquinas/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            MAQUINAS maquinas = db.MAQUINAS.Find(id);
            if (maquinas == null)
            {
                return HttpNotFound();
            }
            return View(maquinas);
        }

        //
        // POST: /Maquinas/Delete/5

        [HttpPost, ActionName("Delete")]
        [Filtro(Roles = "PCP")]
        public ActionResult DeleteConfirmed(int id)
        {
            MAQUINAS maquinas = db.MAQUINAS.Find(id);
            db.MAQUINAS.Remove(maquinas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}