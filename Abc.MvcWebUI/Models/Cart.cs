using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Abc.MvcWebUI.Entity;

namespace Abc.MvcWebUI.Models
{
   
    public class Cart
    {
        private List<CartLine> _cartlines = new List<CartLine>();

        public List<CartLine> CartLines
        {
            get { return _cartlines; }
        }

        public void AddProduckt(Product product, int quantity)
        {
            var line = _cartlines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line == null)
            {
                _cartlines.Add(new CartLine() { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void DeleteProduckt(Product product)
        {
            var line = _cartlines.FirstOrDefault(i => i.Product.Id == product.Id);
            if (line.Quantity > 1)
            {
                line.Quantity -= 1;
            }
            else
            {
                _cartlines.RemoveAll(i => i.Product.Id == product.Id);
            }


        }

        public Double Total()
        {
            if (_cartlines.Count == 0)
            {
                return 0;
            }
            else
            {
                return _cartlines.Sum(i=>i.Product.Price*i.Quantity);
            }
        }

        public void Clear()
        {
            _cartlines.Clear();
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}