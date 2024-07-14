using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;
using System.Linq.Expressions;

namespace Practica2.Services
{
    public class ProductoServices : GenericServices<Producto>, IProducto
    {
        private ControlError log = new ControlError();
        private DynamicEmpty dynamicEmpty = new DynamicEmpty();
        public ProductoServices(VentaspruebaContext context) : base(context)
        {
        }
        public async Task<Respuesta> GetProductos(string? opcion, string? data, string? data2)
        {
            var result = new Respuesta();
            try
            {
                Expression<Func<ProductoDTO, bool>> nulls = ProductoDTO.DictionaryProducto(opcion, data, data2);
                if (nulls != null)
                {
                    result.data = await (from p in _context.Productos
                                         join mar in _context.Marcas on p.MarcaId equals mar.Id
                                         join mod in _context.Modelos on p.ModeloId equals mod.Id
                                         join c in _context.Categoria on p.CategId equals c.Id
                                         join e in _context.Estados on p.EstadoId equals e.Id
                                         select new ProductoDTO
                                         {
                                             ProductoId = p.Id,
                                             ProductoDescrip = p.ProductoDescrip,
                                             Precio = p.Precio,
                                             CategNombre = c.CategNombre,
                                             MarcaNombre = mar.MarcaNombre,
                                             ModeloNombre = mod.ModeloDescripción,
                                             EstadoId = p.EstadoId,
                                             EstadoDescrip = e.EstadoDescripcion,
                                             FechaHoraReg = p.FechaHoraReg,
                                             CategId = p.CategId,
                                             ModeloId = p.ModeloId,
                                             MarcaId = p.MarcaId
                                         }).Where(nulls).ToListAsync();
                }
                result.cod = "000";
                result.mensaje = "Ok";
                if (dynamicEmpty.IsDynamicEmpty(result.data))
                {
                    result.cod = "111";
                    result.mensaje = data2.IsNullOrEmpty() ? $"No se encontro registro de '{opcion}' con similitud a '{data}'" : $"No se encontro registro de '{opcion}' con similitud a en rango de '{data}' y '{data2}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetProductos", ex.Message);

            }
            return result;
        }
    }
}
