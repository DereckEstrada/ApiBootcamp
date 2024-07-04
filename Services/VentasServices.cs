using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using System.Linq.Expressions;
using System.Security.Cryptography.Xml;

namespace Practica2.Services
{
    public class VentasServices : IVentas, IRepository<Venta>
    {
        private VentaspruebaContext _context;
        public VentasServices(VentaspruebaContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> GetVentas(string? opcion, string? data, string? data2)
        {
            var result=new Respuesta();

            try
            {
                int.TryParse(data, out int in1);
                double.TryParse(data, out double double1);
                double.TryParse(data2, out double double2);
                //DateTime.TryParse(data, out DateTime date1);
                //DateTime.TryParse(data2, out DateTime date2);
                IQueryable<VentasDTO> query = (from v in _context.Ventas
                                               join c in _context.Clientes on v.ClienteId equals c.ClienteId
                                               join p in _context.Productos on v.ProductoId equals p.ProductoId
                                               join mo in _context.Modelos on v.ModeloId equals mo.ModeloId
                                               join categ in _context.Categoria on v.CategId equals categ.CategId
                                               join mar in _context.Marcas on v.MarcaId equals mar.MarcaId
                                               join s in _context.Sucursals on v.SucursalId equals s.SucursalId
                                               join caja in _context.Cajas on v.CajaId equals caja.CajaId
                                               join vende in _context.Vendedors on v.VendedorId equals vende.VendedorId
                                               join e in _context.Estados on v.EstadoId equals e.EstadoId
                                               select new VentasDTO
                                               {
                                                   IdFactura = v.IdFactura,
                                                   NumFact = v.NumFact,
                                                   FechaHora = v.FechaHora,
                                                   ClienteId = v.ClienteId,
                                                   ClienteDetalle = c.ClienteNombre,
                                                   ClienteCedulaDetalle = c.Cedula,
                                                   ProductoId = v.ProductoId,
                                                   ProductoDetalle = p.ProductoDescrip,
                                                   ModeloId = v.ModeloId,
                                                   ModeloDetalle = mo.ModeloDescripción,
                                                   MarcaId = v.MarcaId,
                                                   MarcaDetalle = mar.MarcaNombre,
                                                   CategId = v.CategId,
                                                   CategDetalle = categ.CategNombre,
                                                   Precio = v.Precio,
                                                   Unidades = v.Unidades,
                                                   SucursalId = v.SucursalId,
                                                   SucursalDetalle = s.SucursalNombre,
                                                   CajaId = v.CajaId,
                                                   CajaDetalle = caja.CajaDescripcion,
                                                   VendedorId = v.VendedorId,
                                                   VendedorDetalle = vende.VendedorDescripcion,
                                                   EstadoId = v.EstadoId,
                                                   EstadoDetalle = e.EstadoDescripcion
                                               }
                       );
                var dictionary = new Dictionary<string, Expression<Func<VentasDTO, bool>>>();
                dictionary.Add("idFactura", (x) => x.IdFactura == in1 && x.EstadoId == 3);

                var dictionaryDoble=new Dictionary<string, Expression<Func<VentasDTO, bool>>>();

                if (!(opcion.IsNullOrEmpty()&& data.IsNullOrEmpty()))
                {
                    if (data2.IsNullOrEmpty())
                    {
                        switch (opcion.ToLower())
                        {
                            case "id":
                                if(int.TryParse(data, out int id))
                                {
                                    result.data = await query.Where((x)=>x.IdFactura==id && x.EstadoId==3).ToListAsync();
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            case "numfactura":
                                if(data.IsNullOrEmpty())
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' en es compatible para la opcion: '{opcion}'";
                                }
                                else
                                {
                                    result.data = await query.Where((x) => x.NumFact.Equals(data)&& x.EstadoId == 3).ToListAsync();
                                }
                                break;
                            case "precio":
                                if(double.TryParse(data, out double precio))
                                {
                                    result.data = await query.Where((x) => x.Precio == precio && x.EstadoId == 3).ToListAsync();
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            case "estado":
                                if(int.TryParse(data, out int estado))
                                {
                                    result.data = await query.Where((x) => x.EstadoId == estado).ToListAsync();
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            case "vendedor":
                                if(int.TryParse(data, out int vendedorId))
                                {
                                    result.data = await query.Where((x)=> x.VendedorId== vendedorId && x.EstadoId==3).ToListAsync();
                                }
                                break;
                            case "clienteid":
                                if(int.TryParse(data, out int cliente))
                                {
                                    result.data = await query.Where((x) => x.ClienteId == cliente && x.EstadoId == 3).ToListAsync();
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            case "producto":
                                if(int.TryParse(data, out int producto))
                                {
                                    result.data = await query.Where((x) => x.ProductoId == producto && x.EstadoId==3).ToListAsync();
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' en es compatible para la opcion: '{opcion}'";
                                }
                                break; 
                            case "categoria":
                                if(int.TryParse(data, out int categoria))
                                {
                                    result.data = await query.Where((x) => x.CategId == categoria && x.EstadoId == 3).ToListAsync();
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            case "fecha":
                                if(DateTime.TryParse(data, out DateTime date))
                                {
                                    result.data = await query.Where((x)=>x.FechaHora==date && x.EstadoId==3).ToListAsync();
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            default:
                                result.cod = "333";
                                result.mensaje = $"Error en opcion: '{opcion}' no reconocida";
                             break;

                        }
                    }
                    else
                    {
                        switch (opcion.ToLower())
                        {
                            case "precio":
                                if(double .TryParse(data, out double precio1) && double.TryParse(data2, out double precio2))
                                {
                                    if (precio1 < precio2)
                                    {
                                        result.data = await query.Where((x) => precio1 <=x.Precio &&x.Precio <=precio2 && x.EstadoId==3).ToListAsync();
                                    }
                                    else
                                    {
                                        result.data = await query.Where((x) => precio2 <= x.Precio && x.Precio <= precio1 && x.EstadoId == 3).ToListAsync();

                                    }
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' y/o '{data2} en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            case "fecha":
                                if(DateTime.TryParse(data, out DateTime date1) && DateTime.TryParse(data2, out DateTime date2))
                                {
                                    if (date1 < date2)
                                    {
                                        result.data= await query.Where((x) => date1 <= x.FechaHora && x.FechaHora <= date2 && x.EstadoId == 3).ToListAsync();

                                    }
                                    else
                                    {
                                        result.data=await query.Where((x) => date2 <= x.FechaHora && x.FechaHora <= date2 && x.EstadoId == 3).ToListAsync();

                                    }
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' y/o '{data2} en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            case "unidades":
                                if(int.TryParse(data, out int un1) && int.TryParse(data2, out int un2))
                                {
                                    if (un1 < un2)
                                    {
                                       result.data =await query.Where((x) => un1 <= x.Unidades && x.Unidades<= un2 && x.EstadoId == 3).ToListAsync();
                                    }
                                    else
                                    {
                                        result.data= await query.Where((x) => un2 <= x.Unidades && x.Unidades <= un1 && x.EstadoId == 3).ToListAsync();
                                    }
                                }
                                else
                                {
                                    result.cod = "999";
                                    result.mensaje = $"Error en data:'{data}' y/o '{data2} en es compatible para la opcion: '{opcion}'";
                                }
                                break;
                            default:
                                result.cod = "333";
                                result.mensaje = $"Error en opcion: '{opcion}' no reconocida para dos datas";
                                break;
                        }    
                    }
                }
                else
                {
                    result.data =await query.Where((x) => x.EstadoId == 3).ToListAsync();
                }
                if (DynamicEmpty.IsDynamicEmpty(result.data))
                {
                    result.cod = "111";
                    result.mensaje = $"No se encontro registro de '{opcion}' con similitud a '{data}'";
                }
            }
            catch (Exception ex)
            {

                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message} ";
            }
            return result;
        }

        public async Task<Respuesta> PostVentas([FromBody] Venta venta)
        {
            var result = new Respuesta();
            try
            {
                var id=await _context.Ventas.OrderByDescending((x)=>x.IdFactura).Select((x)=>x.IdFactura).FirstOrDefaultAsync()+1;
                venta.IdFactura = id;
                venta.FechaHora=DateTime.Now;
                _context.Ventas.Add(venta);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception:{ex.Message} ";
            }
            return result;
        }
    }
}
