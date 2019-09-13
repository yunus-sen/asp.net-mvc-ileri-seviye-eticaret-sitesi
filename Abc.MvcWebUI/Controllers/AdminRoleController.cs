using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Abc.MvcWebUI.Models;

namespace Abc.MvcWebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminRoleController : Controller
    {
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AdminRoleController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDataContext()));
            roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new IdentityDataContext()));
        }

        // GET: AdminRole
        public ActionResult Index()
        {
            return View(roleManager.Roles.ToList());
        }

        public ActionResult Edit(string id)
        {
            var role = roleManager.FindById(id);
            var member = new List<ApplicationUser>();
            var nonmember = new List<ApplicationUser>();

            foreach (var user in userManager.Users.ToList())
            {
                var list = userManager.IsInRole(user.Id, role.Name) ? member : nonmember;
                list.Add(user);
            }

            return View(new RoleUpdata()
            {
                Role = role,
                Members = member,
                NonMembers = nonmember
            });

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(RoleAdminİnfo model)
        {
             IdentityResult result;
            if (ModelState.IsValid)
            {
                foreach (var userid in model.AddToIds??new string[]{})
                {
                    result = userManager.AddToRole(userid, model.Name);
                    if (!result.Succeeded)
                    {
                        return View("Eror", new string[]
                        {
                            " hata oluştu."
                        });
                    }
                }

                foreach (var userid in model.DeleteToIds ?? new string[] { })
                {
                    result = userManager.RemoveFromRole(userid, model.Name);

                    if (!result.Succeeded)
                    {
                        return View("Eror", new string[]
                        {
                            " hata oluştu."
                        });
                    }
                }


                return RedirectToAction("Index");
            }
            else
            {
                return View("Eror",new string[]
                {
                    " hata oluştu."
                });
            }
        }

        public ActionResult Delete(string id)
        {
            var user = userManager.FindById(id);
            var result = userManager.Delete(user);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View("Eror", new string[] {"hata olutu"});
            }
        }

    }
}