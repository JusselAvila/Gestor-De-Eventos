using Microsoft.AspNetCore.Mvc;
using tiendaweb_backend.Datos;
using tiendaweb_backend.Negocio;

namespace tiendaweb_backend.Controllers;

[ApiController]
[Route("[controller]")]
public class GestionProductosController : ControllerBase
{
    private GestionProductos _gestionProductos;

    public GestionProductosController()
    {
        _gestionProductos = new GestionProductos();
    }

    [HttpGet("lista-productos")]
    public IEnumerable<Producto> ListaProductos()
    {
        return _gestionProductos.ListaProductos();
    }
}