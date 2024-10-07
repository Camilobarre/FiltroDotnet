using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Bookings
{
    [ApiController]
    [Route("api/v1/bookings")]
    public class BookingsController : ControllerBase
    {
        protected readonly IBookingRepository _bookingRepository; // Repositorio protegido

        // Constructor que inyecta el repositorio
        public BookingsController(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository; // Asigna el repositorio
        }
    }
}