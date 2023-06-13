using AutoMapper;
using ISP.BL.Dtos.Role;
using ISP.DAL;
using ISP.DAL.Repository.RoleRepository;

namespace ISP.BL.Services.RoleService
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository roleRepository;
        private readonly IMapper mapper;
        public RoleService(IRoleRepository roleRepository, IMapper mapper)
        {
            this.roleRepository = roleRepository;
            this.mapper = mapper;
        }

        public async Task<List<ReadRoleDto>> GetAll()
        {
            var rolesList = await roleRepository.GetAll();
            return mapper.Map<List<ReadRoleDto>>(rolesList);
        }
       
        public async Task<ReadRoleDto?> GetById(int id)
        {
            var roleDB = await roleRepository.GetByID(id);
            return  mapper.Map<ReadRoleDto>(roleDB);
        }

        public string GetRoleNameByID(string id)
        {
            var role = roleRepository.GetRoleNameByID(id);
            return role;
        }

        public async Task<ReadRoleDto> Insert(WriteRoleDto writeRoleDto)
        {
            var roleToAdd = mapper.Map<Role>(writeRoleDto);
            await roleRepository.Add(roleToAdd);
            roleRepository.SaveChange();
            return  mapper.Map<ReadRoleDto>(roleToAdd);
        }

        public async Task<ReadRoleDto> Update(int Id, UpdateRoleDto updateRoleDto)
        {
            var roleToEdit = await roleRepository.GetByID(Id);
            if (roleToEdit == null)
            {
                return null;
            }

            
            roleToEdit.Status = true;
            roleRepository.SaveChange();

            return mapper.Map<ReadRoleDto>(roleToEdit);
        }
        public async Task<ReadRoleDto> Delete(int id)
        {
            var getRole = await roleRepository.GetByID(id);
            if (getRole == null)
            {
                return null;
            }
            getRole.Status = false;
            roleRepository.Update(getRole);            
            roleRepository.SaveChange();

            return mapper.Map<ReadRoleDto>(getRole);

        }

        
    }
}
