using FiorelloClone.Models;
using Microsoft.EntityFrameworkCore;

namespace FiorelloClone.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<SliderDetail> SliderDetails { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductImage> ProductImages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ProductDetail> ProductDetails { get; set; }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Setting> Settings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<Blog>().HasKey(m=>m.Id);
        modelBuilder.Entity<Blog>().HasQueryFilter(b => !b.IsDeleted);
        modelBuilder.Entity<Blog>()
            .HasData
            (
                new Blog
                {
                    Id = 1,
                    Title = "Flower Power",
                    Description = "This is the description for blog post 1.",
                    Image = "blog-feature-img-1.jpg",
                    IsDeleted = false,
                    CreatedAt = new DateTime(2025, 12, 12),
                    UpdatedAt = new DateTime(2025, 12, 12)
                },

                new Blog
                {
                    Id = 2,
                    Title = "Local Florists",
                    Description = "This is the description for blog post 1.",
                    Image = "blog-feature-img-3.jpg",
                    IsDeleted = false,
                    CreatedAt = new DateTime(2025, 12, 12),
                    UpdatedAt = new DateTime(2025, 12, 12)
                },
                new Blog
                {
                    Id = 3,
                    Title = "Flower Beauty",
                    Description = "This is the description for blog post 1.",
                    Image = "blog-feature-img-4.jpg",
                    IsDeleted = false,
                    CreatedAt = new DateTime(2025, 12, 12),
                    UpdatedAt = new DateTime(2025, 12, 12)
                }
            );
    }
}
