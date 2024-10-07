using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Guests
{
    [ApiController]
    [Route("api/v1/guests")]
    [Tags("guests")]
    public class GuestsController : ControllerBase
    {
        protected readonly IGuestRepository _guestRepository; // Repositorio protegido

        // Constructor que inyecta el repositorio
        public GuestsController(IGuestRepository guestRepository)
        {
            _guestRepository = guestRepository; // Asigna el repositorio
        }
    }
}