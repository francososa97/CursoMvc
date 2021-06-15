using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMvc.Models;
using CursoMvc.Models.TableVM;
using CursoMvc.Models.Users;

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

        [HttpGet]
        public ActionResult Put(int id)
        {
            PutUser userEdit = new PutUser();
            using (var db = new CursoMVCEntities())
            {
                var user = db.User.Find(id);
                userEdit.Edad = (int)user.edad;
                userEdit.Email = user.email;
                userEdit.Id = user.id;
            }
            return View();
        }
        [HttpPost]
        public ActionResult Put(PutUser userEdit)
        {
            if (!ModelState.IsValid)
            {
                return View(userEdit);
            }

            using (var db = new CursoMVCEntities())
            {
                var user = db.User.Find(userEdit.Id);
                user.edad = userEdit.Edad;
                user.email = userEdit.Email;
                user.id = userEdit.Id;

                if(userEdit.Password != null && userEdit.Password.Trim() != "")
                {
                    user.contraseña = userEdit.Password;
                }

                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/"));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {

            using (var db = new CursoMVCEntities())
            {
                var user = db.User.Find(id);
                user.idState = 3; //Eliminaremos
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }
    }
}