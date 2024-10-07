using FiltroDotnet.Data;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FiltroDotnet.Services
{
    public class RoomServices : IRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public RoomServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Room>> GetAllRooms()
        {
            return await _context.Rooms.ToListAsync();
        }

        public async Task<Room?> GetRoomById(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public async Task<IEnumerable<Room>> GetAvailableRooms()
        {
            return await _context.Rooms.Where(r => r.Availability).ToListAsync();
        }

        public async Task<IEnumerable<Room>> GetOccupiedRooms()
        {
            return await _context.Rooms.Where(r => !r.Availability).ToListAsync();
        }

        public async Task AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRoom(int id)
        {
            var room = await GetRoomById(id);
            if (room != null)
            {
                _context.Rooms.Remove(room);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<(int AvailableCount, int OccupiedCount)> GetRoomStatusAsync()
        {
            var availableCount = await _context.Rooms.CountAsync(r => r.Availability);
            var occupiedCount = await _context.Rooms.CountAsync(r => !r.Availability);

            return (availableCount, occupiedCount);
        }
    }
}