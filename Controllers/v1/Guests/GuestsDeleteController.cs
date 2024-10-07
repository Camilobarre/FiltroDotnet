using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/v1/guests/delete")]
    public class GuestsDeleteController : GuestsController
    {
        public GuestsDeleteController(IGuestRepository guestRepository) : base(guestRepository)
        {
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuest(int id)
        {
            var existingGuest = await _guestRepository.GetGuestById(id);
            if (existingGuest == null) return NotFound();
            await _guestRepository.DeleteGuest(id);
            return NoContent();
        }
    }
}