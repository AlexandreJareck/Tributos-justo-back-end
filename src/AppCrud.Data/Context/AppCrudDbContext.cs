using AppCrud.Business.Models;
using Microsoft.EntityFrameworkCore;

namespace AppCrud.Data.Context;

public class AppCrudDbContext : DbContext
{
    public AppCrudDbContext(DbContextOptions<AppCrudDbContext> options) : base(options)
    {

    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Client> Clients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
            property.SetMaxLength(100); 

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppCrudDbContext).Assembly);

        foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

        base.OnModelCreating(modelBuilder);
    }
}
