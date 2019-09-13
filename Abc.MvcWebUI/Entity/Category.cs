using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Category
    {
       
        public int Id { get; set; }
        [DisplayName("Kategori ismi")]
        [Required(ErrorMessage = " Lütfen kategori adını giriniz.")]
        public string Name { get; set; }
        [DisplayName("Kategori acıklaması")]
        [Required(ErrorMessage = "Lütfen kategori acıklaması giriniz")]
        public string Description { get; set; }
        public List<Product>Products  { get; set; }



    }
}