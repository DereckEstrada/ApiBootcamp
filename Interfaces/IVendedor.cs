using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface IVendedor: IGeneric<Vendedor>
    {
        Task<Respuesta> GetVendedor(string? opcion, string? data);
    }
}
