using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Abc.MvcWebUI.Entity
{
    public class Comment
    {
        public int Id { get; set; }
        [Display(Name = "İsim")]
        [Required]
        public String Name { get; set; }
        [Display(Name = "Soyisim")]
        public String Surname { get; set; }
        [Display(Name = "Acıklama")]
        [Required]
        public String Description { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}