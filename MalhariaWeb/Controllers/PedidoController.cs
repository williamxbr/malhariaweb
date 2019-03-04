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
    public class PedidoController : Controller
    {
        private ContextDB db = new ContextDB();

        //
        // GET: /Pedido/

        [Filtro(Roles = "Vendas")]
        public ActionResult Index()
        {
            return View(db.PEDIDO.ToList());
        }

        [Filtro(Roles = "Vendas")]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [Filtro(Roles = "Vendas")]
        public ActionResult Novo(PEDIDO pedido)
        {
            if (ModelState.IsValid)
            {
                pedido.DATA_PEDIDO = DateTime.Now;
                db.PEDIDO.Add(pedido);
                db.SaveChanges();
                return RedirectToAction("Itens", new { id = pedido.ID_PEDIDO});
            }
            return View(pedido);
        }

        [Filtro(Roles = "Vendas")]
        public ActionResult Itens(int id)
        {
            PEDIDO pedido = db.PEDIDO.Find(id);
            List<ITENSPEDIDO> itenspedido = db.ITENSPEDIDO.Include(p => p.PRODUTO).Include(p => p.COR).Where(p => p.ID_PEDIDO == id).ToList();
            pedido.ITENSPEDIDO = itenspedido;
            if (pedido == null)
            {
                return HttpNotFound();
            }
            ViewBag.sProduto = new SelectList(db.PRODUTO, "ID_PRODUTO", "NOME_PRODUTO");
            ViewBag.sCor = new SelectList(db.COR, "ID_COR", "NOME_COR");
            
            return View(pedido);
        }


    }
}
