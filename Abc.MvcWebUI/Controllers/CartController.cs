using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;
using Abc.MvcWebUI.Models;

namespace Abc.MvcWebUI.Controllers
{
    
    public class CartController : Controller
    {
        private DataContext db=new DataContext();
        // GET: Cart
        public ActionResult Index()
        {
            return View(GetCart());
        }

        public ActionResult AddToCart(int Id)
        {
            var product = db.Products.Where(i => i.Id == Id).FirstOrDefault();
            if (product != null)
            {
                GetCart().AddProduckt(product,1);
            }
            return RedirectToAction("Index");
        }

        public ActionResult RemoveFromCart(int Id)
        {
            var product = db.Products.Where(i => i.Id == Id).FirstOrDefault();
            if (product != null)
            {
                GetCart().DeleteProduckt(product);
            }
            return RedirectToAction("Index");
        }
        public Cart GetCart()
        {
            var cart = (Cart) Session["cart"];
            if (cart == null)
            {
                cart =new Cart();
                Session["cart"] = cart;
            }

            return cart;
        }
       
        [ChildActionOnly]
        public PartialViewResult Summary()
        {
            return PartialView("_Summary",GetCart());
        }

        public ActionResult Checkout()
        {
            if (!Request.IsAuthenticated)
            {
                return View("Eror",new string[]{"Lütfen alışverişi tamamlamak icin giriş yapınız"});
            }
            return View(new ShoppingDetails());
        }
        [HttpPost]
        public ActionResult Checkout(ShoppingDetails entity)
        {
            var cart = GetCart();
            if (cart.CartLines.Count == 0)
            {
                ModelState.AddModelError("","sepette ürün yok");
            }

            if (ModelState.IsValid)
            {
                //siparişi veritabanına kaydet
                //ve sepeti sil
                SaveOrder(cart, entity);
                cart.Clear();
                return View("Complated");
            }
            return View(entity);
        }

        private void SaveOrder(Cart cart, ShoppingDetails entity)
        {
            var order =new Order();
            order.OrderNumber="A"+(new Random().Next(11111,99999)).ToString();
            order.Total = cart.Total();
            order.DateTime=DateTime.Now;
            order.UserName = entity.UserName;
            order.AdresBasligi = entity.AdresBasligi;
            order.Adres = entity.Adres;
            order.Sehir = entity.Sehir;
            order.Semt = entity.Semt;
            order.Mahalle = entity.Mahalle;
            order.PostaKodu = entity.PostaKodu;
            order.OrderState = EnumOrderState.Bekleniyor;
            order.OrderLines=new List<OrderLine>();
            foreach (var pr in cart.CartLines)
            {
                var orderline=new OrderLine();
                orderline.Quantity = pr.Quantity;
                orderline.Price = pr.Quantity*pr.Product.Price;
                orderline.ProductId = pr.Product.Id;
                order.OrderLines.Add(orderline);
            }

            db.Orders.Add(order);
            db.SaveChanges(); 
        }
    }
}