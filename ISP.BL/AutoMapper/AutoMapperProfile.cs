using AutoMapper;
using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            CreateMap<Central ,ReadCentralWithGovernarateDTO>().ReverseMap();

            CreateMap<Provider , ReadProviderDTO>().ReverseMap();
            CreateMap<Provider , WriteProviderDTO>().ReverseMap();
            CreateMap<Provider , UpdateProviderDTO>().ReverseMap();
            CreateMap<Provider , DeleteProviderDTO>().ReverseMap();
         



        }

    }
}
