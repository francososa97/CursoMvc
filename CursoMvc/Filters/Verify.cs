using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CursoMvc.Controllers;
using CursoMvc.Models;

namespace CursoMvc.Filters
{
    public class Verify : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var user = (User)HttpContext.Current.Session["User"];

            if(user == null)
            {
                if(filterContext.Controller is RegistroController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Registro/Index");
                }
            }
            else
            {
                if(filterContext.Controller is RegistroController == true)
                {
                    filterContext.HttpContext.Response.Redirect("Home/Index");
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}