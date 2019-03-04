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
    public class PecasController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /Pecas/

        [Filtro(Roles = "Operador")]
        public ActionResult Index()
        {
            var pecas = db.PECAS.Include(p => p.PRODUTO).Include(p => p.UNIDADE_MEDIDA).Include(p => p.DEPOSITO).Include(p => p.OPERADOR).Include(p => p.COR).Include(p => p.ACONDICIONAMENTO).Include(p => p.MAQUINAS);
            return View(pecas.ToList());
        }

        //
        // GET: /Pecas/Details/5

        [Filtro(Roles = "Operador")]
        public ActionResult Details(int id = 0)
        {
            PECAS pecas = db.PECAS.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            return View(pecas);
        }

        // Get: /Pecas/CreatePecaCrua
        [Filtro(Roles = "Operador")]
        public ActionResult CreatePecaCrua()
        {
            ViewBag.ID_ACONDICIONAMENTO = new SelectList(db.ACONDICIONAMENTO, "ID_ACONDICIONAMENTO", "NOME_ACONDICIONAMENTO");
            ViewBag.ID_DEPOSITO         = new SelectList(db.DEPOSITO, "ID_DEPOSITO", "NOME_DEPOSITO");
            ViewBag.ID_MAQUINA          = new SelectList(db.MAQUINAS, "ID_MAQUINA", "NOME_MAQUINA");
            ViewBag.ID_OPERADOR         = new SelectList(db.OPERADOR, "ID_OPERADOR", "NOME_OPERADOR");
            ViewBag.ID_PRODUTO          = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO");
            ViewBag.ID_UNIDADE_MEDIDA   = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA");
            return View();
        }


        [Filtro(Roles = "Operador")]
        public ActionResult DetalhesPecasCruas(int id = 0)
        {
            PECAS pecas = db.PECAS.Find(id);
            if (pecas == null) 
            {
                return HttpNotFound();
            }
            return View(pecas);
        }

        [HttpPost]
        [Filtro(Roles = "Operador")]
        public ActionResult InserirPecaAcabada(FormCollection form)
        {
            int idordem   = Convert.ToInt32(form.GetValue("ID_ORDEM_ACABAMENTO").AttemptedValue);
            int idcor     = Convert.ToInt32(form.GetValue("ID_COR").AttemptedValue);
            int idproduto = Convert.ToInt32(form.GetValue("ID_PRODUTO").AttemptedValue);
            eQualidadePeca  vqualidade = (eQualidadePeca)Convert.ToInt32(form.GetValue("Qualidade").AttemptedValue);
            double metros;
            if (form.GetValue("Metros").AttemptedValue == String.Empty)
                metros = 0.00;
            else
                metros = Convert.ToDouble(form.GetValue("Metros").AttemptedValue);
            double largura;
            if (form.GetValue("Largura").AttemptedValue == String.Empty)
                largura = 0.00;
            else 
                largura = Convert.ToDouble(form.GetValue("Largura").AttemptedValue);
            int acondicionamento = Convert.ToInt32(form.GetValue("Acondicionamento").AttemptedValue);
            int vpecacrua = Convert.ToInt32(form.GetValue("pecacrua").AttemptedValue);

            PECAS pecacrua = db.PECAS.Find(vpecacrua);
            pecacrua.SITUACAO = eSituacaoPeca.Revisado;
            db.Entry(pecacrua).State = EntityState.Modified;

            PECAS pecaacabada = new PECAS();
            pecaacabada.UNIDADE_MEDIDA = pecacrua.UNIDADE_MEDIDA;
            pecaacabada.DATA_ENTRADA = DateTime.Now.Date;
            pecaacabada.HORA_ENTRADA = DateTime.Now;
            pecaacabada.TIPO_PECA = eTipoPeca.Acabado;
            pecaacabada.METROS = metros;
            pecaacabada.LARGURA = largura;
            pecaacabada.ID_COR = idcor;
            pecaacabada.ID_PRODUTO = idproduto;
            pecaacabada.ID_ACONDICIONAMENTO = acondicionamento;
            pecaacabada.ID_DEPOSITO = 3;
            db.PECAS.Add(pecaacabada);
            db.SaveChanges();

            return RedirectToAction("Revisao", "OrdemAcabamento", new { id = idordem });
        }

        //
        // POST: /Pecas/CreateCrua
        [HttpPost]
        [Filtro(Roles = "Operador")]
        public ActionResult CreatePecaCrua(PECAS pecas)
        {
            if (ModelState.IsValid)
            {
                pecas.DATA_ENTRADA = DateTime.Now.Date;
                pecas.HORA_ENTRADA = DateTime.Now;
                pecas.TIPO_PECA = eTipoPeca.Cru;
                pecas.EH_PECA_DIVIDIDA = false;
                pecas.SITUACAO = eSituacaoPeca.Disponivel;
                pecas.PESO_LIQUIDO = pecas.PESO_BRUTO - db.ACONDICIONAMENTO.Find(pecas.ID_ACONDICIONAMENTO).VALOR;
                db.PECAS.Add(pecas);
                db.SaveChanges();
                return RedirectToAction("CreatePecaCrua");
            }

            ViewBag.ID_ACONDICIONAMENTO = new SelectList(db.ACONDICIONAMENTO, "ID_ACONDICIONAMENTO", "NOME_ACONDICIONAMENTO", pecas.ID_ACONDICIONAMENTO);
            ViewBag.ID_DEPOSITO = new SelectList(db.DEPOSITO, "ID_DEPOSITO", "NOME_DEPOSITO", pecas.ID_DEPOSITO);
            ViewBag.ID_MAQUINA = new SelectList(db.MAQUINAS, "ID_MAQUINA", "NOME_MAQUINA", pecas.ID_MAQUINA);
            ViewBag.ID_OPERADOR = new SelectList(db.OPERADOR, "ID_OPERADOR", "NOME_OPERADOR", pecas.ID_OPERADOR);
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO", pecas.ID_PRODUTO);
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA", pecas.ID_UNIDADE_MEDIDA);
            return View(pecas);
        }

        //
        // GET: /Pecas/Create

        [Filtro(Roles = "Operador")]
        public ActionResult Create()
        {
            ViewBag.ID_ACONDICIONAMENTO = new SelectList(db.ACONDICIONAMENTO, "ID_ACONDICIONAMENTO", "NOME_ACONDICIONAMENTO");
            ViewBag.ID_COR = new SelectList(db.COR, "ID_COR", "NOME_COR");
            ViewBag.ID_DEPOSITO = new SelectList(db.DEPOSITO, "ID_DEPOSITO", "NOME_DEPOSITO");
            ViewBag.ID_MAQUINA = new SelectList(db.MAQUINAS, "ID_MAQUINA", "NOME_MAQUINA");
            ViewBag.ID_OPERADOR = new SelectList(db.OPERADOR, "ID_OPERADOR", "NOME_OPERADOR");
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO");
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA");
            return View();
        }

        //
        // POST: /Pecas/Create

        [HttpPost]
        [Filtro(Roles = "Operador")]
        public ActionResult Create(PECAS pecas)
        {
            if (ModelState.IsValid)
            {
                db.PECAS.Add(pecas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_ACONDICIONAMENTO = new SelectList(db.ACONDICIONAMENTO, "ID_ACONDICIONAMENTO", "NOME_ACONDICIONAMENTO", pecas.ID_ACONDICIONAMENTO);
            ViewBag.ID_COR = new SelectList(db.COR, "ID_COR", "NOME_COR", pecas.ID_COR);
            ViewBag.ID_DEPOSITO = new SelectList(db.DEPOSITO, "ID_DEPOSITO", "NOME_DEPOSITO", pecas.ID_DEPOSITO);
            ViewBag.ID_MAQUINA = new SelectList(db.MAQUINAS, "ID_MAQUINA", "NOME_MAQUINA", pecas.ID_MAQUINA);
            ViewBag.ID_OPERADOR = new SelectList(db.OPERADOR, "ID_OPERADOR", "NOME_OPERADOR", pecas.ID_OPERADOR);
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO", pecas.ID_PRODUTO);
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA", pecas.ID_UNIDADE_MEDIDA);
            return View(pecas);
        }

        //
        // GET: /Pecas/Edit/5

        [Filtro(Roles = "Operador")]
        public ActionResult Edit(int id = 0)
        {
            PECAS pecas = db.PECAS.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_ACONDICIONAMENTO = new SelectList(db.ACONDICIONAMENTO, "ID_ACONDICIONAMENTO", "NOME_ACONDICIONAMENTO", pecas.ID_ACONDICIONAMENTO);
            ViewBag.ID_COR = new SelectList(db.COR, "ID_COR", "NOME_COR", pecas.ID_COR);
            ViewBag.ID_DEPOSITO = new SelectList(db.DEPOSITO, "ID_DEPOSITO", "NOME_DEPOSITO", pecas.ID_DEPOSITO);
            ViewBag.ID_MAQUINA = new SelectList(db.MAQUINAS, "ID_MAQUINA", "NOME_MAQUINA", pecas.ID_MAQUINA);
            ViewBag.ID_OPERADOR = new SelectList(db.OPERADOR, "ID_OPERADOR", "NOME_OPERADOR", pecas.ID_OPERADOR);
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO", pecas.ID_PRODUTO);
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA", pecas.ID_UNIDADE_MEDIDA);
            return View(pecas);
        }

        //
        // POST: /Pecas/Edit/5

        [HttpPost]
        [Filtro(Roles = "Operador")]
        public ActionResult Edit(PECAS pecas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pecas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_ACONDICIONAMENTO = new SelectList(db.ACONDICIONAMENTO, "ID_ACONDICIONAMENTO", "NOME_ACONDICIONAMENTO", pecas.ID_ACONDICIONAMENTO);
            ViewBag.ID_COR = new SelectList(db.COR, "ID_COR", "NOME_COR", pecas.ID_COR);
            ViewBag.ID_DEPOSITO = new SelectList(db.DEPOSITO, "ID_DEPOSITO", "NOME_DEPOSITO", pecas.ID_DEPOSITO);
            ViewBag.ID_MAQUINA = new SelectList(db.MAQUINAS, "ID_MAQUINA", "NOME_MAQUINA", pecas.ID_MAQUINA);
            ViewBag.ID_OPERADOR = new SelectList(db.OPERADOR, "ID_OPERADOR", "NOME_OPERADOR", pecas.ID_OPERADOR);
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO", pecas.ID_PRODUTO);
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA", pecas.ID_UNIDADE_MEDIDA);
            return View(pecas);
        }

        //
        // GET: /Pecas/Delete/5

        [Filtro(Roles = "Operador")]
        public ActionResult Delete(int id = 0)
        {
            PECAS pecas = db.PECAS.Find(id);
            if (pecas == null)
            {
                return HttpNotFound();
            }
            return View(pecas);
        }

        //
        // POST: /Pecas/Delete/5

        [HttpPost, ActionName("Delete")]
        [Filtro(Roles = "Operador")]
        public ActionResult DeleteConfirmed(int id)
        {
            PECAS pecas = db.PECAS.Find(id);
            db.PECAS.Remove(pecas);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        [HttpGet]
        [Filtro(Roles = "Operador")]
        public JsonResult GetPecasCruas(int produto)
        {
            var pecas = db.PECAS.Where(p => p.ID_PRODUTO == produto).Where(p => p.SITUACAO == eSituacaoPeca.Disponivel && p.TIPO_PECA == eTipoPeca.Cru && p.QUALIDADE == eQualidadePeca.Primeira).Include(p => p.PRODUTO).Include(p => p.UNIDADE_MEDIDA).Include(p => p.DEPOSITO).Include(p => p.OPERADOR).Include(p => p.COR).Include(p => p.ACONDICIONAMENTO).Include(p => p.MAQUINAS);
            return Json(pecas.ToList(),JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Filtro(Roles = "Operador")]
        public JsonResult GetPecaCrua(int peca)
        {
            var pecas = db.PECAS.Where(p => p.ID_PECA == peca);
            return Json(pecas.ToList(), JsonRequestBehavior.AllowGet);
        }

    }
}