using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MalhariaWeb.Models;
using MalhariaWeb.Roles;

namespace MalhariaWeb.Controllers
{
    public class ItensPedidoController : Controller
    {
        private ContextDB db = new ContextDB();
        //
        // GET: /ItensPedido/
        [Filtro(Roles = "Vendas")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Filtro(Roles = "Vendas")]
        public ActionResult InserirItens(FormCollection form)
        {
            int idPedido = Convert.ToInt32(form["ID_PEDIDO"]);
            int idProduto = Convert.ToInt32(form["Produto"]);
            int iQuantidade = Convert.ToInt32(form["Quantidade"]);
            double dPreco = Convert.ToDouble(form["Preco"]);
            int iCor = Convert.ToInt32(form["Cor"]);
            double dDesconto = 0;
            if  (form["Desconto"] != "")
            {
                dDesconto = Convert.ToDouble(form["Desconto"]);
            }

            try
            {

                ITENSPEDIDO itenspedido = new ITENSPEDIDO();

                itenspedido.ID_PEDIDO = idPedido;
                itenspedido.ID_PRODUTO = idProduto;
                itenspedido.QUANTIDADE = iQuantidade;
                itenspedido.PRECO = dPreco;
                itenspedido.ID_COR = iCor;
                itenspedido.DESCONTO = dDesconto;

                db.ITENSPEDIDO.Add(itenspedido);

                db.SaveChanges();
            }
            catch (Exception err)
            {
                ModelState.AddModelError("", "Failed On Id " + idPedido.ToString() + " : " + err.Message);
                return View();
            }

            return RedirectToAction("Itens", "Pedido", new { id = idPedido });
        }

    }
}
