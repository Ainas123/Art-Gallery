using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Art_Gallery.Models
{
    public partial class art_gallery_dbContext : DbContext
    {
        public art_gallery_dbContext()
        {
        }

        public art_gallery_dbContext(DbContextOptions<art_gallery_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AdminTb> AdminTbs { get; set; } = null!;
        public virtual DbSet<CartTb> CartTbs { get; set; } = null!;
        public virtual DbSet<CategoryTb> CategoryTbs { get; set; } = null!;
        public virtual DbSet<FaqTb> FaqTbs { get; set; } = null!;
        public virtual DbSet<FeedbackTb> FeedbackTbs { get; set; } = null!;
        public virtual DbSet<ProductTb> ProductTbs { get; set; } = null!;
        public virtual DbSet<UserProductTb> UserProductTbs { get; set; } = null!;
        public virtual DbSet<UserTb> UserTbs { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-B71VTA3\\SQLEXPRESS;Database=art_gallery_db;Trusted_Connection=True;TrustServerCertificate=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AdminTb>(entity =>
            {
                entity.HasKey(e => e.AdminId);

                entity.ToTable("adminTb");

                entity.Property(e => e.AdminId).HasColumnName("admin_id");

                entity.Property(e => e.AdminEmail).HasColumnName("admin_email");

                entity.Property(e => e.AdminImage).HasColumnName("admin_image");

                entity.Property(e => e.AdminName).HasColumnName("admin_name");

                entity.Property(e => e.AdminPassword).HasColumnName("admin_password");
            });

            modelBuilder.Entity<CartTb>(entity =>
            {
                entity.HasKey(e => e.CartId);

                entity.ToTable("cartTb");

                entity.Property(e => e.CartId).HasColumnName("cart_id");

                entity.Property(e => e.CartStatus).HasColumnName("cart_status");

                entity.Property(e => e.CustId).HasColumnName("cust_id");

                entity.Property(e => e.ProdId).HasColumnName("prod_id");

                entity.Property(e => e.ProductQuantity).HasColumnName("product_quantity");
            });

            modelBuilder.Entity<CategoryTb>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("categoryTb");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.CategoryName).HasColumnName("category_name");
            });

            modelBuilder.Entity<FaqTb>(entity =>
            {
                entity.HasKey(e => e.FaqId);

                entity.ToTable("faqTb");

                entity.Property(e => e.FaqId).HasColumnName("faq_id");

                entity.Property(e => e.FaqAnswer).HasColumnName("faq_answer");

                entity.Property(e => e.FaqName).HasColumnName("faq_name");
            });

            modelBuilder.Entity<FeedbackTb>(entity =>
            {
                entity.HasKey(e => e.FeedbackId);

                entity.ToTable("feedbackTbs");

                entity.Property(e => e.FeedbackId).HasColumnName("feedback_id");

                entity.Property(e => e.UserCountry)
                    .HasColumnName("user_country")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.UserEmail)
                    .HasColumnName("user_email")
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.UserMessage).HasColumnName("user_message");

                entity.Property(e => e.UserName).HasColumnName("user_name");
            });

            modelBuilder.Entity<ProductTb>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("productTbs");

                entity.HasIndex(e => e.CatId, "IX_productTbs_cat_id");

                entity.Property(e => e.ProductId).HasColumnName("product_id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.ProductDescription).HasColumnName("product_description");

                entity.Property(e => e.ProductImage).HasColumnName("product_image");

                entity.Property(e => e.ProductName).HasColumnName("product_name");

                entity.Property(e => e.ProductPrice).HasColumnName("product_price");

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.ProductTbs)
                    .HasForeignKey(d => d.CatId);
            });

            modelBuilder.Entity<UserProductTb>(entity =>
            {
                entity.HasKey(e => e.UpId);

                entity.ToTable("User_ProductTb");

                entity.Property(e => e.UpId).HasColumnName("up_id");

                entity.Property(e => e.CatId).HasColumnName("cat_id");

                entity.Property(e => e.UpDescription)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("up_description");

                entity.Property(e => e.UpImage)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("up_image");

                entity.Property(e => e.UpName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("up_name");

                entity.Property(e => e.UpPrice)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("up_price");
            });

            modelBuilder.Entity<UserTb>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.ToTable("userTb");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.Property(e => e.UserAddress).HasColumnName("user_address");

                entity.Property(e => e.UserCity).HasColumnName("user_city");

                entity.Property(e => e.UserCountry).HasColumnName("user_country");

                entity.Property(e => e.UserEmail).HasColumnName("user_email");

                entity.Property(e => e.UserGender).HasColumnName("user_gender");

                entity.Property(e => e.UserImage).HasColumnName("user_image");

                entity.Property(e => e.UserName).HasColumnName("user_name");

                entity.Property(e => e.UserPassword).HasColumnName("user_password");

                entity.Property(e => e.UserPhone).HasColumnName("user_phone");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
