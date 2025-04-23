using System;
using System.Collections.Generic;

namespace Art_Gallery.Models
{
    public partial class UserProductTb
    {
        internal string uproduct_image;

        public int UpId { get; set; }
        public string UpName { get; set; } = null!;
        public string UpPrice { get; set; } = null!;
        public string UpDescription { get; set; } = null!;
        public string UpImage { get; set; } = null!;
        public int CatId { get; set; }
    }
}
