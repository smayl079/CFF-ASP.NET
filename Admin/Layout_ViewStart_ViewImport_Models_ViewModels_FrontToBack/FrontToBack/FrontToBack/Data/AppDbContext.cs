using FrontToBack.Models;
using Microsoft.EntityFrameworkCore;

namespace FrontToBack.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    public DbSet<OurWork> OurWorks { get; set; }
    public DbSet<Category> Categories { get; set; }
}
