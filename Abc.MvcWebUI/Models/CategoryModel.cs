using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string  Name { get; set; }
        public int CategoryCaunt { get; set; }
        public List<ProductModel> Products { get; set; }     
    }
}