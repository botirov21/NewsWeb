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
                            Id = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
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

            modelBuilder.Entity<News>()
                .HasData(
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        },
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        },
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        },
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        },
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        },
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        },
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        },
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        },
                        new News()
                        {
                            Id = Guid.NewGuid(),
                            CategoryId = Guid.Parse("6ff3bb66-b37e-4b73-9472-b8c35a4f5881"),
                            Title = "Today is a good day!",
                            Body = "❗️Бирор егуликка нисбатан кучли хоҳиш организмда қайсидир модда етишмаслигидан дарак беради.",
                            CreatedTime = DateTime.Now,
                            Images = "trending/trending_bottom1.jpg",
                            Links = "",
                            NumberOfViewers = 12
                        }

                );
        }
    }
}