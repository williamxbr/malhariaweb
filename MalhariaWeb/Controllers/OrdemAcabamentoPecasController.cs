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
    public class OrdemAcabamentoPecasController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /OrdemAcabamentoPecas/
        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View(db.ORDEM_ACABAMENTO_PECAS.ToList());
        }

        //
        // GET: /OrdemAcabamentoPecas/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas = db.ORDEM_ACABAMENTO_PECAS.Find(id);
            if (ordem_acabamento_pecas == null)
            {
                return HttpNotFound();
            }
            return View(ordem_acabamento_pecas);
        }

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult InserirPecas(FormCollection form)
        {
            var vidordem = form.GetValues("ID_ORDEM_ACABAMENTO");
            var vidpecas = form.GetValues("checkboxPecas");
            int idordem = Convert.ToInt32(vidordem[0]);

            if (vidpecas == null)
            {
                ModelState.AddModelError("", "None of the reconds has been selected for delete action !");
                return View();
            }

            foreach (var item in vidpecas)
            {
                try
                {
                    int id = Convert.ToInt32(item);
                    PECAS pecas = db.PECAS.Find(id);
                    if ((pecas.SITUACAO == eSituacaoPeca.Disponivel) && (pecas.TIPO_PECA == eTipoPeca.Cru))
                    {
                        ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas = new ORDEM_ACABAMENTO_PECAS();
                        ordem_acabamento_pecas.ID_ORDEM_ACABAMENTO = idordem;
                        ordem_acabamento_pecas.ID_PECA = pecas.ID_PECA;
                        if (pecas.METROS.HasValue)
                           ordem_acabamento_pecas.METROS = (double)pecas.METROS;
                        ordem_acabamento_pecas.PESO = pecas.PESO_LIQUIDO;
                        db.ORDEM_ACABAMENTO_PECAS.Add(ordem_acabamento_pecas);

                        ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(idordem);
                        ordem_acabamento.KILOS_ORIGINAIS = ordem_acabamento.KILOS_ORIGINAIS + pecas.PESO_LIQUIDO;
                        db.Entry(ordem_acabamento).State = EntityState.Modified;

                        PECAS pecacrua = db.PECAS.Find(id);
                        pecacrua.SITUACAO = eSituacaoPeca.Producao;
                        db.Entry(pecacrua).State = EntityState.Modified;
                        
                        db.SaveChanges();
                    }
                }
                catch (Exception err)
                {
                    ModelState.AddModelError("", "Failed On Id " + item.ToString() + " : " + err.Message);
                    return View();
                }
            }


            return RedirectToAction("Emissao", "OrdemAcabamento", new { id = idordem });
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [Filtro(Roles = "PCP")]
        public JsonResult DeletaPeca(int id)
        {
            ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas = db.ORDEM_ACABAMENTO_PECAS.Find(id);
            if (ordem_acabamento_pecas == null)
            {
                return Json(false);
            }
            
            int peca = ordem_acabamento_pecas.ID_PECA;
            int ordem = ordem_acabamento_pecas.ID_ORDEM_ACABAMENTO;

            ORDEM_ACABAMENTO ordem_acabamento = db.ORDEM_ACABAMENTO.Find(ordem);
            ordem_acabamento.KILOS_ORIGINAIS = ordem_acabamento.KILOS_ORIGINAIS - ordem_acabamento_pecas.PESO;
            db.Entry(ordem_acabamento).State = EntityState.Modified;

            PECAS pecacrua = db.PECAS.Find(peca);
            pecacrua.SITUACAO = eSituacaoPeca.Disponivel;
            db.Entry(pecacrua).State = EntityState.Modified;
            
            db.ORDEM_ACABAMENTO_PECAS.Remove(ordem_acabamento_pecas);
            
            db.SaveChanges();

            return Json(true);
        }

        [Filtro(Roles = "PCP")]
        public ActionResult DeletarPecas(FormCollection form)
        {
            var vidpecas = form.GetValues("checkboxPecas");
            if (vidpecas == null)
            {
                ModelState.AddModelError("", "None of the reconds has been selected for delete action !");
                return View();
            }

           // ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas = db.ORDEM_ACABAMENTO_PECAS.Find(ID);
           // db.ORDEM_ACABAMENTO_PECAS.Remove(ordem_acabamento_pecas);
           // db.SaveChanges();
            return View(); // Json(true, JsonRequestBehavior.AllowGet);
        }
        

        //
        // GET: /OrdemAcabamentoPecas/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrdemAcabamentoPecas/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas)
        {
            if (ModelState.IsValid)
            {
                db.ORDEM_ACABAMENTO_PECAS.Add(ordem_acabamento_pecas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordem_acabamento_pecas);
        }

        //
        // GET: /OrdemAcabamentoPecas/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas = db.ORDEM_ACABAMENTO_PECAS.Find(id);
            if (ordem_acabamento_pecas == null)
            {
                return HttpNotFound();
            }
            return View(ordem_acabamento_pecas);
        }

        //
        // POST: /OrdemAcabamentoPecas/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordem_acabamento_pecas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordem_acabamento_pecas);
        }

        //
        // GET: /OrdemAcabamentoPecas/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas = db.ORDEM_ACABAMENTO_PECAS.Find(id);
            if (ordem_acabamento_pecas == null)
            {
                return HttpNotFound();
            }
            return View(ordem_acabamento_pecas);
        }

        //
        // POST: /OrdemAcabamentoPecas/Delete/5

        [HttpPost, ActionName("Delete")]
        [Filtro(Roles = "PCP")]
        public ActionResult DeleteConfirmed(int id)
        {
            ORDEM_ACABAMENTO_PECAS ordem_acabamento_pecas = db.ORDEM_ACABAMENTO_PECAS.Find(id);
            db.ORDEM_ACABAMENTO_PECAS.Remove(ordem_acabamento_pecas);
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