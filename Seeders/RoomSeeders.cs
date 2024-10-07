using FiltroDotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace FiltroDotnet.Seeders
{
    public static class RoomSeeder
    {
        public static void SeedRooms(ModelBuilder modelBuilder)
        {
            const int totalFloors = 5;
            const int roomsPerFloor = 10;

            int roomNumber = 1;

            for (int floor = 1; floor <= totalFloors; floor++)
            {
                for (int roomIndex = 1; roomIndex <= roomsPerFloor; roomIndex++)
                {
                    // Asignar tipos de habitación cíclicamente
                    int roomTypeId = (roomNumber - 1) % 4 + 1; // Alternar entre 1 a 4

                    modelBuilder.Entity<Room>().HasData(new Room
                    {
                        Id = roomNumber,
                        RoomNumber = $"F{floor}R{roomIndex}", // Ejemplo: F1R1
                        RoomTypeId = roomTypeId,
                        PricePerNight = roomTypeId switch
                        {
                            1 => 50,
                            2 => 80,
                            3 => 150,
                            4 => 200,
                            _ => throw new ArgumentOutOfRangeException()
                        },
                        Availability = true,
                        MaxOccupancyPersons = roomTypeId switch
                        {
                            1 => 1,
                            2 => 2,
                            3 => 2,
                            4 => 4,
                            _ => throw new ArgumentOutOfRangeException()
                        }
                    });

                    roomNumber++;
                }
            }
        }
    }
}