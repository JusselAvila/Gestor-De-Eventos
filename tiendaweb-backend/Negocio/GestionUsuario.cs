using Isopoh.Cryptography.Argon2;
using tiendaweb_backend.Datos;
using tiendaweb_backend.Models;

namespace tiendaweb_backend.Negocio;

public class GestionUsuarios
{
    private readonly AppDbContext _context;

    public GestionUsuarios(AppDbContext context) => _context = context;

    public List<Usuario> ObtenerTodos() => _context.Usuarios.ToList();

    public Usuario? ObtenerPorId(int id) => _context.Usuarios.Find(id);

    public void RegistrarUsuario(string email, string password)
    {
        if (_context.Usuarios.Any(u => u.Email == email))
            throw new Exception("El correo ya está registrado.");

        string passwordHash = Argon2.Hash(password); 

        var nuevoUsuario = new Usuario {
            Email = email,
            PasswordHash = passwordHash,
            RolId = 1
        };

        _context.Usuarios.Add(nuevoUsuario);
        _context.SaveChanges();
    }

    public void ActualizarUsuario(Usuario usuarioActualizado, string? nuevaPassword = null)
    {
        var usuario = _context.Usuarios.Find(usuarioActualizado.Id);
        if (usuario == null) throw new Exception("Usuario no encontrado");

        usuario.Email = usuarioActualizado.Email;
        usuario.Nombre = usuarioActualizado.Nombre;
        usuario.RolId = usuarioActualizado.RolId;

        if (!string.IsNullOrEmpty(nuevaPassword))
        {
            usuario.PasswordHash = Argon2.Hash(nuevaPassword);
        }
        
        _context.SaveChanges();
    }

    public void EliminarUsuario(int id)
    {
        var usuario = _context.Usuarios.Find(id);
        if (usuario == null) throw new Exception("Usuario no encontrado");

        _context.Usuarios.Remove(usuario);
        _context.SaveChanges();
    }

    public Usuario? ValidarCredenciales(string email, string password)
    {
        var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
        
        if (usuario != null && Argon2.Verify(usuario.PasswordHash, password))
        {
            return usuario;
        }
        return null;
    }
}