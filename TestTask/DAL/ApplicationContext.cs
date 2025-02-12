using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    internal class ApplicationContext : DbContext
    {
        public DbSet<Image> Images { get; set; } = null!;
        public DbSet<ImageInfo> ImageInfos { get; set; } = null!;
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=testappdb;Trusted_Connection=True;");
        }
    }
}
