using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Bookings
{
    [ApiController]
    [Route("api/v1/bookings/delete")]
    public class BookingsDeleteController : BookingsController
    {
        public BookingsDeleteController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var existingBooking = await _bookingRepository.GetBookingById(id);
            if (existingBooking == null) return NotFound();
            await _bookingRepository.DeleteBooking(id);
            return NoContent();
        }
    }
}