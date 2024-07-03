using Practica2.Models;

namespace Practica2.Interfaces
{
    public interface ICatalogo
    {
        Task<Respuesta> GetMarca();
        Task<Respuesta> PostMarca(Marca marca);
        Task<Respuesta> PutMarca(Marca marca);
        Task<Respuesta> DeleteMarca(int id);
        Task<Respuesta> GetModelo();
        Task<Respuesta> PostModelo(Modelo modelo);
        Task<Respuesta> PutModelo(Modelo modelo);
        Task<Respuesta> DeleteModelo(int id);
        Task<Respuesta> GetCategoria();
        Task<Respuesta> PostCategoria(Categorium categoria);
        Task<Respuesta> PutCategoria(Categorium categoria);
        Task<Respuesta> DeleteCategoria(int id);
        Task<Respuesta> GetSucursal();
        Task<Respuesta> PostSucursal(Sucursal sucursal);
        Task<Respuesta> PutSucursal(Sucursal sucursal);
        Task<Respuesta> DeleteSucursal(int id);

    }
}
