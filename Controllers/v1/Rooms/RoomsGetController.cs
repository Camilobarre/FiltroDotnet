using FiltroDotnet.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FiltroDotnet.Controllers.v1.Rooms
{
    [ApiController]
    [Route("api/v1/rooms")]
    public class RoomsGetController : RoomsController // Hereda de RoomsController
    {
        public RoomsGetController(IRoomRepository roomRepository)
            : base(roomRepository) // Llama al constructor de la clase base
        {
        }

        [HttpGet("available")]
        public async Task<IActionResult> GetAvailableRooms()
        {
            var rooms = await _roomRepository.GetAvailableRooms();
            return Ok(rooms);
        }

        [HttpGet("occupied")]
        [Authorize]
        public async Task<IActionResult> GetOccupiedRooms()
        {
            var rooms = await _roomRepository.GetOccupiedRooms();
            return Ok(rooms);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var room = await _roomRepository.GetRoomById(id);
            if (room == null) return NotFound();
            return Ok(room);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllRooms()
        {
            var rooms = await _roomRepository.GetAllRooms();
            return Ok(rooms);
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetRoomStatus()
        {
            var (availableCount, occupiedCount) = await _roomRepository.GetRoomStatusAsync();
            var roomStatus = new
            {
                AvailableRooms = availableCount,
                OccupiedRooms = occupiedCount
            };

            return Ok(roomStatus);
        }
    }
}