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
    public class OrdemAcabamentoController : Controller
    {
        private ContextDB db = new ContextDB();

        [Filtro(Roles = "PCP")]
        public ActionResult Programado()
        {
            var ordem_acabamento = db.ORDEM_ACABAMENTO.Where(b => b.SITUACAO == eTipoSituacao.Programado).Include(b => b.PRODUTO).Include(b => b.COR);
            return View(ordem_acabamento.ToList());
        }

        [Filtro(Roles = "PCP")]
        public ActionResult Producao()
        {
            var ordem_acabamento = db.ORDEM_ACABAMENTO.Where(b => b.SITUACAO == eTipoSituacao.Emitido).Include(b => b.PRODUTO).Include(b => b.COR);
            return View(ordem_acabamento.ToList());
        }

        [Filtro(Roles = "PCP")]
        public ActionResult Retornado()
        {
            var ordem_acabamento = db.ORDEM_ACABAMENTO.Where(b => b.SITUACAO == eTipoSituacao.Recebido).Include(b => b.PRODUTO).Include(b => b.COR);
            return View(ordem_acabamento.ToList());
        }

        [Filtro(Roles = "PCP")]
        public ActionResult Emissao(int id = 0)
        {
            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(id);
            List<ORDEM_ACABAMENTO_PECAS> ordem_acabamento_pecas = db.ORDEM_ACABAMENTO_PECAS.Where(p => p.ID_ORDEM_ACABAMENTO == id).ToList();
            ordem_acabamento.ORDEM_ACABAMENTO_PECAS = ordem_acabamento_pecas;
            if (ordem_acabamento == null)
            {
                return HttpNotFound();
            }
            return View(ordem_acabamento);
        }

        [Filtro(Roles = "PCP")]
        public ActionResult Revisao(int id = 0)
        {
            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(id);
            List<ORDEM_ACABAMENTO_PECAS> ordem_acabamento_pecas = db.ORDEM_ACABAMENTO_PECAS.Where(p => p.ID_ORDEM_ACABAMENTO == id).ToList();
            ordem_acabamento.ORDEM_ACABAMENTO_PECAS = ordem_acabamento_pecas;
            var acondicionamento = from c in db.ACONDICIONAMENTO select c;
            ViewData["acondicionamento"] = new SelectList(acondicionamento, "ID_ACONDICIONAMENTO", "NOME_ACONDICIONAMENTO");
            if (ordem_acabamento == null)
            {
                return HttpNotFound();
            }
            return View(ordem_acabamento);
        }

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public JsonResult Emitir(int id)
        {
            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(id);
            if (ordem_acabamento == null)
            {
                return Json(false);
            }

            ordem_acabamento.SITUACAO = eTipoSituacao.Emitido;
            db.Entry(ordem_acabamento).State = EntityState.Modified;
            db.SaveChanges();
            return Json(true);
        }

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public JsonResult Recebimento(int id)
        {
            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(id);
            if (ordem_acabamento == null)
            {
                return Json(false);
            }

            ordem_acabamento.SITUACAO = eTipoSituacao.Recebido;
            db.Entry(ordem_acabamento).State = EntityState.Modified;
            db.SaveChanges();
            return Json(true);
        }


        //
        // GET: /OrdemAcabamento/

        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View(db.ORDEM_ACABAMENTO.ToList());
        }

        //
        // GET: /OrdemAcabamento/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(id);
            if (ordem_acabamento == null)
            {
                return HttpNotFound();
            }
            return View(ordem_acabamento);
        }

        //
        // GET: /OrdemAcabamento/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO");
            ViewBag.ID_COR     = new SelectList(db.COR, "ID_COR", "NOME_COR");
            return View();
        }

        //
        // POST: /OrdemAcabamento/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(ORDEM_ACABAMENTO ordem_acabamento)
        {
            if (ModelState.IsValid)
            {
                db.ORDEM_ACABAMENTO.Add(ordem_acabamento);
                db.SaveChanges();
                return RedirectToAction("Programado");
            }

            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO");
            ViewBag.ID_COR = new SelectList(db.COR, "ID_COR", "NOME_COR");
            return View(ordem_acabamento);
        }

        //
        // GET: /OrdemAcabamento/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(id);
            if (ordem_acabamento == null)
            {
                return HttpNotFound();
            }
            return View(ordem_acabamento);
        }

        //
        // POST: /OrdemAcabamento/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(ORDEM_ACABAMENTO ordem_acabamento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordem_acabamento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordem_acabamento);
        }

        //
        // GET: /OrdemAcabamento/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(id);
            if (ordem_acabamento == null)
            {
                return HttpNotFound();
            }
            return View(ordem_acabamento);
        }

        //
        // POST: /OrdemAcabamento/Delete/5

        [Filtro(Roles = "PCP")]
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(id);
            db.ORDEM_ACABAMENTO.Remove(ordem_acabamento);
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