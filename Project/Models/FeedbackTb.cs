using System;
using System.Collections.Generic;

namespace Art_Gallery.Models
{
    public partial class FeedbackTb
    {
        public int FeedbackId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserMessage { get; set; } = null!;
        public string UserEmail { get; set; } = null!;
        public string UserCountry { get; set; } = null!;
    }
}
