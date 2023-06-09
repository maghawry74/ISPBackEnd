using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ISP.BL
{
    public interface IGovernarateService
    {
        Task<List<ReadGovernarateDTO>> GetAll();
        Task<ReadGovernarateDTO?> GetById(int Code);

        Task<ReadGovernarateDTO> AddGovernarate(WriteGovernarateDTO writeGovernarateDTO);

        Task<ReadGovernarateDTO> UpdateGovernarate(int Code, UpdateGovernarateDTO updateGovernarateDTO);

        Task<ReadGovernarateDTO> DeleteGovernarate(ReadGovernarateDTO readGovernarateDTO);
    }
}
