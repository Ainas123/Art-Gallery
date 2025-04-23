using System;
using System.Collections.Generic;

namespace Art_Gallery.Models
{
    public partial class AdminTb
    {
        public int AdminId { get; set; }
        public string AdminName { get; set; } = null!;
        public string AdminEmail { get; set; } = null!;
        public string AdminPassword { get; set; } = null!;
        public string AdminImage { get; set; } = null!;
    }
}
