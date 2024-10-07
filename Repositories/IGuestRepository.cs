using FiltroDotnet.Models;

namespace FiltroDotnet.Repositories
{
    public interface IGuestRepository
    {
        Task<IEnumerable<Guest>> GetAllGuests();
        Task<Guest?> GetGuestById(int id);
        Task AddGuest(Guest guest);
        Task UpdateGuest(Guest guest);
        Task DeleteGuest(int id);
        Task<IEnumerable<Guest>> SearchGuests(string keyword);
    }
}