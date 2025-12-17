using System.ComponentModel.DataAnnotations;

namespace AuthenticationAPI_Database.Model
{
    public class Usuario
    {
        [Key]
        public int usuarioId { get; set; }
        public string correo { get; set; }
        public string contrasena { get; set; }
    }
}
