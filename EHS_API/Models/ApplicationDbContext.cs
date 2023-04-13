using Microsoft.EntityFrameworkCore;

namespace EHS_API.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Add References
        //seller part
       // public DbSet<Seller> Sellers { get; set; }
        public DbSet<House> Houses { get; set; }
        public DbSet<HouseImage> HouseImages { get; set; }

        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        //admin part
        public DbSet<AdminModelClass> Admins { get; set; }

        public DbSet<UserDetails> Users { get; set; }
        public DbSet<UserRoles> Roles{ get; set; }

        public DbSet<UserRoleMappings> UserRoleMpping { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserRoleMappings>()
                .HasIndex(p => new { p.UserDetailsId, p.UserRolesId })
                .IsUnique();
            //For BuyerCartModel
            modelBuilder.Entity<BuyerCartModel>()
                .HasIndex(p => new { p.UserDetaisId, p.HouseId })
                .IsUnique();
        }

        //Buyer part
        public DbSet<BuyerCartModel> BuyerCarts { get; set; }

    }
}
