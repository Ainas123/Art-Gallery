using Microsoft.EntityFrameworkCore;

namespace Art_Gallery.Models
{
    public class artGallery : DbContext
    {
        public artGallery(DbContextOptions<artGallery> options) : base(options) 
        {

        }    
        public DbSet<AdminTb> adminTb {  get; set; }
        public DbSet<UserTb> userTb { get; set; }
        public DbSet<CategoryTb> categoryTb { get; set; }
        public DbSet<ProductTb> productTbs { get; set; }
        public DbSet<CartTb> cartTb { get; set; }
        public DbSet<FeedbackTb> feedbackTbs { get; set; }
        public DbSet<FaqTb> faqTb { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductTb>().HasOne(p=>p.Category).WithMany(c=>c.products).HasForeignKey(p=>p.cat_id);
        }
       

    }
}
