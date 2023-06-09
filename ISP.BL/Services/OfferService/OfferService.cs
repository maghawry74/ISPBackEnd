using AutoMapper;
using ISP.BL.Dtos.Offer;
using ISP.DAL;
using ISP.DAL.Repository.OfferRepository;

namespace ISP.BL.Services.OfferService;

public class OfferService : IOfferService
{
    private readonly IOfferRepository offerRepository;
    private readonly IMapper mapper;

    public OfferService(IOfferRepository offerRepository, IMapper mapper)
    {
        this.offerRepository = offerRepository;
        this.mapper = mapper;
    }

    public async Task<ReadOfferDto> Insert(WriteOfferDto writeOfferDto)
    {
        var offer = mapper.Map<Offer>(writeOfferDto);
        await offerRepository.Add(offer);
        offerRepository.SaveChange();
        return mapper.Map<ReadOfferDto>(offer);
    }

    public async Task<List<ReadOfferDto>> GetAll()
    {
        var offers = await offerRepository.GetAll();
        return mapper.Map<List<ReadOfferDto>>(offers);
    }

    public async Task<ReadOfferDto?> GetById(int id)
    {
        var offer = await offerRepository.GetByID(id);
        return mapper.Map<ReadOfferDto>(offer);
    }

    public async Task<ReadOfferDto> Delete(ReadOfferDto deleteOfferDto)
    {
        var offerToEdit = await offerRepository.GetByID(deleteOfferDto.Id);
        if (offerToEdit == null)
        {
            return null;
        }

        if(offerToEdit != null && offerToEdit.Status == true)
        {
            offerToEdit.Id = deleteOfferDto.Id;
            offerToEdit.Name = deleteOfferDto.Name;
            offerToEdit.NumOfOfferMonth = deleteOfferDto.NumOfOfferMonth;
            offerToEdit.NumOfOfferMonth = deleteOfferDto.NumOfFreeMonth;
            offerToEdit.RouterPrice = deleteOfferDto.RouterPrice;
            offerToEdit.IsPercentageDiscount = deleteOfferDto.IsPercentageDiscount;
            offerToEdit.CancelFine = deleteOfferDto.CancelFine;
            offerToEdit.ProviderId = deleteOfferDto.Id;
            offerToEdit.Isfreefirst = deleteOfferDto.Isfreefirst;
            offerToEdit.DiscoutAmout = deleteOfferDto.DiscoutAmout;
            offerToEdit.HasRouter = deleteOfferDto.HasRouter;
            offerToEdit.IsPossibleToRasieOrLower = deleteOfferDto.IsPossibleToRasieOrLower;
            offerToEdit.Status = false;

            offerRepository.Update(offerToEdit);
            offerRepository.SaveChange();

        }
       
        return mapper.Map<ReadOfferDto>(offerToEdit);
    }

    public async Task<ReadOfferDto> Edit(int id, UpdataOfferDto updataOfferDto)
    {
        var offerToEdit = await offerRepository.GetByID(id);
        if (offerToEdit == null)
        {
            return null;
        }

        offerToEdit.Id = updataOfferDto.Id;
        offerToEdit.Name = updataOfferDto.Name;
        offerToEdit.NumOfOfferMonth = updataOfferDto.NumOfOfferMonth;
        offerToEdit.NumOfOfferMonth = updataOfferDto.NumOfFreeMonth;
        offerToEdit.RouterPrice = updataOfferDto.RouterPrice;
        offerToEdit.IsPercentageDiscount = updataOfferDto.IsPercentageDiscount;
        offerToEdit.CancelFine = updataOfferDto.CancelFine;               
        offerToEdit.Isfreefirst = updataOfferDto.Isfreefirst;
        offerToEdit.DiscoutAmout = updataOfferDto.DiscoutAmout;
        offerToEdit.HasRouter = updataOfferDto.HasRouter;
        offerToEdit.IsPossibleToRasieOrLower = updataOfferDto.IsPossibleToRasieOrLower;
        offerToEdit.Status = updataOfferDto.Status;
            

        offerRepository.Update(offerToEdit);

        offerRepository.SaveChange();

        return mapper.Map<ReadOfferDto>(offerToEdit);
    }

    

}
