using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherService.Data.Entities;

namespace WeatherService.Data;

// 1. Alteração do modelo
// 2. Criar a migração add-migration <nome-migração>
// 3. Correr migrações update-database

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<City> Cities { get; set; }
    public DbSet<Country> Countries { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }


    #region model configurations

    // https://learn.microsoft.com/en-us/ef/core/modeling/
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
    {
        base.ConfigureConventions(configurationBuilder);

        //configurationBuilder.Properties<DateTime>().HavePrecision(0);
        //configurationBuilder.Properties<string>().HaveMaxLength(1024);
    }

    #endregion model configurations
}