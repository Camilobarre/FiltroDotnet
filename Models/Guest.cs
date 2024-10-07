using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiltroDotnet.Models
{
    [Table("guests")]  // Nombre de la tabla
    public class Guest
    {
        [Key]
        [Column("id")]  // Nombre de la columna
        public int Id { get; set; }


        [MaxLength(255)]
        [Column("first_name")]
        public string FirstName { get; set; } = string.Empty;


        [MaxLength(255)]
        [Column("last_name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [MaxLength(255)]
        [Column("email")]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        [Column("identification_number")]
        public string IdentificationNumber { get; set; } = string.Empty;

        [Phone]
        [MaxLength(20)]
        [Column("phone_number")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column("birthdate")]
        public DateTime Birthdate { get; set; }

        // Relación con Bookings
        public ICollection<Booking>? Bookings { get; set; }
    }
}