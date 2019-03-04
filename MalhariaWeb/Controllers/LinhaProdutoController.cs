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
    public class LinhaProdutoController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /LinhaProduto/
        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View(db.LINHA_PRODUTO.ToList());
        }

        //
        // GET: /LinhaProduto/Details/5

        [Filtro(Roles = "PCP")]
        public ActionResult Details(int id = 0)
        {
            LINHA_PRODUTO linha_produto = db.LINHA_PRODUTO.Find(id);
            if (linha_produto == null)
            {
                return HttpNotFound();
            }
            return View(linha_produto);
        }

        //
        // GET: /LinhaProduto/Create

        [Filtro(Roles = "PCP")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LinhaProduto/Create

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Create(LINHA_PRODUTO linha_produto)
        {
            if (ModelState.IsValid)
            {
                db.LINHA_PRODUTO.Add(linha_produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(linha_produto);
        }

        //
        // GET: /LinhaProduto/Edit/5

        [Filtro(Roles = "PCP")]
        public ActionResult Edit(int id = 0)
        {
            LINHA_PRODUTO linha_produto = db.LINHA_PRODUTO.Find(id);
            if (linha_produto == null)
            {
                return HttpNotFound();
            }
            return View(linha_produto);
        }

        //
        // POST: /LinhaProduto/Edit/5

        [HttpPost]
        [Filtro(Roles = "PCP")]
        public ActionResult Edit(LINHA_PRODUTO linha_produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(linha_produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(linha_produto);
        }

        //
        // GET: /LinhaProduto/Delete/5

        [Filtro(Roles = "PCP")]
        public ActionResult Delete(int id = 0)
        {
            LINHA_PRODUTO linha_produto = db.LINHA_PRODUTO.Find(id);
            if (linha_produto == null)
            {
                return HttpNotFound();
            }
            return View(linha_produto);
        }

        //
        // POST: /LinhaProduto/Delete/5

        [HttpPost, ActionName("Delete")]
        [Filtro(Roles = "PCP")]
        public ActionResult DeleteConfirmed(int id)
        {
            LINHA_PRODUTO linha_produto = db.LINHA_PRODUTO.Find(id);
            db.LINHA_PRODUTO.Remove(linha_produto);
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