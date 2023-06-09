using ISP.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
namespace ISP.DAL
{
   public class ISPContext:IdentityDbContext<User>
   {
        public ISPContext(DbContextOptions<ISPContext> contextOptions):base(contextOptions)
        {
            
        }

        public DbSet<Role> Roles =>  Set<Role>();
        public DbSet<Branch> Branches =>  Set<Branch>();
        public DbSet<Governarate> Governarates =>  Set<Governarate>();
        public DbSet<Central> Centrals =>  Set<Central>();
        public DbSet<Provider> Providers => Set<Provider>();
        public DbSet<Offer> Offers =>  Set<Offer>();
        public DbSet<Package> Packages => Set<Package>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<Bill> Bills => Set<Bill>();



        protected override void OnModelCreating(ModelBuilder builder)
        {                         
            base.OnModelCreating(builder);


            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");

                  builder.Entity<Branch>()
                          .HasAlternateKey(e => e.Phone1);
                  builder.Entity<Branch>()
                          .HasAlternateKey(e => e.Phone2);
                  builder.Entity<Branch>()
                          .HasAlternateKey(e => e.Mobile1);
                  builder.Entity<Branch>()
                         .HasAlternateKey(e => e.Mobile2);

            builder.Entity<Governarate>()
                         .HasAlternateKey(e => e.Name);


           builder.Entity<Client>()
            .HasIndex(o => new { o.Mobile1, o.Mobile2 })
            .IsUnique();

          //Global Filters

            builder.Entity<Bill>().HasQueryFilter(p => p.Status == true);
            builder.Entity<Branch>().HasQueryFilter(p => p.Status == true);
            builder.Entity<Governarate>().HasQueryFilter(p => p.Status == true);
            builder.Entity<Central>().HasQueryFilter(p => p.Status == true);
            builder.Entity<Client>().HasQueryFilter(p => p.Isactive == true);
            builder.Entity<Offer>().HasQueryFilter(p => p.Status == true);
            builder.Entity<Package>().HasQueryFilter(p => p.IsActive == true);
            builder.Entity<Provider>().HasQueryFilter(p => p.IsActive == true);
            builder.Entity<Role>().HasQueryFilter(p => p.Status == true);
            builder.Entity<User>().HasQueryFilter(p => p.Status == true);


            // builder.Entity<Branch>().HasMany(p => p.Phones).WithOne().HasForeignKey(a => a.Id);
            // builder.Entity<Branch>().HasMany(p => p.Mobiles).WithOne().HasForeignKey(a => a.Id);

            builder.Entity<Client>()
           .HasIndex(c=>c.Phone)
           .IsUnique();

        }
   }
}
