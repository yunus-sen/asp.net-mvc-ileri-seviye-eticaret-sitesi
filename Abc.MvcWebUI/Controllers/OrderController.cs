using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Models;

namespace Abc.MvcWebUI.Controllers
{
    [Authorize(Roles = "admin")]
    public class OrderController : Controller
    {
        private DataContext db=new DataContext();
        // GET: Order
        public ActionResult Index()
        {
            var orders = db.Orders.Select(i => new AdminOrderModel()
            {
                Id = i.Id,
                OrderNumber = i.OrderNumber,
                OrderState = i.OrderState,
                DateTime = i.DateTime,
                Total = i.Total,
                Count = i.OrderLines.Count
            }).ToList();

            return View(orders);
        }

        public ActionResult Details(int Id)
        {
            var product = db.Orders.Where(i => i.Id == Id)
                .Select(i => new OrderDetailsModel()
                {
                    UserName = i.UserName,
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

        public ActionResult UpdateOrderState(int OrderId, EnumOrderState OrderState)
        {
            var order = db.Orders.FirstOrDefault(i => i.Id == OrderId);
            if (order != null)
            {
              
                order.OrderState = OrderState;
                db.SaveChanges();
                TempData["message"] = "Bilgileriniz Kayıt Edildi.";
                return RedirectToAction("Details",new{id=OrderId});
            }

            return View("Index");
        }
    }
}