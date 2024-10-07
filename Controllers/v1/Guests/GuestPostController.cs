using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/[controller]")]
    public class GuestPostController : GuestsController
    {
        public GuestPostController(IGuestRepository guestRepository) : base(guestRepository)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterGuest(Guest guest)
        {
            await _guestRepository.AddGuest(guest); // Usa el repositorio de la clase base
            return CreatedAtAction(nameof(GuestsGetController.GetGuestById), new { id = guest.Id }, guest);
        }
    }
}