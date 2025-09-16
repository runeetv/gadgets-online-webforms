using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GadgetsOnline.Models;

namespace GadgetsOnline.ViewModel
{
    public class ShoppingCartViewModel
    {
        public List<Models.Cart> CartItems { get; set; }
        public decimal CartTotal { get; set; }
    }
}