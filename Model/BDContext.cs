using Microsoft.EntityFrameworkCore;

namespace Pharmacy.Model
{
    internal class BDContext : DbContext
    {
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MV43C0T;Database=Pharmacy;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
