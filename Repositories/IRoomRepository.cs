using FiltroDotnet.Models;

namespace FiltroDotnet.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> GetAllRooms();
        Task<Room?> GetRoomById(int id);
        Task<IEnumerable<Room>> GetAvailableRooms();
        Task<IEnumerable<Room>> GetOccupiedRooms();
        Task AddRoom(Room room);
        Task UpdateRoom(Room room);
        Task DeleteRoom(int id);
    }
}