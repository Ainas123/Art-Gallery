using System;
using System.Collections.Generic;

namespace Art_Gallery.Models
{
    public partial class ProductTb
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public string ProductPrice { get; set; } = null!;
        public string ProductDescription { get; set; } = null!;
        public string ProductImage { get; set; } = null!;
        public int CatId { get; set; }

        public virtual CategoryTb Cat { get; set; } = null!;
    }
}
