using FiltroDotnet.Data;
using FiltroDotnet.DTOs;
using FiltroDotnet.Models;
using FiltroDotnet.Repositories;
using Microsoft.EntityFrameworkCore;

namespace FiltroDotnet.Services
{
    public class GuestServices : IGuestRepository
    {
        private readonly ApplicationDbContext _context;

        public GuestServices(ApplicationDbContext context)
        {
            _context = context; // Inicializa el contexto de la base de datos
        }

        public async Task<IEnumerable<Guest>> GetAllGuests()
        {
            return await _context.Guests.ToListAsync(); // Obtiene todos
        }

        public async Task<Guest?> GetGuestById(int id)
        {
            return await _context.Guests.FindAsync(id); // Busca por ID
        }

        public async Task AddGuest(GuestDTO guestDto)
        {
            var guest = new Guest
            {
                FirstName = guestDto.FirstName,
                LastName = guestDto.LastName,
                Email = guestDto.Email,
                PhoneNumber = guestDto.PhoneNumber,
            };

            _context.Guests.Add(guest); // Agrega a la base de datos
            await _context.SaveChangesAsync(); // Guarda los cambios

            guestDto.Id = guest.Id; // Asigna el ID generado al DTO
        }

        public async Task UpdateGuest(Guest guest)
        {
            _context.Guests.Update(guest); // Actualiza en la base de datos
            await _context.SaveChangesAsync(); // Guarda los cambios
        }

        public async Task DeleteGuest(int id)
        {
            var guest = await GetGuestById(id); // Busca por ID
            if (guest != null)
            {
                _context.Guests.Remove(guest); // Elimina 
                await _context.SaveChangesAsync(); // Guarda los cambios
            }
        }

        public async Task<IEnumerable<Guest>> SearchGuests(string keyword)
        {
            return await _context.Guests
                .Where(g => g.FirstName.Contains(keyword) || g.IdentificationNumber.Contains(keyword)) // Busca por palabra clave
                .ToListAsync(); // Devuelve la lista de resultados
        }
    }
}