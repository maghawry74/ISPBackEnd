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
            CreateMap<Branch , ReadBranchDTO>().ReverseMap();
            CreateMap<Branch , WriteBranchDTO>().ReverseMap();
            CreateMap<Branch , DeleteBranchDTO>().ReverseMap();
            CreateMap<Branch , UpdateBranchDTO>().ReverseMap();

            CreateMap<Governarate , ReadGovernarateDTO>().ReverseMap();
            CreateMap<Governarate , WriteGovernarateDTO>().ReverseMap();
            CreateMap<Governarate , UpdateGovernarateDTO>().ReverseMap();
            CreateMap<Governarate , DeleteGovernarateDTO>().ReverseMap();


            CreateMap<Central , ReadCentralDTO>().ReverseMap();
            CreateMap<Central , WriteCentralDTO>().ReverseMap();
            CreateMap<Central , UpdateCentralDTO>().ReverseMap();
            CreateMap<Central , DeleteCentralDTO>().ReverseMap();

            CreateMap<Provider , ReadProviderDTO>().ReverseMap();
            CreateMap<Provider , WriteProviderDTO>().ReverseMap();
            CreateMap<Provider , UpdateProviderDTO>().ReverseMap();
            CreateMap<Provider , DeleteProviderDTO>().ReverseMap();

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


        }

    }
}
