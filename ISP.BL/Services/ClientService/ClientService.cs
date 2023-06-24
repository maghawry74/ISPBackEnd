using AutoMapper;

using ISP.DAL;
using System.Runtime.Intrinsics.X86;

namespace ISP.BL
{
    public class ClientService : IClientservice
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientService(IClientRepository clientRepository , IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public  async Task<List<ReadClientDTO>> GetAll()
        {
               var clientFrondb =  await clientRepository.GetAll(); 
            return   mapper.Map<List<ReadClientDTO>>(clientFrondb); 

        }

        public async Task<ReadClientDTO?> GetById(string SSn)
        {
            var clientFromDB = await clientRepository.GetByID(SSn);
            return mapper.Map<ReadClientDTO>(clientFromDB);
        }

        public async Task<ReadClientDTO> AddClient(WriteClientDTO writeClientDTO)
        {
            var clientToAdd = mapper.Map<Client>(writeClientDTO);
            await clientRepository.Add(clientToAdd);
            clientRepository.SaveChange();
            return mapper.Map<ReadClientDTO>(clientToAdd);
        }

        public async Task<ReadClientDTO> UpdateClient(string SSn, UpdateClientDTO updateClientDTO)
        {
            var ClientToEdit = await clientRepository.GetByID(SSn);
            if (ClientToEdit == null)
            {
                return null;
            }

            ClientToEdit.PackageId = updateClientDTO.PackageId;
            ClientToEdit.Isactive = true;
        
            clientRepository.Update(ClientToEdit);

            clientRepository.SaveChange();

            return mapper.Map<ReadClientDTO>(ClientToEdit);
        }

        public async Task<ReadClientDTO> DeleteClient(string SSn)
        {
            var ClientTodeleted = await clientRepository.GetByID(SSn);
            if (ClientTodeleted == null)
            {
                return null;
            }

            ClientTodeleted.Isactive = false;

            clientRepository.Update(ClientTodeleted);

            clientRepository.SaveChange();

            return mapper.Map<ReadClientDTO>(ClientTodeleted);
        }
    }
}
