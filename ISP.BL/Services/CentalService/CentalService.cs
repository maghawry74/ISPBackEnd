using AutoMapper;
using ISP.DAL;
using ISP.DAL.Repository.BranchRepository;
using ISP.DAL.Repository.CentralRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class CentalService : ICentalService
    {
        private readonly ICentralRepository centralRepository;
        private readonly IMapper mapper;

        public CentalService(ICentralRepository centralRepository , IMapper mapper)
        {
            this.centralRepository = centralRepository;
            this.mapper = mapper;
        }

        public async Task<List<ReadCentralDTO>> GetAll()
        {
            var CentralListFromDB = await centralRepository.GetAll();
            return mapper.Map<List<ReadCentralDTO>>(CentralListFromDB);
        }

        public async Task<ReadCentralDTO?> GetById(int id)
        {
            var CentalFromDB = await centralRepository.GetByID(id);
            return mapper.Map<ReadCentralDTO>(CentalFromDB);
        }

        public async Task<ReadCentralDTO?> GetByName(string Name)
        {
            var CentalFromDB = await centralRepository.GetBYNameAsync(Name);
            return mapper.Map<ReadCentralDTO>(CentalFromDB);
        }

        public async Task<ReadCentralDTO> Insert(WriteCentralDTO writeCentralDTO)
        {
            var CentalToAdd = mapper.Map<Central>(writeCentralDTO);
            await centralRepository.Add(CentalToAdd);
            centralRepository.SaveChange();
            return mapper.Map<ReadCentralDTO>(CentalToAdd);
        }

        public async Task<ReadCentralDTO> Edit(int id, UpdateCentralDTO updateCentralDTO)
        {

            var CentalToEdit = await centralRepository.GetByID(id);
            if (CentalToEdit == null)
            {
                return null;
            }

            CentalToEdit.Name = updateCentralDTO.Name;
            CentalToEdit.GovernarateCode = updateCentralDTO.GovernarateCode;
            CentalToEdit.Status = true;         



            centralRepository.Update(CentalToEdit);

            centralRepository.SaveChange();

            return mapper.Map<ReadCentralDTO>(CentalToEdit);

        }    

        public async Task<ReadCentralDTO> Delete(ReadCentralDTO readCentralDTO)
        {
            var centalToEdit = mapper.Map<UpdateCentralDTO>(readCentralDTO);            
            var centalFromDB = await centralRepository.GetByID(centalToEdit.Id);
            if (centalFromDB == null)
            {
                return null;
            }
            if(centalFromDB != null && centalFromDB.Status == true)
            {
                centalFromDB.Name = centalToEdit.Name;
                centalFromDB.GovernarateCode = centalToEdit.GovernarateCode;
                centalFromDB.Status = false;

                centralRepository.Update(centalFromDB);
                centralRepository.SaveChange();
            }
            
            return mapper.Map<ReadCentralDTO>(centalFromDB);

        }

        public async Task<List<ReadCentralWithGovernarateDTO>> GetAllWithGov()
        {
              var cenfromdb =   await centralRepository.getAllCentralwithGovernarate();

            return mapper.Map<List<ReadCentralWithGovernarateDTO>>(cenfromdb);
                
        }
    }
}
