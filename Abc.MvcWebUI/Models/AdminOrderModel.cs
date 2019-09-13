using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abc.MvcWebUI.Entity;

namespace Abc.MvcWebUI.Models
{
    public class AdminOrderModel
    {
        public int Id { get; set; }
        public int Count { get; set; }
        public string OrderNumber { get; set; }
        public double Total { get; set; }
        public string UserName { get; set; }
        public DateTime DateTime { get; set; }
        public EnumOrderState OrderState { get; set; }
    }
}