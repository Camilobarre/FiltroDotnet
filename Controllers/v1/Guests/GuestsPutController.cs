using FiltroDotnet.DTOs;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/v1/guests/put")]
    [Tags("guests")]
    public class GuestsPutController : GuestsController
    {
        public GuestsPutController(IGuestRepository guestRepository) : base(guestRepository)
        {
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateGuest(int id, GuestDTO guestDto)
        {
            if (id != guestDto.Id) return BadRequest();

            // Obtener el guest existente
            var existingGuest = await _guestRepository.GetGuestById(id);
            if (existingGuest == null) return NotFound();

            // Actualizar las propiedades del guest existente con los datos del DTO
            existingGuest.FirstName = guestDto.FirstName;
            existingGuest.LastName = guestDto.LastName;
            existingGuest.Email = guestDto.Email;
            existingGuest.PhoneNumber = guestDto.PhoneNumber;

            // Pasar el guest actualizado al servicio
            await _guestRepository.UpdateGuest(existingGuest);
            return NoContent();
        }
    }
}