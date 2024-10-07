using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Bookings
{
    [ApiController]
    [Route("api/v1/bookings/get")]
    [Tags("bookings")]
    public class BookingsGetController : BookingsController
    {
        public BookingsGetController(IBookingRepository bookingRepository) : base(bookingRepository)
        {
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _bookingRepository.GetBookingById(id); // Usa el repositorio de la clase base
            if (booking == null) return NotFound();
            return Ok(booking);
        }

        [HttpGet("search/{identification_number}")]
        [Authorize]
        public async Task<IActionResult> GetBookingsByGuestIdentification(string identification_number)
        {
            var bookings = await _bookingRepository.SearchBookingsByGuestIdentification(identification_number); // Usa el repositorio de la clase base
            return Ok(bookings);
        }
    }
}