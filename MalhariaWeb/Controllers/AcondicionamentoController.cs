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
    public class AcondicionamentoController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /Acondicionamento/

        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View(db.ACONDICIONAMENTO.ToList());
        }

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Index(FormCollection form)
        {
            var deleteInputs = form.GetValues("deleteInputs");
            if (deleteInputs == null)
            {
                ModelState.AddModelError("", "None of the reconds has been selected for delete action !");
                return View();
            }

            foreach (var item in deleteInputs)
            {
                try
                {
                    if (item != "false")
                    {
                        int id = Convert.ToInt32(item);
                        ACONDICIONAMENTO acondicionamento = db.ACONDICIONAMENTO.Find(id);
                        db.ACONDICIONAMENTO.Remove(acondicionamento);
                        db.SaveChanges();
                    }
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", "Failed On Id " + item.ToString() + " : " + err.Message);
                    return View(db.ACONDICIONAMENTO.ToList());
                }
            }
            return View(db.ACONDICIONAMENTO.ToList());
        }


        //
        // GET: /Acondicionamento/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            ACONDICIONAMENTO acondicionamento = db.ACONDICIONAMENTO.Find(id);
            if (acondicionamento == null)
            {
                return HttpNotFound();
            }
            return View(acondicionamento);
        }

        //
        // GET: /Acondicionamento/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Acondicionamento/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(ACONDICIONAMENTO acondicionamento)
        {
            if (ModelState.IsValid)
            {
                db.ACONDICIONAMENTO.Add(acondicionamento);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(acondicionamento);
        }

        //
        // GET: /Acondicionamento/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            ACONDICIONAMENTO acondicionamento = db.ACONDICIONAMENTO.Find(id);
            if (acondicionamento == null)
            {
                return HttpNotFound();
            }
            return View(acondicionamento);
        }

        //
        // POST: /Acondicionamento/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(ACONDICIONAMENTO acondicionamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(acondicionamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(acondicionamento);
        }

        //
        // GET: /Acondicionamento/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            ACONDICIONAMENTO acondicionamento = db.ACONDICIONAMENTO.Find(id);
            if (acondicionamento == null)
            {
                return HttpNotFound();
            }
            return View(acondicionamento);
        }

        //
        // POST: /Acondicionamento/Delete/5

        //[HttpPost, ActionName("Delete")]
        [Filtro(Roles = "PCP")]
        public ActionResult DeleteConfirmed(int id)
        {
            ACONDICIONAMENTO acondicionamento = db.ACONDICIONAMENTO.Find(id);
            db.ACONDICIONAMENTO.Remove(acondicionamento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [Filtro(Roles = "PCP")]
        public JsonResult DeleteAcondicionamento(int id)
        {
            // delete the record from ID and return true else false
            return Json(true, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}