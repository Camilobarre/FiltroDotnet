using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/v1/guests/post")]
    public class GuestPostController : GuestsController
    {
        public GuestPostController(IGuestRepository guestRepository) : base(guestRepository)
        {
        }
        
        [HttpPost]
        public async Task<IActionResult> RegisterGuest(Guest guest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _guestRepository.AddGuest(guest);
            return CreatedAtAction(nameof(GuestsGetController.GetGuestById), new { id = guest.Id }, guest);
        }
    }
}