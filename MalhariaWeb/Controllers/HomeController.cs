using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MalhariaWeb.Models;

namespace MalhariaWeb.Controllers
{
    public class HomeController : Controller
    {
        private ContextDB db = new ContextDB();
        //
        // GET: /Home/
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

    }
}
