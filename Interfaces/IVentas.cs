using Microsoft.AspNetCore.Mvc;
using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetVentas(string? opcion, string? data, string? data2);
        Task<Respuesta> PostVentas([FromBody] Venta venta)
    }
}
