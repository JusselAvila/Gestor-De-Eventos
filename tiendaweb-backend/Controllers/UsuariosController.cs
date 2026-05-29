using Microsoft.AspNetCore.Mvc;
using tiendaweb_backend.Negocio;
using tiendaweb_backend.Models;
using tiendaweb_backend.Servicios;
using Microsoft.AspNetCore.Authorization;

namespace tiendaweb_backend.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly GestionUsuarios _gestionUsuarios;
    private readonly TokenServicio _tokenServicio;

    public UsuariosController(GestionUsuarios gestionUsuarios, TokenServicio tokenServicio)
    {
        _gestionUsuarios = gestionUsuarios;
        _tokenServicio = tokenServicio;
    }

    [AllowAnonymous]
    [HttpPost("login")]
    public IActionResult Login([FromBody] RegistroRequest request)
    {
        var usuario = _gestionUsuarios.ValidarCredenciales(request.Email, request.Password);
        
        if (usuario == null)
            return Unauthorized(new { message = "Credenciales inválidas" });

        var token = _tokenServicio.GenerarToken(usuario);
        return Ok(new { token });
    }

    [HttpGet]
    public IActionResult Listar() => Ok(_gestionUsuarios.ObtenerTodos());

    [HttpGet("{id}")]
    public IActionResult Obtener(int id)
    {
        var usuario = _gestionUsuarios.ObtenerPorId(id);
        return usuario != null ? Ok(usuario) : NotFound(new { message = "Usuario no encontrado" });
    }

    [AllowAnonymous]
    [HttpPost("registrar")]
    public IActionResult Registrar([FromBody] RegistroRequest request)
    {
        try
        {
            _gestionUsuarios.RegistrarUsuario(request.Email, request.Password);
            return Ok(new { message = "Usuario registrado exitosamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpPut("actualizar")]
    public IActionResult Actualizar([FromBody] ActualizarUsuarioRequest request)
    {
        try
        {
            var usuario = new Usuario { 
                Id = request.Id, 
                Email = request.Email, 
                Nombre = request.Nombre,
                RolId = request.RolId 
            };
            
            _gestionUsuarios.ActualizarUsuario(usuario, request.Password);
            return Ok(new { message = "Usuario actualizado correctamente" });
        }
        catch (Exception ex)
        {
            return BadRequest(new { message = ex.Message });
        }
    }

    [HttpDelete("{id}")]
    public IActionResult Eliminar(int id)
    {
        try
        {
            _gestionUsuarios.EliminarUsuario(id);
            return Ok(new { message = "Usuario eliminado correctamente" });
        }
        catch (Exception ex)
        {
            return NotFound(new { message = ex.Message });
        }
    }
}

public class RegistroRequest {
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
}

public class ActualizarUsuarioRequest {
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Nombre { get; set; } = string.Empty;
    public int RolId { get; set; }
    public string? Password { get; set; } 
}