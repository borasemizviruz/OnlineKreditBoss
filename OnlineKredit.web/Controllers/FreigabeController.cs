using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineKredit.web.Controllers
{
    public class FreigabeController : Controller
    {
        // GET: Freigabe
        public ActionResult Index(bool erfolgreich)
        {
            Debug.WriteLine("");
            Debug.Indent();

            Debug.Unindent();
            return View(erfolgreich);
        }
    }
}