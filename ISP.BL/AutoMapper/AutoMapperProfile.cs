using AutoMapper;
using ISP.BL.Dtos.Offer;
using ISP.BL.Dtos.Role;
using ISP.DAL;

namespace ISP.BL
{
   public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            //Branch
            CreateMap<Branch , ReadBranchDTO>().ReverseMap();
            CreateMap<Branch , WriteBranchDTO>().ReverseMap();            
            CreateMap<Branch , UpdateBranchDTO>().ReverseMap();
            CreateMap<ReadBranchDTO, UpdateProviderDTO>().ReverseMap();

            //Governarate
            CreateMap<Governarate , ReadGovernarateDTO>().ReverseMap();
            CreateMap<Governarate , WriteGovernarateDTO>().ReverseMap();
            CreateMap<Governarate , UpdateGovernarateDTO>().ReverseMap();
   

            //Central
            CreateMap<Central , ReadCentralDTO>().ReverseMap();
            CreateMap<Central , WriteCentralDTO>().ReverseMap();
            CreateMap<Central , UpdateCentralDTO>().ReverseMap();
            CreateMap<Central ,ReadCentralWithGovernarateDTO>().ReverseMap();

 

            //Provider
            CreateMap<Provider , ReadProviderDTO>().ReverseMap();
            CreateMap<Provider , WriteProviderDTO>().ReverseMap();
            CreateMap<Provider , UpdateProviderDTO>().ReverseMap();
          
            CreateMap<ReadProviderDTO, UpdateProviderDTO>().ReverseMap();


            //Package
            CreateMap<Package, ReadPackageDTO>().ReverseMap();
            CreateMap<Package, WritePackageDTO>().ReverseMap();
            CreateMap<Package, UpdatePackageDTO>().ReverseMap();


           
            

            //Offer
            CreateMap<Offer, ReadOfferDto>()
                .ForSourceMember(x => x.Clients, opt => opt.DoNotValidate())
                .ReverseMap();
            CreateMap<Offer, WriteOfferDto>()
                .ForSourceMember(x => x.Clients, opt => opt.DoNotValidate())
                .ReverseMap();
            CreateMap<Offer, UpdataOfferDto>().ReverseMap();
            

            //Role
            CreateMap<Role, ReadRoleDto>().ReverseMap();
            CreateMap<Role, WriteRoleDto>().ReverseMap();
            CreateMap<Role, UpdateRoleDto>().ReverseMap();


            //client
            CreateMap<Client , ReadClientDTO>().ReverseMap();
            CreateMap<Client , WriteClientDTO>().ReverseMap();
            CreateMap<Client , UpdateClientDTO>().ReverseMap();

        }

    }
}
