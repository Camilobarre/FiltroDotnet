using FiltroDotnet.Data;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FiltroDotnet.Services
{
    public class RoomTypeServices : IRoomTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomTypeServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<RoomType>> GetAllRoomTypes()
        {
            return await _context.RoomTypes.ToListAsync();
        }

        public async Task<RoomType?> GetRoomTypeById(int id)
        {
            return await _context.RoomTypes.FindAsync(id);
        }

        public async Task<IEnumerable<RoomType>> GetRoomTypesWithRoomsAsync()
        {
            return await _context.RoomTypes
                .Include(rt => rt.Rooms) // Incluir las habitaciones relacionadas
                .ToListAsync();
        }
    }
}