using Microsoft.EntityFrameworkCore;

namespace api.Models
{
    [Keyless]
    public class Usuario
    {
        public int Id { get; set; }
        public string correo { get; set; }
        public string contra { get; set; }
    }
}
