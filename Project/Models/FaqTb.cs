using System;
using System.Collections.Generic;

namespace Art_Gallery.Models
{
    public partial class FaqTb
    {
        public int FaqId { get; set; }
        public string FaqName { get; set; } = null!;
        public string FaqAnswer { get; set; } = null!;
    }
}
