using AutoMapper;
using ISP.DAL;
namespace ISP.BL
{
    public class GovernarateService : IGovernarateService
    {
        private readonly IGovernarateRepository governarateRepository;
        private readonly IMapper mapper;

        public GovernarateService(IGovernarateRepository governarateRepository , IMapper mapper)
        {
            this.governarateRepository = governarateRepository;
            this.mapper = mapper;
        }

        public  async Task<List<ReadGovernarateDTO>> GetAll()
        {
            var GovernarateListFromDB = await governarateRepository.GetAll();
            return mapper.Map<List<ReadGovernarateDTO>>(GovernarateListFromDB);
        }

        public async Task<ReadGovernarateDTO?> GetById(int Code)
        {
            var GovernarateFromDB = await governarateRepository.GetByID(Code);
            return mapper.Map<ReadGovernarateDTO>(GovernarateFromDB);
        }

        public async Task<ReadGovernarateDTO> AddGovernarate(WriteGovernarateDTO writeGovernarateDTO)
        {
            var GovernarateToAdd = mapper.Map<Governarate>(writeGovernarateDTO);
            await governarateRepository.Add(GovernarateToAdd);
            governarateRepository.SaveChange();
            return mapper.Map<ReadGovernarateDTO>(GovernarateToAdd);
        }

        public async Task<ReadGovernarateDTO> UpdateGovernarate(int Code, UpdateGovernarateDTO updateGovernarateDTO)
        {
            var GovernarateToEdit = await governarateRepository.GetByID(Code);
            if (GovernarateToEdit == null)
            {
                return null;
            }


            var updatedGovernarate = new Governarate
            {
                Code = updateGovernarateDTO.Code,
                Name = updateGovernarateDTO.Name,
                Status = true
            };

            // Save changes
            try
            {
                governarateRepository.Delete(GovernarateToEdit);
               await governarateRepository.Add(updatedGovernarate);
                governarateRepository.SaveChange();
            }
            catch (Exception ex)
            {
                // Handle exceptions
                throw new Exception("Failed to update governarate.", ex);
            }

            // Return the updated entity
            return mapper.Map<ReadGovernarateDTO>(updatedGovernarate);
        }
        public async Task<ReadGovernarateDTO> DeleteGovernarate(DeleteGovernarateDTO deleteGovernarateDTO)
        {
           
            var GovernarateFromDB = await governarateRepository.GetByID(deleteGovernarateDTO.Code);
            if (GovernarateFromDB == null)
            {
                return null;
            }
            
                GovernarateFromDB.Status = false;
                governarateRepository.Update(GovernarateFromDB);
                governarateRepository.SaveChange();             
           
            return mapper.Map<ReadGovernarateDTO>(GovernarateFromDB);
        }

     
    }
}
