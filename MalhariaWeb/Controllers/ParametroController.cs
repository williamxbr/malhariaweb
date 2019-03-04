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
    public class ParametroController : Controller
    {
        private ContextDB db = new ContextDB();
        //
        // GET: /Parametro/

        [Filtro(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View(db.PARAMETRO.ToList());
        }
        [Authorize]
        public ActionResult Altera(int id = 0)
        {
            PARAMETRO parametro = db.PARAMETRO.Find(id);
            if (parametro == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_DEPOSITO_CRU = new SelectList(db.DEPOSITO.Where(b => b.TIPO_DEPOSITO == eTipoDeposito.Cru), "ID_DEPOSITO", "NOME_DEPOSITO", parametro.ID_DEPOSITO_CRU);
            ViewBag.ID_DEPOSITO_ACABADO = new SelectList(db.DEPOSITO.Where(b => b.TIPO_DEPOSITO == eTipoDeposito.Acabado), "ID_DEPOSITO", "NOME_DEPOSITO", parametro.ID_DEPOSITO_ACABADO);
            return View(parametro);
        }

        [HttpPost]
        [Filtro(Roles = "Administrador")]
        public ActionResult Altera(PARAMETRO parametro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parametro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index"); 
            }
            ViewBag.ID_DEPOSITO_CRU = new SelectList(db.DEPOSITO.Where(b => b.TIPO_DEPOSITO == eTipoDeposito.Cru), "ID_DEPOSITO", "NOME_DEPOSITO", parametro.ID_DEPOSITO_CRU);
            ViewBag.ID_DEPOSITO_ACABADO = new SelectList(db.DEPOSITO.Where(b => b.TIPO_DEPOSITO == eTipoDeposito.Acabado), "ID_DEPOSITO", "NOME_DEPOSITO", parametro.ID_DEPOSITO_ACABADO);
            return View(parametro);
        }



    }
}
