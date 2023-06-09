using ISP.DAL.Repository.BranchRepository;
using ISP.DAL.Repository.CentralRepository;
using ISP.DAL.Repository.OfferRepository;
using ISP.DAL.Repository.RoleRepository;
using ISP.DAL;
using ISP.BL.Services.OfferService;
using ISP.BL.Services.RoleService;
using ISP.BL;

namespace ISP.API.RedisterDependancies
{
    public static class ServiceDependencyInjectionExtensions
    {


        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IBranchService, BranchService>();
            services.AddScoped<IGovernarateService, GovernarateService>();
            services.AddScoped<ICentalService, CentalService>();
           services.AddScoped<IProviderService, ProviderService>();

            services.AddScoped<IPackageService, PackageService>();

           services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IOfferService, OfferService>();
            services.AddScoped<IClientservice, ClientService>();
        }

    }
}
