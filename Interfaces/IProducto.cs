using Microsoft.AspNetCore.Mvc;
using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface IProducto:IGeneric<Producto>
    {
        Task<Respuesta> GetProductos(string? opcion, string? data, string? data2);

    }
}
