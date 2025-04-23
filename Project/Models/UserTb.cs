using System;
using System.Collections.Generic;

namespace Art_Gallery.Models
{
    public partial class UserTb
    {
        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserPhone { get; set; }
        public string? UserEmail { get; set; }
        public string? UserPassword { get; set; }
        public string? UserGender { get; set; }
        public string? UserCountry { get; set; }
        public string? UserCity { get; set; }
        public string? UserAddress { get; set; }
        public string? UserImage { get; set; }
    }
}
