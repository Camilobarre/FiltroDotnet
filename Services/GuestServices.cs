using FiltroDotnet.Data;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FiltroDotnet.Services
{
    public class GuestServices : IGuestRepository
    {
        private readonly ApplicationDbContext _context;

        public GuestServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Guest>> GetAllGuests()
        {
            return await _context.Guests.ToListAsync();
        }

        public async Task<Guest?> GetGuestById(int id)
        {
            return await _context.Guests.FindAsync(id);
        }

        public async Task AddGuest(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateGuest(Guest guest)
        {
            _context.Guests.Update(guest);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGuest(int id)
        {
            var guest = await GetGuestById(id);
            if (guest != null)
            {
                _context.Guests.Remove(guest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Guest>> SearchGuests(string keyword)
        {
            return await _context.Guests
                .Where(g => g.FirstName.Contains(keyword) || g.IdentificationNumber.Contains(keyword))
                .ToListAsync();
        }
    }
}