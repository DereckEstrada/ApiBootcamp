using Microsoft.AspNetCore.Mvc;
using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface IProducto
    {
        Task<Respuesta> GetProductos(string? opcion, string? data, string? data2);
        Task<Respuesta> PostProducto(Producto producto);
        Task<Respuesta> PutProducto(Producto producto);
        Task<Respuesta> DeleteProducto(int id);
    }
}
