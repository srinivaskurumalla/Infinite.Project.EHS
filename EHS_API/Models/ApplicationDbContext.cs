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
        public DbSet<HouseImage> HouseImages { get; set; }

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
    }
}
