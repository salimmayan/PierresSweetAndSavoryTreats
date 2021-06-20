using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PierresSweetAndSavoryTreats.Models
{
  public class PierresSweetAndSavoryTreatsContext : IdentityDbContext<ApplicationUser>
  {
    public virtual DbSet<Treat> Treats { get; set; }
    public virtual DbSet<Flavor> Flavors { get; set; }
    public virtual DbSet<FlavorTreat> FlavorTreats { get; set; }

    public PierresSweetAndSavoryTreatsContext(DbContextOptions options): base(options) { }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
      optionsBuilder.UseLazyLoadingProxies();
    }
  }
}