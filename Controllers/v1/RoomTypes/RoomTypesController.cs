using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.RoomTypes
{
    [ApiController]
    [Route("api/v1/room_types")]
    [Tags("roomTypes")]
    public class RoomTypesController : ControllerBase
    {
        protected readonly IRoomTypeRepository _roomTypeRepository; // Repositorio protegido

        // Constructor que inyecta el repositorio
        public RoomTypesController(IRoomTypeRepository roomTypeRepository)
        {
            _roomTypeRepository = roomTypeRepository; // Asigna el repositorio
        }
    }
}