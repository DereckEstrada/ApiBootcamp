using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface ICliente
    {
        Task<Respuesta> GetCliente(string? opcion, string? data);
        Task<Respuesta> PostCliente(Cliente cliente);
        Task<Respuesta> PutCliente(Cliente cliente);
        Task<Respuesta> DeleteCliente(int id);
    }
}
