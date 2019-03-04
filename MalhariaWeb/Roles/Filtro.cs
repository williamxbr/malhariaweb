using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MalhariaWeb.Roles
{
    public class Filtro : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext filterContext)
        {
            base.OnAuthorization(filterContext);

            if (filterContext.Result is HttpUnauthorizedResult && filterContext.HttpContext.Request.IsAuthenticated)
                filterContext.HttpContext.Response.Redirect("/Usuario/AcessoNegado");
        }
    }
}