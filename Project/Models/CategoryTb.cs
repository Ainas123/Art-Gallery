using System;
using System.Collections.Generic;

namespace Art_Gallery.Models
{
    public partial class CategoryTb
    {
        public CategoryTb()
        {
            ProductTbs = new HashSet<ProductTb>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = null!;

        public virtual ICollection<ProductTb> ProductTbs { get; set; }
    }
}
