using Microsoft.AspNetCore.Mvc;
using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface IVentas
    {
        Task<Respuesta> GetVentas(string? opcion, string? data, string? data2);
         Task<Respuesta> GetReporte(double precio);
        Task<Respuesta> PostVentas(Venta venta);
        Task<Respuesta> PutVentas(Venta venta);
        Task<Respuesta> DeleteVentas(int idFactura);
    }
}
