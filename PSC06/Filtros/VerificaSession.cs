using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using PSC06.Models;
using PSC06.Controllers;
using System.Web.Mvc;

namespace PSC06.Filtros
{
	public class VerificaSession : ActionFilterAttribute 
	{
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var miUsuario = (USER)HttpContext.Current.Session["Usuario"];
            if (miUsuario == null)
            {
                if (filterContext.Controller is AccederController == false)
                {
                    filterContext.HttpContext.Response.Redirect("~/Acceder/Login");
                }
            }
            else
            {
                if (filterContext.Controller is AccederController == true)
                {
                    filterContext.HttpContext.Response.Redirect("~/Home/Index");
                }
            }
                base.OnActionExecuting(filterContext);
        }
    }
}