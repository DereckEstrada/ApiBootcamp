using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface ICliente : IGeneric<Cliente>
    {
        Task<Respuesta> GetCliente(string? opcion, string? data);
    }
}
