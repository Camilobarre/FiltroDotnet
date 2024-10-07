using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiltroDotnet.Models
{
    [Table("bookings")]  // Nombre de la tabla
    public class Booking
    {
        [Key]
        [Column("id")]  // Nombre de la columna
        public int Id { get; set; }

        [Required]
        [ForeignKey("Room")]
        [Column("room_id")]
        public int RoomId { get; set; }

        [Required]
        [ForeignKey("Guest")]
        [Column("guest_id")]
        public int GuestId { get; set; }

        [Required]
        [ForeignKey("Employee")]
        [Column("employee_id")]
        public int EmployeeId { get; set; }

        [Required]
        [Column("start_date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Column("end_date")]
        public DateTime EndDate { get; set; }

        [Column("total_cost", TypeName = "decimal(18,2)")]
        public decimal TotalCost { get; set; }

        // Relaciones de navegación
        public Room? Room { get; set; }
        public Guest? Guest { get; set; }
        public Employee? Employee { get; set; }
    }

}