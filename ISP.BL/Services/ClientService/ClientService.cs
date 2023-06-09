using AutoMapper;
using ISP.DAL;
using ISP.DAL.Repository.CentralRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<ReadClientDTO?> GetById(int SSn)
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

        public async Task<ReadClientDTO> UpdateClient(int SSn, UpdateClientDTO updateClientDTO)
        {
            var ClientToEdit = await clientRepository.GetByID(SSn);
            if (ClientToEdit == null)
            {
                return null;
            }

            ClientToEdit.ProviderId = updateClientDTO.PackageId;

        
            clientRepository.Update(ClientToEdit);

            clientRepository.SaveChange();

            return mapper.Map<ReadClientDTO>(ClientToEdit);
        }


    }
}
