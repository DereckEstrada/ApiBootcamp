
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using System.Linq.Expressions;
namespace Practica2.Services
{
    public class ProductoServices : IProducto, IRepository<Producto>
    {
        private VentaspruebaContext _context;
        public ProductoServices(VentaspruebaContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> DeleteProducto(int id)
        {
            var result=new Respuesta();
            bool validar = false;
            var productoDelete = new Producto();
            try
            {
                validar=await _context.Productos.Where((x)=>x.ProductoId == id).AnyAsync();
                if (validar)
                {
                    productoDelete=await _context.Productos.Where((x)=>x.ProductoId==id).FirstOrDefaultAsync();
                    productoDelete.EstadoId = 2;
                    _context.Productos.Update(productoDelete);
                    await _context.SaveChangesAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ningun producto se encontro con la id: '{id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
            }
            return result;
        }

        public async Task<Respuesta> GetProductos(string? opcion, string? data, string? data2)
            {
            var result = new Respuesta();
            Expression<Func<ProductoDTO, bool>> nulls;
            IQueryable<ProductoDTO> query = (from p in _context.Productos
                         join mar in _context.Marcas on p.MarcaId equals mar.MarcaId
                         join mod in _context.Modelos on p.ModeloId equals mod.ModeloId
                         join c in _context.Categoria on p.CategId equals c.CategId
                         join e in _context.Estados on p.EstadoId equals e.EstadoId
                         select new ProductoDTO
                         {
                            ProductoId=p.ProductoId,
                            ProductoDescrip=p.ProductoDescrip,
                            Precio = p.Precio,
                            CategNombre=c.CategNombre,
                            MarcaNombre=mar.MarcaNombre,
                            ModeloNombre=mod.ModeloDescripción,
                            EstadoId=p.EstadoId,
                            EstadoDescrip=e.EstadoDescripcion,
                            FechaHoraReg=p.FechaHoraReg,
                            CategId=p.CategId,
                            ModeloId=p.ModeloId,
                            MarcaId=p.MarcaId
                         });
            try
            {

                result.cod = "000";
                result.mensaje = "Ok";
                if (!(opcion.IsNullOrEmpty() && data.IsNullOrEmpty())) {
                    if (data2.IsNullOrEmpty())
                    {
                        nulls = QuerysServices.DictionaryProducto(opcion, data);
                        if (nulls != null)
                        {
                            result.data = await query.Where(nulls).ToListAsync();
                        }
                    }
                    else
                    {
                        nulls = QuerysServices.DictionaryProductoDoble(opcion, data, data2);
                        if (nulls != null)
                        {
                            result.data = await query.Where(nulls).ToListAsync();
                        }
                    }

                }
                else
                {
                    result.data=await query.Where((x) => x.EstadoId == 1).ToListAsync();
                }
                if (DynamicEmpty.IsDynamicEmpty(result.data)) {
                    result.cod = "111";
                    result.mensaje = data2.IsNullOrEmpty()?$"No se encontro registro de '{opcion}' con similitud a '{data}'": $"No se encontro registro de '{opcion}' con similitud a en rango de '{data}' y '{data2}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
            }
            return result;
        }

        public async Task<Respuesta> PostProducto(Producto producto)
        {
            var result = new Respuesta();
            try
            {
                var query= await _context.Productos.OrderByDescending((x)=>x.ProductoId).Select((x)=>x.ProductoId).FirstOrDefaultAsync()+1;  
                producto.ProductoId = query;
                producto.FechaHoraReg = DateTime.Now;
                _context.Productos.Add(producto);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.data= await this.GetProductos("id", Convert.ToString(producto.ProductoId), null);
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
            }
            return result;
        }

        public async Task<Respuesta> PutProducto(Producto producto)
        {
            var result = new Respuesta();
            bool validar = false;
            try
            {
                validar = await _context.Productos.Where((x) => x.ProductoId == producto.ProductoId).AnyAsync();
                if (validar)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Productos.Update(producto);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ningun producto se encontro con la id: '{producto.ProductoId}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
            }
            return result;
        }
    }
}
