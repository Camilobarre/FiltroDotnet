using FiltroDotnet.Models;

namespace FiltroDotnet.Repositories
{
    public interface IRoomTypeRepository
    {
        Task<IEnumerable<RoomType>> GetAllRoomTypes();
        Task<RoomType?> GetRoomTypeById(int id);
    }
}
