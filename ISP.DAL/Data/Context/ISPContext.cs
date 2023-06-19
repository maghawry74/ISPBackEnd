using ISP.DAL.Data.Models;
using ISP.DAL.Data.Models.ModelsCongiguration;
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

       
        public DbSet<Branch> Branches =>  Set<Branch>();
        public DbSet<Governorate> Governorates =>  Set<Governorate>();
        public DbSet<Central> Centrals =>  Set<Central>();
        public DbSet<Provider> Providers => Set<Provider>();
        public DbSet<Offer> Offers =>  Set<Offer>();
        public DbSet<Package> Packages => Set<Package>();
        public DbSet<Client> Clients => Set<Client>();
        public DbSet<ClientOffers> ClientOffers => Set<ClientOffers>();

        public DbSet<Bill> Bills => Set<Bill>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Role> Roles => Set<Role>();
        public DbSet<Role> RoleClaims => Set<Role>();



        protected override void OnModelCreating(ModelBuilder builder)
        {                         
            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("User");
            builder.Entity<IdentityRole>().ToTable("Role");            
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims");

            //can find all your configuration classes that inherit IEntityTypeConfiguration<T> and run them all for you
            // builder.ApplyConfigurationsFromAssembly(
            //Assembly.GetExecutingAssembly());

            builder.ApplyConfiguration(new BranchConfig());
            builder.ApplyConfiguration(new ClientConfig());
            builder.ApplyConfiguration(new GovernorateConfig());

             

            //Shdow Propreties
            //builder.Entity<User>().Property<bool>("Status");
           
            //builder.Entity<Provider>()
            //    .HasQueryFilter(p => p.IsActive == true)
            //    .Property<bool>("IsActive");                


            //Global Filters
            
            builder.Entity<Branch>().HasQueryFilter(p => p.Status );
            builder.Entity<Governorate>().HasQueryFilter(p => p.Status);
            builder.Entity<Central>().HasQueryFilter(p => p.Status);
            builder.Entity<Client>().HasQueryFilter(p => p.Isactive);
            builder.Entity<Offer>().HasQueryFilter(p => p.Status);
            builder.Entity<Package>().HasQueryFilter(p => p.IsActive );
            builder.Entity<Provider>().HasQueryFilter(p => p.IsActive );
            //builder.Entity<User>().HasQueryFilter(p => p.Status);          

           
        }
   }
}
