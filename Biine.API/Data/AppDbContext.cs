using Biine.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Biine.API.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Recipe> Recipes => Set<Recipe>();
    public DbSet<Restaurant> Restaurants => Set<Restaurant>();
    public DbSet<Interaction> Interactions => Set<Interaction>();
    public DbSet<Translation> Translations => Set<Translation>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // JSONB columns for ingredients
        modelBuilder.Entity<Recipe>()
            .Property(r => r.IngredientsSv)
            .HasColumnType("jsonb");
        modelBuilder.Entity<Recipe>()
            .Property(r => r.IngredientsEn)
            .HasColumnType("jsonb");

        // Decimal precision for restaurant fields
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.Rating)
            .HasColumnType("decimal(3,2)");
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.Lat)
            .HasColumnType("decimal(10,7)");
        modelBuilder.Entity<Restaurant>()
            .Property(r => r.Lng)
            .HasColumnType("decimal(10,7)");

        // Unique index on Translation.Key
        modelBuilder.Entity<Translation>()
            .HasIndex(t => t.Key)
            .IsUnique();

        // Interaction → Recipe FK
        modelBuilder.Entity<Interaction>()
            .HasOne(i => i.Recipe)
            .WithMany(r => r.Interactions)
            .HasForeignKey(i => i.RecipeId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
