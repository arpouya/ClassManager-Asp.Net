using Microsoft.EntityFrameworkCore;
namespace ClassManager.Models
{
    public class AppDbContext : DbContext
    {

        public DbSet<Students> Student { get; set; }
        public DbSet<Classes> Class { get; set; }
        public DbSet<Report> Report { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string desktopaddress = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            optionsBuilder.UseSqlite($"Data Source={desktopaddress}\\appclass.db;");
        }

    }
}
