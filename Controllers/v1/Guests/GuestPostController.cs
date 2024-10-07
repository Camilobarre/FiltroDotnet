using FiltroDotnet.DTOs;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/v1/guests/post")]
    [Tags("guests")]
    public class GuestPostController : GuestsController
    {
        public GuestPostController(IGuestRepository guestRepository) : base(guestRepository)
        {
        }

        [HttpPost]
        public async Task<IActionResult> RegisterGuest([FromBody] GuestDTO guestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _guestRepository.AddGuest(guestDto);

            // Usar CreatedAtRoute con el nombre de la ruta "GetGuestById"
            return CreatedAtRoute("GetGuestById", new { id = guestDto.Id }, guestDto);
        }
    }
}