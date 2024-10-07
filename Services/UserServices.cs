using FiltroDotnet.Data;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;

namespace FiltroDotnet.Services
{
    public class UserServices : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }
    }
}
