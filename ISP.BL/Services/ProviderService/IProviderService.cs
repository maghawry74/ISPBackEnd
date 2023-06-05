using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public interface IProviderService
    {
        Task<List<ReadProviderDTO>> GetAll();
        Task<ReadProviderDTO?> GetById(int id);

        Task<ReadProviderDTO> Insert(WriteProviderDTO writeProviderDTO);

        Task<ReadProviderDTO> Edit(int id, UpdateProviderDTO updateProviderDTO);

        Task<ReadProviderDTO> Remove(DeleteProviderDTO deleteProviderDTO);
    }
}
