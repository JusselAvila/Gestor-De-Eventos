using tiendaweb_backend.Datos;

namespace tiendaweb_backend.Negocio;

public class GestionProductos
{
    public List<Producto> ListaProductos()
    {
        var result = new List<Producto>
        {
            new() {Id = 1, Nombre = "Mouse", Descripcion = "hardware", Precio = 12.45},
            new() {Id = 2, Nombre = "Monitor", Descripcion = "hardware", Precio = 100.0},
            new() {Id = 3, Nombre = "Teclado", Descripcion = "hardware", Precio = 50.5}
        };

        return result;
    }
}