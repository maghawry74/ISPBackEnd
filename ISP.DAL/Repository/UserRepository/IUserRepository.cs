
namespace ISP.DAL.Repository.UserRepository
{
    public interface IUserRepository :IGenericRepository<User>
    {
    Task<List<User>> GetAllUsers();
    }
}
