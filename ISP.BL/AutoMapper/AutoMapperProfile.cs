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
            #region Branch
            //Branch
            CreateMap<Branch , ReadBranchDTO>().ReverseMap();
            CreateMap<Branch , WriteBranchDTO>().ReverseMap();            
            CreateMap<Branch , UpdateBranchDTO>().ReverseMap();
            #endregion

            #region Goernorate
            //Governarate
            CreateMap<Governorate , ReadGovernarateDTO>().ReverseMap();
            CreateMap<Governorate , WriteGovernarateDTO>().ReverseMap();
            CreateMap<Governorate , UpdateGovernarateDTO>().ReverseMap();
            #endregion

            #region Central
            //Central
            CreateMap<Central , ReadCentralDTO>().ReverseMap();
            CreateMap<Central , WriteCentralDTO>().ReverseMap();
            CreateMap<Central , UpdateCentralDTO>().ReverseMap();
            CreateMap<Central , ReadCentralWithGovernarateDTO>().ReverseMap();



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

            #region Client
            //client
            CreateMap<Client, ReadClientDTO>()
                .ForMember(c => c.SSID, cmt => cmt.MapFrom(src => src.SSn))
                .ForMember(c => c.Name, cmt => cmt.MapFrom(src => src.Name))
                .ForMember(c => c.Tel, cmt => cmt.MapFrom(src => src.Phone))
                .ForMember(c => c.GovernorateName, cmt => cmt.MapFrom(src => src.Governarate.Name))
                .ForMember(c => c.Address, cmt => cmt.MapFrom(src => src.Address))
                .ForMember(c => c.Email, cmt => cmt.MapFrom(src => src.Email))
                .ForMember(c => c.ProviderName, cmt => cmt.MapFrom(src => src.Provider.Name))
                .ForMember(c => c.PackageName, cmt => cmt.MapFrom(src => src.Package.Name))
                .ForMember(c => c.CentralName, cmt => cmt.MapFrom(src => src.Central.Name))
                .ForMember(c => c.BranchName, cmt => cmt.MapFrom(src => src.Branch.Name))
                .ForMember(c => c.Phone, cmt => cmt.MapFrom(src => src.Mobile1))
                .ForMember(c => c.UserName, cmt => cmt.MapFrom(src => src.userName))
                .ForMember(c => c.Password, cmt => cmt.MapFrom(src => src.Password))
                .ReverseMap();

            #endregion

            #region Package

            CreateMap<Client, UpdateClientDTO>()
              .ForMember(c => c.SSID, cmt => cmt.MapFrom(src => src.SSn))
              .ForMember(c => c.PackageId, cmt => cmt.MapFrom(src => src.PackageId))
              .ReverseMap();

            CreateMap<Client, WriteClientDTO>()
            .ForMember(c => c.ssid, cmt => cmt.MapFrom(src => src.SSn))
            .ForMember(c => c.name, cmt => cmt.MapFrom(src => src.Name))
            .ForMember(c => c.tel, cmt => cmt.MapFrom(src => src.Phone))
            .ForMember(c => c.governorateCode, cmt => cmt.MapFrom(src => src.GovernarateCode))
            .ForMember(c => c.address, cmt => cmt.MapFrom(src => src.Address))
            .ForMember(c => c.email, cmt => cmt.MapFrom(src => src.Email))
            .ForMember(c => c.providerId, cmt => cmt.MapFrom(src => src.ProviderId))
            .ForMember(c => c.packageId, cmt => cmt.MapFrom(src => src.PackageId))
            .ForMember(c => c.branchId, cmt => cmt.MapFrom(src => src.BranchId))
            //.ForMember(c => c.offerId, cmt => cmt.MapFrom(src => src.offerId))
            .ForMember(c => c.centralId, cmt => cmt.MapFrom(src => src.CentralId))
            .ForMember(c => c.packageIp, cmt => cmt.MapFrom(src => src.IpPackage))
            .ForMember(c => c.routerSerial, cmt => cmt.MapFrom(src => src.RouterSerial))
            .ForMember(c => c.phone, cmt => cmt.MapFrom(src => src.Mobile1))
            .ForMember(c => c.orderNumber, cmt => cmt.MapFrom(src => src.OrderNumber))
            .ForMember(c => c.portSlot, cmt => cmt.MapFrom(src => src.PortSlot))
            .ForMember(c => c.slot, cmt => cmt.MapFrom(src => src.Slotnum))
            .ForMember(c => c.block, cmt => cmt.MapFrom(src => src.Blocknum))
            .ForMember(c => c.portBlock, cmt => cmt.MapFrom(src => src.PortBlock))
            .ForMember(c => c.userName, cmt => cmt.MapFrom(src => src.userName))
            .ForMember(c => c.password, cmt => cmt.MapFrom(src => src.Password))
            .ForMember(c => c.vci, cmt => cmt.MapFrom(src => src.VCI))
            .ForMember(c => c.vpi, cmt => cmt.MapFrom(src => src.VPI))
            .ForMember(c => c.operationOrderNumber, cmt => cmt.MapFrom(src => src.OrderWorkNumber))
            .ForMember(c => c.operationOrderDate, cmt => cmt.MapFrom(src => src.Orderworkdate))
            .ForMember(c => c.prePaid, cmt => cmt.MapFrom(src => src.PrePaid))
            .ForMember(c => c.installationFee, cmt => cmt.MapFrom(src => src.installationFee))
            .ForMember(c => c.contractFee, cmt => cmt.MapFrom(src => src.ContractFee))
            .ReverseMap();

          


            //Package
            CreateMap<Package, ReadPackageDTO>().ReverseMap();
            CreateMap<Package, WritePackageDTO>().ReverseMap();
            CreateMap<Package, UpdatePackageDTO>().ReverseMap();

            #endregion




        
            #region Role  


            //Role
            CreateMap<Role, ReadRoleDto>().ReverseMap();
            CreateMap<Role, WriteRoleDto>().ReverseMap();           
            #endregion

            #region Bill
            // bill
            CreateMap<Bill , ReadBillDTO>().ReverseMap();
            #endregion


        }

    }
}
