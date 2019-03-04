using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MalhariaWeb.Models;

namespace MalhariaWeb.Controllers
{
    public class UnidadeMedidaController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /UnidadeMedida/

        public ActionResult Index()
        {
            return View(db.UNIDADE_MEDIDA.ToList());
        }

        //
        // GET: /UnidadeMedida/Details/5

        public ActionResult Details(int id = 0)
        {
            UNIDADE_MEDIDA unidade_medida = db.UNIDADE_MEDIDA.Find(id);
            if (unidade_medida == null)
            {
                return HttpNotFound();
            }
            return View(unidade_medida);
        }

        //
        // GET: /UnidadeMedida/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UnidadeMedida/Create

        [HttpPost]
        public ActionResult Create(UNIDADE_MEDIDA unidade_medida)
        {
            if (ModelState.IsValid)
            {
                db.UNIDADE_MEDIDA.Add(unidade_medida);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(unidade_medida);
        }

        //
        // GET: /UnidadeMedida/Edit/5

        public ActionResult Edit(int id = 0)
        {
            UNIDADE_MEDIDA unidade_medida = db.UNIDADE_MEDIDA.Find(id);
            if (unidade_medida == null)
            {
                return HttpNotFound();
            }
            return View(unidade_medida);
        }

        //
        // POST: /UnidadeMedida/Edit/5

        [HttpPost]
        public ActionResult Edit(UNIDADE_MEDIDA unidade_medida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(unidade_medida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(unidade_medida);
        }

        //
        // GET: /UnidadeMedida/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UNIDADE_MEDIDA unidade_medida = db.UNIDADE_MEDIDA.Find(id);
            if (unidade_medida == null)
            {
                return HttpNotFound();
            }
            return View(unidade_medida);
        }

        //
        // POST: /UnidadeMedida/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            UNIDADE_MEDIDA unidade_medida = db.UNIDADE_MEDIDA.Find(id);
            db.UNIDADE_MEDIDA.Remove(unidade_medida);
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