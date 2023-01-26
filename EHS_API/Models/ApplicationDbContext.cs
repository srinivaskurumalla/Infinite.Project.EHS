using Microsoft.EntityFrameworkCore;

namespace EHS_API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Add References
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<House> HouseImages { get; set; }
    }
}
