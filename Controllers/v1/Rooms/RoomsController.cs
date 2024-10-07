using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Rooms
{
    [ApiController]
    [Route("api/v1/rooms")]
    public class RoomsController : ControllerBase
    {
        protected readonly IRoomRepository _roomRepository; // Repositorio protegido

        // Constructor que inyecta el repositorio
        public RoomsController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository; // Asigna el repositorio
        }
    }
}