﻿using AutoMapper;
using ISP.BL.Dtos.Offer;
using ISP.BL.Dtos.Role;
using ISP.DAL;

namespace ISP.BL
{
   public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            #region Branch
            //Branch
            CreateMap<Branch , ReadBranchDTO>().ReverseMap();
            CreateMap<Branch , WriteBranchDTO>().ReverseMap();            
            CreateMap<Branch , UpdateBranchDTO>().ReverseMap();
            #endregion

            #region Goernorate
            //Governarate
            CreateMap<Governarate , ReadGovernarateDTO>().ReverseMap();
            CreateMap<Governarate , WriteGovernarateDTO>().ReverseMap();
            CreateMap<Governarate , UpdateGovernarateDTO>().ReverseMap();
            #endregion

            #region Central
            //Central
            CreateMap<Central , ReadCentralDTO>().ReverseMap();
            CreateMap<Central , WriteCentralDTO>().ReverseMap();
            CreateMap<Central , UpdateCentralDTO>().ReverseMap();
            CreateMap<Central ,ReadCentralWithGovernarateDTO>().ReverseMap();
            #endregion


            #region Provider
            //Provider
            CreateMap<Provider , ReadProviderDTO>().ReverseMap();
            CreateMap<Provider , WriteProviderDTO>().ReverseMap();

            #endregion

            #region Offer
            //Offer
            CreateMap<Offer, UpdataOfferDto>()
                .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
                .ForMember(o => o.FreeRouter, opt => opt.MapFrom(src => src.HasRouter))
                .ForMember(o => o.RouterPrice, opt => opt.MapFrom(src => src.RouterPrice))
                .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
                .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
                .ForMember(o => o.ProviderId, opt => opt.MapFrom(src => src.ProviderId))
                .ForMember(o => o.NumberOfMonths, opt => opt.MapFrom(src => src.NumOfOfferMonth))
                .ForMember(o => o.Discount, opt => opt.MapFrom(src => src.DiscoutAmout))
                .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
                .ForMember(o => o.FreeMonthsFirst, opt => opt.MapFrom(src => src.Isfreefirst))
                .ForMember(o => o.NumberOfFreeMonths, opt => opt.MapFrom(src => src.NumOfFreeMonth))
                .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
                .ForMember(o => o.SuspendFee, opt => opt.MapFrom(src => src.FineOfSuspensed))
                .ReverseMap();

            CreateMap<Offer, WriteOfferDto>()
               .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
               .ForMember(o => o.FreeRouter, opt => opt.MapFrom(src => src.HasRouter))
               .ForMember(o => o.RouterPrice, opt => opt.MapFrom(src => src.RouterPrice))
               .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
               .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
               .ForMember(o => o.ProviderId, opt => opt.MapFrom(src => src.ProviderId))
               .ForMember(o => o.NumberOfMonths, opt => opt.MapFrom(src => src.NumOfOfferMonth))
               .ForMember(o => o.Discount, opt => opt.MapFrom(src => src.DiscoutAmout))
               .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
               .ForMember(o => o.FreeMonthsFirst, opt => opt.MapFrom(src => src.Isfreefirst))
               .ForMember(o => o.NumberOfFreeMonths, opt => opt.MapFrom(src => src.NumOfFreeMonth))
               .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
               .ForMember(o => o.SuspendFee, opt => opt.MapFrom(src => src.FineOfSuspensed))
               .ReverseMap();

            CreateMap<Offer, ReadOfferDto>()
               .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
               .ForMember(o => o.FreeRouter, opt => opt.MapFrom(src => src.HasRouter))
               .ForMember(o => o.RouterPrice, opt => opt.MapFrom(src => src.RouterPrice))
               .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
               .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
               .ForMember(o => o.Provider, opt => opt.MapFrom(src => src.Provider.Id))
               .ForMember(o => o.NumberOfMonths, opt => opt.MapFrom(src => src.NumOfOfferMonth))
               .ForMember(o => o.Discount, opt => opt.MapFrom(src => src.DiscoutAmout))
               .ForMember(o => o.IsPercent, opt => opt.MapFrom(src => src.IsPercentageDiscount))
               .ForMember(o => o.FreeMonthsFirst, opt => opt.MapFrom(src => src.Isfreefirst))
               .ForMember(o => o.NumberOfFreeMonths, opt => opt.MapFrom(src => src.NumOfFreeMonth))
               .ForMember(o => o.CancelFee, opt => opt.MapFrom(src => src.CancelFine))
               .ForMember(o => o.SuspendFee, opt => opt.MapFrom(src => src.FineOfSuspensed))
               .ReverseMap();

            #endregion


            #region Package
            //Package
            CreateMap<Package, ReadPackageDTO>().ReverseMap();
            CreateMap<Package, WritePackageDTO>().ReverseMap();
            CreateMap<Package, UpdatePackageDTO>().ReverseMap();

            #endregion



            //Offer
            //CreateMap<Offer, ReadOfferDto>()
            //    .ForSourceMember(x => x.Clients, opt => opt.DoNotValidate())
            //    .ReverseMap();
            //CreateMap<Offer, WriteOfferDto>()
            //    .ForSourceMember(x => x.Clients, opt => opt.DoNotValidate())
            //    .ReverseMap();

            #region Role
            //Role
            CreateMap<Role, ReadRoleDto>().ReverseMap();
            CreateMap<Role, WriteRoleDto>().ReverseMap();           
            #endregion

            #region Client
            //client
            CreateMap<Client , ReadClientDTO>().ReverseMap();
            CreateMap<Client , WriteClientDTO>().ReverseMap();
            CreateMap<Client , UpdateClientDTO>().ReverseMap();
            #endregion

        }

    }
}
