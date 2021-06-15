using CursoMvc.Models.Files;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMvc.Controllers
{
    public class FilesController : Controller
    {
        // GET: Files
        public ActionResult Index()
        {
            if(TempData["Message"] != null)
            {
                ViewBag.Message = TempData["Message"].ToString();
            }
            return View();
        }
        public ActionResult Save(FileVm vm)
        {
            string RutaSitio = Server.MapPath("~/ ");
            string PathArchivo1 = Path.Combine(RutaSitio+"/Files/Archivo1.png");
            string PathArchivo2 = Path.Combine(RutaSitio + "/Files/Archivo2.png");

            if (!ModelState.IsValid)
            {
                return View("index",vm);
            }

            vm.Archivo1.SaveAs(PathArchivo1);
            vm.Archivo2.SaveAs(PathArchivo2);

            @TempData["Message"] = "Se cargaron los archivos";
            return RedirectToAction("index");
        }
    }
}