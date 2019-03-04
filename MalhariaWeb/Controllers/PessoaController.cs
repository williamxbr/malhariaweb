using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MalhariaWeb.Models;
using MalhariaWeb.Roles;

namespace MalhariaWeb.Controllers
{
    public class PessoaController : Controller
    {
        private ContextDB db = new ContextDB();
        //
        // GET: /Pessoa/

        [Filtro(Roles = "Vendas")]
        public ActionResult Index()
        {
            return View(db.PESSOA.ToList());
        }

        //
        // GET: /Pessoa/Details/5

        [Filtro(Roles = "Vendas")]
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Pessoa/Create

        [Filtro(Roles = "Vendas")]
        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Pessoa/Create

        [HttpPost]
        [Filtro(Roles = "Vendas")]
        public ActionResult Create(PESSOA pessoa)
        {
            if (ModelState.IsValid)
            {
                db.PESSOA.Add(pessoa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        //
        // GET: /Pessoa/Edit/5

        [Filtro(Roles = "Vendas")]
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Pessoa/Edit/5

        [HttpPost]
        [Filtro(Roles = "Vendas")]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Pessoa/Delete/5

        [Filtro(Roles = "Vendas")]
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Pessoa/Delete/5

        [HttpPost]
        [Filtro(Roles = "Vendas")]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
