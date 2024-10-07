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
            : base(guestRepository) // Constructor que llama a la clase base
        {
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllGuests()
        {
            var guests = await _guestRepository.GetAllGuests(); // Obtiene todos los huéspedes
            return Ok(guests); // Devuelve en formato JSON
        }

        [HttpGet("{id}", Name = "GetGuestById")]
        [Authorize]
        public async Task<IActionResult> GetGuestById(int id)
        {
            var guest = await _guestRepository.GetGuestById(id); // Obtiene por ID
            if (guest == null) return NotFound(); // Devuelve 404 si no se encuentra
            return Ok(guest);
        }

        [HttpGet("search/{keyword}")]
        [Authorize]
        public async Task<IActionResult> SearchGuest(string keyword)
        {
            var guests = await _guestRepository.SearchGuests(keyword); // Busca por palabra clave
            return Ok(guests); // Devuelve los resultados de la búsqueda
        }
    }
}