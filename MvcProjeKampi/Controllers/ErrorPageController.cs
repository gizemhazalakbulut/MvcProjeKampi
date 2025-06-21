using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProjeKampi.Controllers
{
    public class ErrorPageController : Controller
    {
        // GET: ErrorPage
        public ActionResult Page403()
        {
            Response.StatusCode = 403; // HTTP 403 Forbidden
            Response.TrySkipIisCustomErrors = true; // IIS özel hatalarını atla
            return View();
        }

        public ActionResult Page404()
        {
            Response.StatusCode = 404; // HTTP 403 Forbidden
            Response.TrySkipIisCustomErrors = true; // IIS özel hatalarını atla
            return View();
        }
    }
}