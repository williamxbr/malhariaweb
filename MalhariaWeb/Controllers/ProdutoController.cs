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
    public class ProdutoController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /Produto/

        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            var produto = db.PRODUTO.Include(p => p.LINHA_PRODUTO).Include(p => p.UNIDADE_MEDIDA);
            return View(produto.ToList());
        }

        //
        // GET: /Produto/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            PRODUTO produto = db.PRODUTO.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //
        // GET: /Produto/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            ViewBag.ID_LINHA_PRODUTO = new SelectList(db.LINHA_PRODUTO, "ID_LINHA_PRODUTO", "NOME_LINHA_PRODUTO");
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA");
            return View();
        }

        //
        // POST: /Produto/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(PRODUTO produto)
        {
            if (ModelState.IsValid)
            {
                db.PRODUTO.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_LINHA_PRODUTO = new SelectList(db.LINHA_PRODUTO, "ID_LINHA_PRODUTO", "NOME_LINHA_PRODUTO", produto.ID_LINHA_PRODUTO);
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA", produto.ID_UNIDADE_MEDIDA);
            return View(produto);
        }

        //
        // GET: /Produto/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            PRODUTO produto = db.PRODUTO.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_LINHA_PRODUTO = new SelectList(db.LINHA_PRODUTO, "ID_LINHA_PRODUTO", "NOME_LINHA_PRODUTO", produto.ID_LINHA_PRODUTO);
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA", produto.ID_UNIDADE_MEDIDA);
            return View(produto);
        }

        //
        // POST: /Produto/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(PRODUTO produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_LINHA_PRODUTO = new SelectList(db.LINHA_PRODUTO, "ID_LINHA_PRODUTO", "NOME_LINHA_PRODUTO", produto.ID_LINHA_PRODUTO);
            ViewBag.ID_UNIDADE_MEDIDA = new SelectList(db.UNIDADE_MEDIDA, "ID_UNIDADE_MEDIDA", "NOME_UNIDADE_MEDIDA", produto.ID_UNIDADE_MEDIDA);
            return View(produto);
        }

        //
        // GET: /Produto/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            PRODUTO produto = db.PRODUTO.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //
        // POST: /Produto/Delete/5

        [HttpPost, ActionName("Delete")]
        [Filtro(Roles = "PCP")]
        public ActionResult DeleteConfirmed(int id)
        {
            PRODUTO produto = db.PRODUTO.Find(id);
            db.PRODUTO.Remove(produto);
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