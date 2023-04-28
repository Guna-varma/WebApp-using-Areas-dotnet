using Microsoft.EntityFrameworkCore;
using WeabApp_Razor.Models;

namespace WeabApp_Razor.Data
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
                new Category { Id = 1, DisplayOrder = 1, Name = "Action" }
                );
        }
    }
}
