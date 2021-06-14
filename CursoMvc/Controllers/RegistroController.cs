using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMvc.Models;

namespace CursoMvc.Controllers
{
    public class RegistroController : Controller
    {
        // GET: Registro
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Enter ( string nameusuario, string contraseña)
        {
            try
            {

                using (CursoMVCEntities db = new CursoMVCEntities())
                {
                    var usuariosValidados = from usuario in db.User
                                        where usuario.email == nameusuario && usuario.contraseña == contraseña && usuario.idState == 1
                                        select usuario;
                    if(usuariosValidados.Any())
                    {
                        User usuario = usuariosValidados.First();
                        Session["user"] = usuario;
                        return Content("1");

                    }
                    else
                    {
                        return Content("usuario incorrecto");
                    }
                }
            }
            catch (Exception ex)
            {
                return Content($"ocurrio el error : {ex.Message}");
            }
        }
    }
}