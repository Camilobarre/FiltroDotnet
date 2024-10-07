using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/v1/guests/get")]
    [Tags("guests")]
    public class GuestsGetController : GuestsController // Hereda de GuestsController
    {
        public GuestsGetController(IGuestRepository guestRepository)
            : base(guestRepository) // Llama al constructor de la clase base
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _guestRepository.GetAllGuests(); // Usa el repositorio de la clase base
            return Ok(guests);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestRepository.GetGuestById(id); // Usa el repositorio de la clase base
            if (guest == null) return NotFound();
            return Ok(guest);
        }

        [HttpGet("search/{keyword}")]
        [Authorize]
        public async Task<IActionResult> SearchGuest(string keyword)
        {
            var guests = await _guestRepository.SearchGuests(keyword); // Usa el repositorio de la clase base
            return Ok(guests);
        }
    }

}