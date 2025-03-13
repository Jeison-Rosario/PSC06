using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PSC06.Models;
using PSC06.Models.ViewModels;

namespace PSC06.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Query()
        {
            List<QueryViewModels> lst = null;

            using (DBMVCEntities db = new DBMVCEntities())
            {
                lst = (from d in db.USERS
                       where d.idEstatus == 1
                       orderby d.Nombre

                       select new QueryViewModels
                       {
                           Id = d.ID,
                           Nombre = d.Nombre,
                           Edad = d.Edad
                       }).ToList(); 
            }

            return View(lst);
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            using (var db = new DBMVCEntities())
            {
                var oUser = db.USERS.Find(Id);
                oUser.idEstatus = 3;

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Content("1");
        }

        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(AddUserViewModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using(var db = new DBMVCEntities())
            {
                USER oUser = new USER();

                oUser.idEstatus = 1;
                oUser.Usuario = model.Nombre;
                oUser.Email = model.Email;
                oUser.Edad = model.Edad;
                oUser.Nombre = model.Nombre;
                oUser.Password = model.Password;

                db.USERS.Add(oUser);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Query"));
        }

        [HttpGet]
        public ActionResult Edit(int Id)
        {
            EditUserViewModels model = new EditUserViewModels();

            using (var db = new DBMVCEntities())
            {
                var oUser = db.USERS.Find(Id);

                model.Nombre = oUser.Nombre;
                model.Password = oUser.Password;
                model.Email = oUser.Email;
                model.Edad = (int)oUser.Edad;
                model.Id = oUser.ID;

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(EditUserViewModels model)
        {
            using (var db = new DBMVCEntities())
            {
                var oUser = db.USERS.Find(model.Id);

                oUser.Email = model.Email;
                oUser.Edad = model.Edad;
                oUser.Nombre = model.Nombre;
                
                if(model.Password != null || model.Password != "")
                {
                    oUser.Password = model.Password;
                }

                db.Entry(oUser).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/User/Query"));
        }
    }
}