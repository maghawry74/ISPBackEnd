using AutoMapper;
using ISP.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository branchRepository;
        private readonly IMapper mapper;

        public BranchService(IBranchRepository branchRepository, IMapper mapper)
        {
            this.branchRepository = branchRepository;
            this.mapper = mapper;
        }

        public async Task<List<ReadBranchDTO>> GetAll()
        {
            var BranchListFromDB = await branchRepository.GetAll();
            return mapper.Map<List<ReadBranchDTO>>(BranchListFromDB);
        }

        public async Task<ReadBranchDTO?> GetById(int id)
        {
            var BranchFromDB = await branchRepository.GetByID(id);
            return mapper.Map<ReadBranchDTO>(BranchFromDB);
        }
        public async Task<ReadBranchDTO> AddBranch(WriteBranchDTO writeBranchDTO)
        {
            var BranchToAdd = mapper.Map<Branch>(writeBranchDTO);
            await branchRepository.Add(BranchToAdd);
            branchRepository.SaveChange();
            return mapper.Map<ReadBranchDTO>(BranchToAdd);
        }

        public async Task<ReadBranchDTO> DeleteBranch(ReadBranchDTO readBranchDTO)
        {
            var updateBranchDTO = mapper.Map<UpdateBranchDTO>(readBranchDTO);
            var BranchFromDB = await branchRepository.GetByID(updateBranchDTO.Id);
            if (BranchFromDB == null)
            {
                return null;
            }
            if(BranchFromDB != null && BranchFromDB.Status == true)
            {
                BranchFromDB.Name = updateBranchDTO.Name;
                BranchFromDB.Address = updateBranchDTO.address;
                BranchFromDB.Phone1 = updateBranchDTO.phone1;
                BranchFromDB.Phone2 = updateBranchDTO.phone2;
                BranchFromDB.Mobile1 = updateBranchDTO.mobile1;
                BranchFromDB.Mobile2 = updateBranchDTO.mobile2;
                BranchFromDB.ManagerId = updateBranchDTO.ManagerId;
                BranchFromDB.Fax = updateBranchDTO.Fax;
                BranchFromDB.Status = false;

                branchRepository.Update(BranchFromDB);
                branchRepository.SaveChange();
            }
            
            return mapper.Map<ReadBranchDTO>(BranchFromDB);


        }

        public async Task<ReadBranchDTO> UpdateBranch(int id, UpdateBranchDTO updateBranchDTO)
        {
            var BranchToEdit = await branchRepository.GetByID(id);
            if (BranchToEdit == null)
            {
                return null;
            }

            BranchToEdit.Name = updateBranchDTO.Name;
            BranchToEdit.Address = updateBranchDTO.address;
            BranchToEdit.Phone1 = updateBranchDTO.phone1;
            BranchToEdit.Phone2= updateBranchDTO.phone2;
            BranchToEdit.Mobile1= updateBranchDTO.mobile1;
            BranchToEdit.Mobile2= updateBranchDTO.mobile2;
            BranchToEdit.ManagerId= updateBranchDTO.ManagerId;
            BranchToEdit.Fax= updateBranchDTO.Fax;
            BranchToEdit.Status = true;

            branchRepository.Update(BranchToEdit);

            branchRepository.SaveChange();

            return mapper.Map<ReadBranchDTO>(BranchToEdit);
        }


    }
}
