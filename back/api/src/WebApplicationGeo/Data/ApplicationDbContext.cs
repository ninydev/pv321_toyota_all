using WebApplicationGeo.Models.Cars.Toyota;
using WebApplicationGeo.Models.Entities.Geo;

namespace WebApplicationGeo.Data;
using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public DbSet<ToyotaModel> ToyotaModels { get; set; }
    
    public DbSet<ConfigurationModel> Configurations { get; set; }
    
    public DbSet<ConfigurationColorsModel> ConfigurationColors { get; set; }
    
    
    public DbSet<ColorModel> Colors { get; set; }
    
    
    public DbSet<CountryModel> Countries { get; set; }
    public DbSet<AreaModel> Areas { get; set; }
    public DbSet<CityModel> Cities { get; set; }
    public DbSet<RegionModel> Regions { get; set; }
    
    
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Настройка отношения один ко многим между AreaModel и CityModel
        modelBuilder.Entity<AreaModel>()
            .HasMany(a => a.Cities)  // Связь с коллекцией Cities
            .WithOne(c => c.Area)     // Обратная связь с Area в CityModel
            .HasForeignKey(c => c.AreaId)  // Указание внешнего ключа в CityModel
            .OnDelete(DeleteBehavior.Restrict);  // Выберите поведение при удалении
    }
}