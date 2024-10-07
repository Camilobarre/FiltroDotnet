using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltroDotnet.Models
{
    public class Room
    {
        public int Id { get; set; }
        public string RoomNumber { get; set; } = string.Empty;
        public int RoomTypeId { get; set; }
        public double PricePerNight { get; set; }
        public bool Availability { get; set; }
        public int MaxOccupancyPersons { get; set; }

        // Relaciones
        public RoomType RoomType { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }

}