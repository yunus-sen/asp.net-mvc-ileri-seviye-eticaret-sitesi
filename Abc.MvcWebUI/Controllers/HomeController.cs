using Abc.MvcWebUI.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Models;

namespace Abc.MvcWebUI.Controllers
{
    public class HomeController : Controller
    {
        private DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var urunler = db.Products.Where(i => i.IsHome && i.IsApproved).Select(i => new ProductModel()
            {
                Id = i.Id,
                Image = i.Image,
                Name = i.Name,
                Stock = i.Stock,
                Description = i.Description.Substring(0,80) + "...",
                //IsHome = i.IsHome,
                //IsApproved = i.IsApproved,
                Price = i.Price,
                CategoryId = i.CategoryId
            }).ToList();

            return View(urunler);
        }

        public ActionResult Details(int id)
        {
            var product = db.Products.Where(i => i.Id == id).FirstOrDefault();
            ViewBag.Comments = db.Comments.Where(i => i.ProductId == id).ToList();
            return View(product);
        }

        public ActionResult List(int? id)
        {
            var urunler = db.Products.Where(a => a.IsApproved).Select(a => new ProductModel()
            {
                Id = a.Id,
                Image = a.Image,
                Name = a.Name,
                Stock = a.Stock,
                Description = a.Description.Substring(0, 80) + "...",
                //IsHome = i.IsHome,
                //IsApproved = i.IsApproved,
                Price = a.Price,
                CategoryId = a.CategoryId
            }).AsQueryable();
            if (id == null)
            {
                return View(urunler.ToList());
            }
            else
            {
                urunler = urunler.Where(i => i.CategoryId == id);
                return View(urunler.ToList());
            }
        }
       
        [ChildActionOnly]
        public PartialViewResult _GetCategories()
        {
            var kategoriler = db.Categories.Select(i => new CategoryModel()
            {
                Name = i.Name,
                CategoryCaunt = i.Products.Count(),
                Id = i.Id
            })
                .ToList();
            return PartialView("_GetCategories", kategoriler);
        }
    }
}