using Microsoft.EntityFrameworkCore;
using Bulky.Model.Models;

namespace Bulky.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        public DbSet<Category> Category { get; set; }

//      protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//      {
//          optionsBuilder.UseMySQL("server=localhost;database=bulky; uid=root; pwd=qwerty;");
//      }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, DisplayOrder = 1, Name = "Action" },
                new Category { Id = 2, DisplayOrder = 2, Name = "Drama" },
                new Category { Id = 3, DisplayOrder = 2, Name = "Scifi" },
                new Category { Id = 4, DisplayOrder = 3, Name = "Horror" }
                );
        } 
    }
}