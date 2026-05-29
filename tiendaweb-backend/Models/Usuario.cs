
namespace tiendaweb_backend.Models;

public class Usuario {
    public int Id { get; set; }
    public string Nombre { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty; // Aquí guardarás el Argon2id
    public int RolId { get; set; }
}