using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltroDotnet.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public double PricePerNight { get; set; }
        public bool Availability { get; set; }
        public int MaxOccupancyPersons { get; set; }
        public string RoomTypeName { get; set; } = string.Empty;
    }

}