using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Serialization;

namespace Abc.MvcWebUI.Models
{
    public class ShoppingDetails
    {
       
        public string UserName { get; set; }
        [Required (ErrorMessage = "lütfen Adres basligini giriniz")]
        public string AdresBasligi  { get; set; }
        [Required(ErrorMessage = "lütfen Adres basligini giriniz")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "lütfen Adres basligini giriniz")]
        public string Sehir { get; set; }
        [Required(ErrorMessage = "lütfen Adres basligini giriniz")]
        public string Semt { get; set; }
        [Required(ErrorMessage = "lütfen Adres basligini giriniz")]
        public string Mahalle { get; set; }
        [Required(ErrorMessage = "lütfen Adres basligini giriniz")]
        public string PostaKodu { get; set; }
    }
}