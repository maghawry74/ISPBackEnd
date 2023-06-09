using ISP.BL.Dtos.Client;
namespace ISP.BL
{
    public interface IClientservice
    {
        Task<List<ReadClientDTO>> GetAll();
        Task<ReadClientDTO?> GetById(int SSn);

        Task<ReadClientDTO> AddClient(WriteClientDTO writeClientDTO);

        Task<ReadClientDTO> UpdateClient(int SSn, UpdateClientDTO updateClientDTO);

        Task<ReadClientDTO> DeleteClient( DeleteClientDto deleteClientDto);


    }
}
