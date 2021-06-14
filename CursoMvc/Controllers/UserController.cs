using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMvc.Models;
using CursoMvc.Models.TableVM;

namespace CursoMvc.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            var usuarios = new List<UsersVM>();
            
            using (CursoMVCEntities db = new CursoMVCEntities())
            {
                usuarios = (from d in db.User
                            where d.idState == 1
                            orderby d.email
                            select new UsersVM
                            {
                                id = d.id,
                                email = d.email,
                                edad = d.edad,
                            }).ToList();
                        
            }
            return View(usuarios);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(NewUser newUser)
        {
            if (!ModelState.IsValid)
            {
                return View(newUser);
            }

            using(var db = new CursoMVCEntities())
            {
                User user = new User();
                user.idState = 1;
                user.email = newUser.Email;
                user.edad = newUser.Edad;
                user.contraseña = newUser.Password;


                db.User.Add(user);
                db.SaveChanges();

            }
            return Redirect(Url.Content("~/User/"));
        }
    }
}