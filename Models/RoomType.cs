using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiltroDotnet.Models
{
    [Table("room_types")]  // Nombre de la tabla
    public class RoomType
    {
        [Key]
        [Column("id")]  // Nombre de la columna
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        [Column("name")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(255)]
        [Column("description")]
        public string Description { get; set; } = string.Empty;

        // Relación inversa
        public ICollection<Room>? Rooms { get; set; }
    }

}