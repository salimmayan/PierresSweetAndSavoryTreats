using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace PierresSweetAndSavoryTreats.Models
{
  public class PierresSweetAndSavoryTreatsContextFactory : IDesignTimeDbContextFactory<PierresSweetAndSavoryTreatsContext>
  {
    PierresSweetAndSavoryTreatsContext IDesignTimeDbContextFactory<PierresSweetAndSavoryTreatsContext>.CreateDbContext(string[] args)
    {
      IConfiguration configuration = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
      
      var builder = new DbContextOptionsBuilder<PierresSweetAndSavoryTreatsContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new PierresSweetAndSavoryTreatsContext(builder.Options);
    }
  }
}