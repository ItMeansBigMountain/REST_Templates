using Microsoft.EntityFrameworkCore;
using MyRestApi.Features.UserAccounts.Models;
using MyRestApi.Features.BooksLibrary.Models;

namespace MyRestApi.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Additional configuration for the entities can be added here
        }
    }
}
