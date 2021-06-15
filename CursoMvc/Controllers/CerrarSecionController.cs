using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMvc.Controllers
{
    public class CerrarSecionController : Controller
    {
        public ActionResult Logoff()
        {
            Session["User"] = null;
            return RedirectToAction("index", "Registro");
        }
    }
}