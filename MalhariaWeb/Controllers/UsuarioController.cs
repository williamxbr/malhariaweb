using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using MalhariaWeb.Models;
using MalhariaWeb.Roles;
using MalhariaWeb.Utils;

namespace MalhariaWeb.Controllers
{
    public class UsuarioController : Controller
    {

        private ContextDB db = new ContextDB();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(USUARIO usuario)
        {
            if (usuario.isValid(usuario.NOME_USUARIO, usuario.SENHA))
            {
                FormsAuthentication.SetAuthCookie(usuario.NOME_USUARIO, true);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Dados de login está incorreto!");
                return View(usuario);
            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        [Filtro(Roles = "Administrador")]
        public ActionResult Novo()
        {
            return View();
        }

        [HttpPost]
        [Filtro(Roles = "Administrador")]
        public ActionResult Novo(USUARIO usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.SENHA = SHA1.Encode(usuario.SENHA);
                db.USUARIO.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Lista");
            }
            return View();
        }


        [Filtro(Roles = "Administrador")]
        public ActionResult Lista()
        {
            return View(db.USUARIO.ToList());
        }

        public ActionResult AcessoNegado()
        {
            return View();
        }

    }
}
