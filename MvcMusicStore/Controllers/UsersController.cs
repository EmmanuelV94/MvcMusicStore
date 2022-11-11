using MvcMusicStore.Models;
using MvcMusicStore.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MvcMusicStore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class UsersController : Controller
    {
        MusicStoreEntities storeDB = new MusicStoreEntities();

        // GET: Users
        public ActionResult Index()
        {
            return View(storeDB.Users.Where(x=>x.UserName == "Administrador").ToList());
        }

        // GET: Users/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserFormViewModel user = storeDB.Users.Where(x => x.Id == id).Select(x => new UserFormViewModel
            {
                Id = x.Id,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
                UserName = x.PhoneNumber,
                RoleId = x.Roles.FirstOrDefault().RoleId
            }).FirstOrDefault();
            if (user == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(storeDB.Roles, "Id", "Name", user.RoleId);
            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        public ActionResult Edit(string id, UserFormViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = storeDB.Users.FirstOrDefault(x => x.Id == model.Id);
                user.PhoneNumber = model.PhoneNumber;
                user.Email = model.Email;
                user.UserName = model.UserName;
                user.Roles.Clear();
                user.Roles.Add(new Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole()
                {
                    RoleId = model.RoleId,
                    UserId = model.Id
                });
                storeDB.Entry(user).State = EntityState.Modified;
                storeDB.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreId = new SelectList(storeDB.Roles, "Id", "Name", model.RoleId);
            return View(model);

        }
    }
}
