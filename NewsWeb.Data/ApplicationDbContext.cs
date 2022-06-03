using Microsoft.EntityFrameworkCore;
using NewsWeb.Models;

namespace NewsWeb.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Links> Link { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "IT"
                        },
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Global"
                        },
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Footbal"
                        }
                    );

        }
    }
}