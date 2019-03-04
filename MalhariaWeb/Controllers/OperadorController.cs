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
    public class OperadorController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /Operador/
        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View(db.OPERADOR.ToList());
        }

        //
        // GET: /Operador/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            OPERADOR operador = db.OPERADOR.Find(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        //
        // GET: /Operador/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Operador/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(OPERADOR operador)
        {
            if (ModelState.IsValid)
            {
                db.OPERADOR.Add(operador);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(operador);
        }

        //
        // GET: /Operador/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            OPERADOR operador = db.OPERADOR.Find(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        //
        // POST: /Operador/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(OPERADOR operador)
        {
            if (ModelState.IsValid)
            {
                db.Entry(operador).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(operador);
        }

        //
        // GET: /Operador/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            OPERADOR operador = db.OPERADOR.Find(id);
            if (operador == null)
            {
                return HttpNotFound();
            }
            return View(operador);
        }

        //
        // POST: /Operador/Delete/5

        [HttpPost, ActionName("Delete")]
        [Filtro(Roles = "PCP")]
        public ActionResult DeleteConfirmed(int id)
        {
            OPERADOR operador = db.OPERADOR.Find(id);
            db.OPERADOR.Remove(operador);
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