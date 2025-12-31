using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Task3.Models;
using Task3.Models.Base;

namespace Task3.Context;

public class AppDbContext:DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<HomeVM> HomeVMs { get; set; }


}
