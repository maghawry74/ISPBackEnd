using ISP.DAL.Repository.BranchRepository;
using ISP.DAL.Repository.CentralRepository;
using ISP.DAL.Repository.OfferRepository;
using ISP.DAL.Repository.RoleRepository;
using ISP.DAL;

namespace ISP.API.RedisterDependancies
{
    public static class RepositoryDependencyInjectionExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IBranchRepository, BranchRepository>();
            services.AddScoped<IGovernarateRepository, GovernarateRepository>();
            services.AddScoped<ICentralRepository, CentralRepository>();
            services.AddScoped<IProviderRepository, ProviderRepository>();
            services.AddScoped<IPackageReposatory, PackageReposatory>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IOfferRepository, OfferRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
        }
    }
}
