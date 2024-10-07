
using FiltroDotnet.Models;

namespace FiltroDotnet.Repositories
{
    public interface IUserRepository
    {
        Task AddUser(User user);
    }
}