using FiltroDotnet.Models;

namespace FiltroDotnet.Repositories
{
    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task<Booking?> GetBookingById(int id);
        Task<IEnumerable<Booking>> SearchBookingsByGuestIdentification(string identificationNumber);
        Task AddBooking(Booking booking);
        Task DeleteBooking(int id);
    }
}