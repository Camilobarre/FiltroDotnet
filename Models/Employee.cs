using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FiltroDotnet.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string IdentificationNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        // Relaciones
        public ICollection<Booking> Bookings { get; set; }
    }

}