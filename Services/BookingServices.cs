using FiltroDotnet.Data;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FiltroDotnet.Services
{
public class BookingServices : IBookingRepository
    {
        private readonly ApplicationDbContext _context;

        public BookingServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _context.Bookings.ToListAsync();
        }

        public async Task<Booking?> GetBookingById(int id)
        {
            return await _context.Bookings.FindAsync(id);
        }

        public async Task<IEnumerable<Booking>> SearchBookingsByGuestIdentification(string identificationNumber)
        {
            return await _context.Bookings
                .Where(b => b.Guest.IdentificationNumber == identificationNumber)
                .ToListAsync();
        }

        public async Task AddBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBooking(int id)
        {
            var booking = await GetBookingById(id);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}