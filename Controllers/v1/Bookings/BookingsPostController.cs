using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Bookings
{
    [ApiController]
    [Route("api/v1/bookings/post")]
    [Tags("bookings")]
    public class BookingsPostController : BookingsController
    {
        public BookingsPostController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateBooking(Booking booking)
        {
            await _bookingRepository.AddBooking(booking); // Usa el repositorio de la clase base
            return CreatedAtAction(nameof(BookingsGetController.GetBookingById), new { id = booking.Id }, booking);
        }
    }
}