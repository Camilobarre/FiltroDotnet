using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.RoomTypes
{
    [ApiController]
    [Route("api/v1/room_types")]
    [Tags("roomTypes")]
    public class RoomTypesGetController : RoomTypesController
    {
        public RoomTypesGetController(IRoomTypeRepository roomTypeRepository) : base(roomTypeRepository)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomTypes()
        {
            var roomTypes = await _roomTypeRepository.GetAllRoomTypes(); // Usa el repositorio de la clase base
            return Ok(roomTypes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRoomTypeById(int id)
        {
            var roomType = await _roomTypeRepository.GetRoomTypeById(id); // Usa el repositorio de la clase base
            if (roomType == null) return NotFound();
            return Ok(roomType);
        }
    }
}