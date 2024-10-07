using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiltroDotnet.Models
{
    [Table("rooms")]  // Nombre de la tabla
    public class Room
    {
        [Key]
        [Column("id")]  // Nombre de la columna
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("room_number")]  // Nombre de la columna
        public string RoomNumber { get; set; } = string.Empty;

        [Required]
        [ForeignKey("RoomType")]
        [Column("room_type_id")]  // Llave foránea y nombre de la columna
        public int RoomTypeId { get; set; }

        [Column("price_per_night", TypeName = "decimal(18,2)")]  // Columna con tipo de dato decimal
        public decimal PricePerNight { get; set; }

        [Column("availability")]  // Columna boolean
        public bool Availability { get; set; }

        [Column("max_occupancy_persons")]  // Columna para la capacidad máxima
        [Range(1, 10, ErrorMessage = "The occupancy must be between 1 and 10.")]
        public int MaxOccupancyPersons { get; set; }

        // Relaciones de navegación
        public RoomType? RoomType { get; set; }
        public ICollection<Booking>? Bookings { get; set; }
    }
}