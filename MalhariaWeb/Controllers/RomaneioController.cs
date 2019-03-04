using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MalhariaWeb.Models;

namespace MalhariaWeb.Controllers
{
    public class RomaneioController : Controller
    {

        private ContextDB db = new ContextDB();


        [HttpGet]
        public ActionResult GerarRomaneio()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GerarRomaneio(FormCollection form)
        {
            return View();
        }

        //
        // GET: /Romaneio/

        public ActionResult Index()
        {
            return View();
        }

    }
}
