using FiltroDotnet.Models;
using FiltroDotnet.Seeders;
using Microsoft.EntityFrameworkCore;

namespace FiltroDotnet.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Aquí manejas las entidades que se corresponden con las tablas en la base de datos
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Guest> Guests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            RoomTypeSeeders.SeedRoomTypes(modelBuilder); // Asegúrate de que este método exista
            RoomSeeder.SeedRooms(modelBuilder); // Asegúrate de que este método exista
        }
    }
}