using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CursoMvc.Controllers
{
    public class AnimalsController : Controller
    {
        // GET: Animals
        public ActionResult Index()
        {
            //llenar el combobox en cascada

            //forma uno  llenar el padre
            List<SelectListItem> ListPadre = new List<SelectListItem>();

            using (Models.CursoMVCEntities db = new Models.CursoMVCEntities()){

                ListPadre = (from d in db.Animales
                             select new SelectListItem()
                             {
                                 Value = d.Id.ToString(),
                                 Text = d.Name
                             }).ToList();
            }

            return View(ListPadre);
        }
        [HttpGet]
        public JsonResult Animal(int idAnimalClass)
        {
            List<ElementJsonIntKey> AnimalClasses = new List<ElementJsonIntKey>();

            using (Models.CursoMVCEntities db = new Models.CursoMVCEntities())
            {
                AnimalClasses = (from d in db.Animals
                                 where d.IdAnimal == idAnimalClass
                                 select new ElementJsonIntKey
                                 {
                                     Id = d.Id,
                                     Value = d.Name,
                                 }
                                 ).ToList();
            }
            return Json(AnimalClasses, JsonRequestBehavior.AllowGet);
        }

        #region Metodos Privados
        private class ElementJsonIntKey
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }

        #endregion
    }
}