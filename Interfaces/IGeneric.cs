using Practica2.Models;
using System.Formats.Tar;

namespace Practica2.Interfaces
{
    //La implementar esta interfaz podremos hacer uso de metodos genericos
    public interface IGeneric<T>
    {
        Task<Respuesta> Post(T value);
        Task<Respuesta> Put(T value);
        Task<Respuesta> Delete(int id);
    }
}
