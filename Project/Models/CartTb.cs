using System;
using System.Collections.Generic;

namespace Art_Gallery.Models
{
    public partial class CartTb
    {
        public int CartId { get; set; }
        public int ProdId { get; set; }
        public int CustId { get; set; }
        public int ProductQuantity { get; set; }
        public int CartStatus { get; set; }
    }
}
