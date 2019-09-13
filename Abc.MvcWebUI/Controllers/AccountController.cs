using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Identity;
using Abc.MvcWebUI.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace Abc.MvcWebUI.Controllers
{
    public class AccountController : Controller
    {
        private DataContext db=new DataContext();
        private UserManager<ApplicationUser> userManager;
        private RoleManager<ApplicationRole> roleManager;

        public AccountController()
        {
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new IdentityDataContext()));
            roleManager = new RoleManager<ApplicationRole>(new RoleStore<ApplicationRole>(new IdentityDataContext()));
        }
        [Authorize]
        public ActionResult Index()
        {
            var user = User.Identity.Name;
            var order = db.Orders.Where(i=>i.UserName==user).Select(i => new UserOrderModel()
            {
                Id = i.Id,
                Total = i.Total,
                UserName = i.UserName,
                DateTime = i.DateTime,
                OrderState = i.OrderState,
                OrderNumber = i.OrderNumber
            }).OrderByDescending(i=>i.DateTime).ToList();

            return View(order);
        }
        [Authorize]
        public ActionResult Details(int Id)
        {
            var product = db.Orders.Where(i => i.Id == Id)
                .Select(i => new OrderDetailsModel()
                {
                    OrderId = i.Id,
                    OrderNumber = i.OrderNumber,
                    Total = i.Total,
                    DateTime = i.DateTime,
                    OrderState = i.OrderState,
                    AdresBasligi = i.AdresBasligi,
                    Adres = i.Adres,
                    Mahalle = i.Mahalle,
                    Sehir = i.Sehir,
                    Semt = i.Semt,
                    PostaKodu = i.PostaKodu,
                    OrderLines = i.OrderLines.Select(a => new OrderLineModel()
                    {
                        Quantity = a.Quantity,
                        Price = a.Price,
                        Images = a.Product.Image,
                        ProductId = a.ProductId,
                        ProductName = a.Product.Name
                    }).ToList()

                }).FirstOrDefault();

            return View(product);
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser();
                user.Name = model.Name;
                user.SurName = model.SurName;
                user.Email = model.Email;
                user.UserName = model.UserName;
                var result = userManager.Create(user, model.Password);
                if (result.Succeeded)
                {
                    if (roleManager.RoleExists("user"))
                    {
                        userManager.AddToRole(user.Id, "user");
                    }

                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("RegisterUserEror", "Kullanıcı oluşturulurken hata oluştu.");
                }
            }
            return View(model);
        }

        public ActionResult Login(string ReturnUrl)
        {
            if (Request.IsAuthenticated)
            {
                return View("Eror", new string[] { "Yetkisiz Giriş" });
            }

          

            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult login(Login model, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = userManager.Find(model.UserName, model.Password);
                if (user != null)
                {
                    var authManager = HttpContext.GetOwinContext().Authentication;
                    var identity = userManager.CreateIdentity(user, "ApplicationCookie");
                    var authProperties = new AuthenticationProperties()
                    {
                        IsPersistent = model.RememberMe
                    };

                    authManager.SignOut();
                    authManager.SignIn(authProperties, identity);
                    if (userManager.IsInRole(user.Id, "admin"))
                    {
                        return Redirect(string.IsNullOrEmpty(ReturnUrl) ? "/AdminRole/Index" : ReturnUrl);
                    }
                    else
                    {
                        return Redirect(string.IsNullOrEmpty(ReturnUrl) ? "/Home/Index" : ReturnUrl);
                    }

                }
                else
                {
                    ModelState.AddModelError("", "kullanıcı adı veya paralo yanlış.");
                }

            }

            ViewBag.ReturnUrl = ReturnUrl;
            return View(model);
        }

        public ActionResult Logout()
        {
            var authManager = HttpContext.GetOwinContext().Authentication;
            authManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

    }
}