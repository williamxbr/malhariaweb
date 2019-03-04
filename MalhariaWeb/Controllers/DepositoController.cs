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
    public class DepositoController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /Deposito/
        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View(db.DEPOSITO.ToList());
        }

        //
        // GET: /Deposito/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            DEPOSITO deposito = db.DEPOSITO.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            return View(deposito);
        }

        //
        // GET: /Deposito/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Deposito/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(DEPOSITO deposito)
        {
            if (ModelState.IsValid)
            {
                db.DEPOSITO.Add(deposito);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(deposito);
        }

        //
        // GET: /Deposito/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            DEPOSITO deposito = db.DEPOSITO.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            return View(deposito);
        }

        //
        // POST: /Deposito/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(DEPOSITO deposito)
        {
            if (ModelState.IsValid)
            {
                db.Entry(deposito).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(deposito);
        }

        //
        // GET: /Deposito/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            DEPOSITO deposito = db.DEPOSITO.Find(id);
            if (deposito == null)
            {
                return HttpNotFound();
            }
            return View(deposito);
        }

        //
        // POST: /Deposito/Delete/5

        [HttpPost, ActionName("Delete")]
        [Filtro(Roles = "PCP")]
        public ActionResult DeleteConfirmed(int id)
        {
            DEPOSITO deposito = db.DEPOSITO.Find(id);
            db.DEPOSITO.Remove(deposito);
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