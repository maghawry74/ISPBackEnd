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

    public async Task<ReadOfferDto> Delete(DeleteOfferDto deleteOfferDto)
    {
        var offerTodeleted = await offerRepository.GetByID(deleteOfferDto.Id);
        if (offerTodeleted == null)
        {
            return null;
        }

        offerTodeleted.Status = false;

        offerRepository.Update(offerTodeleted);
        offerRepository.SaveChange();
        
       
        return mapper.Map<ReadOfferDto>(offerTodeleted);
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
        offerToEdit.Status = true;
            

        offerRepository.Update(offerToEdit);

        offerRepository.SaveChange();

        return mapper.Map<ReadOfferDto>(offerToEdit);
    }

    

}
