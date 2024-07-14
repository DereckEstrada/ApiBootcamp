using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface ICaja: IGeneric<Caja>
    {
        Task<Respuesta> GetCaja(string? opcion, string? data);
    }
}
