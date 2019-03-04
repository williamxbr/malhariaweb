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
    public class OrdemMalhariaController : Controller
    {
        private ContextDB db = new ContextDB();
        //
        // GET: /OrdemMalharia/

        [Filtro(Roles = "PCP")]
        public ActionResult Programado()
        {
            var ordem_malharia = db.ORDEM_MALHARIA.Where(b => b.SITUACAO == eSituacaoMalharia.Programado).Include(b => b.PRODUTO).Include(b => b.MAQUINAS);
            return View(ordem_malharia.ToList());
        }

        [Filtro(Roles = "PCP")]
        public ActionResult Emitidas()
        {
            var ordem_malharia = db.ORDEM_MALHARIA.Where(b => b.SITUACAO == eSituacaoMalharia.Emitido).Include(b => b.PRODUTO).Include(b => b.MAQUINAS);
            return View(ordem_malharia.ToList());
        }

        [Filtro(Roles = "PCP")]
        public ActionResult Novo()
        {
            ViewBag.ID_MAQUINA = new SelectList(db.MAQUINAS, "ID_MAQUINA", "NOME_MAQUINA");
            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO");

            return View();
        }

        [Filtro(Roles = "PCP")]
        [HttpPost]
        public ActionResult Novo(ORDEM_MALHARIA ordem_malharia)
        {
            if (ModelState.IsValid)
            {
                db.ORDEM_MALHARIA.Add(ordem_malharia);
                db.SaveChanges();
                return RedirectToAction("Programado");
            }

            ViewBag.ID_PRODUTO = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO");
            ViewBag.ID_COR = new SelectList(db.MAQUINAS, "ID_MAQUINAS", "NOME_MAQUINAS");
            return View(ordem_malharia);
        }


        [Filtro(Roles = "PCP")]
        public ActionResult Index()
        {
            return View();
        }

        [Filtro(Roles = "PCP")]
        public ActionResult Emissao(int id = 0)
        {
            ORDEM_MALHARIA ordem_malharia = db.ORDEM_MALHARIA.Find(id);
            if (ordem_malharia == null)
            {
                return HttpNotFound();
            }
            return View(ordem_malharia);
        }


    }
}
