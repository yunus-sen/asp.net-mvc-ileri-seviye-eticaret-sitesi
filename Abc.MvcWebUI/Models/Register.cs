using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Models
{
    public class Register
    {
        [Required]
        [DisplayName("İsim")]
        public string  Name { get; set; }

        [Required]
        [DisplayName(" Soyisim")]
        public string SurName { get; set; }

        [Required]
        [DisplayName(" Kullnacı Adı")]
        public string UserName { get; set; }

        [Required]
        [DisplayName("E-mail")]
        public string Email { get; set; }

        [Required]
        [DisplayName("Paralo")]
        public string Password { get; set; }

        [Required]
        [DisplayName("Paralo Tekrar")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string RePassword { get; set; }
    }
}