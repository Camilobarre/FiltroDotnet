using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/v1/guests/put")]
    public class GuestsPutController : GuestsController
    {
        public GuestsPutController(IGuestRepository guestRepository) : base(guestRepository)
        {
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateGuest(int id, Guest guest)
        {
            if (id != guest.Id) return BadRequest();
            var existingGuest = await _guestRepository.GetGuestById(id);
            if (existingGuest == null) return NotFound();
            await _guestRepository.UpdateGuest(guest);
            return NoContent();
        }
    }
}