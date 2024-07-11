
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;
using System.Linq.Expressions;
using System.Reflection;
using System.Security.Cryptography.Xml;

namespace Practica2.Services
{
    public class VentasServices : IVentas, IRepository<Venta>
    {
        private VentaspruebaContext _context;
        private ControlError log=new ControlError();
        public VentasServices(VentaspruebaContext context)
        {
            this._context = context;
        }

        public async Task<Respuesta> DeleteVentas(int idFactura)
        {
            var result = new Respuesta();
            try
            {
                var ventaDelete = await _context.Ventas.Where((x) => x.IdFactura == idFactura).FirstOrDefaultAsync();
                ventaDelete.EstadoId = 2;
                _context.Ventas.Update(ventaDelete);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {

                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message} ";
                log.LogErrorMetodos(this.GetType().Name, "DeleteVentas", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> GetReporte(double precio)
        {
            var result=new Respuesta();
            try
            {
                result.cod = "000";
                result.data=await  _context.Ventas.Where((x) => x.Precio == precio).GroupBy((g) => g.Precio).Select((s) => new { Precio=s.Key, Count = s.Count()}).ToListAsync();
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se presente una novedad, comunicarse con el departamento de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetReporte", ex.Message);
            }
            return result;
        }

        public async Task<Respuesta> GetVentas(string? opcion, string? data, string? data2)
        {
            var result=new Respuesta();
            
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                Expression<Func<VentasDTO, bool>> nulls;
                IQueryable<VentasDTO> query =  (from v in _context.Ventas
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
                       ).AsQueryable<VentasDTO>();

                if (!(opcion.IsNullOrEmpty() && data.IsNullOrEmpty()))
                {
                    if (data2.IsNullOrEmpty())
                    {
                         nulls = QuerysServices.DictionaryVentas(opcion, data);
                        if (nulls != null)
                        {
                            result.data = await query.Where(nulls).ToListAsync();
                        }
                    }
                    else
                    {
                        nulls = QuerysServices.DictionaryVentasDoble(opcion, data, data2);
                        if (nulls != null)
                        {
                            result.data = await query.Where(nulls).ToListAsync();
                        }
                    }
                }
                else
                {
                    result.data = await query.Where((x) => x.EstadoId == 3).ToListAsync();
                }
                if (DynamicEmpty.IsDynamicEmpty(result.data))
                {
                    result.cod = "111";
                    result.mensaje = data2.IsNullOrEmpty() ? $"No se encontro registro de '{opcion}' con similitud a '{data}'" : $"No se encontro registro de '{opcion}' con similitud a en rango de '{data}' y '{data2}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se presente una novedad, comunicarse con el departamento de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetVentas", ex.Message);
            }
            return result;
        }

        public async Task<Respuesta> PostVentas(Venta venta)
        {
            var result = new Respuesta();
            try
            {
                var id=await _context.Ventas.OrderByDescending((x)=>x.IdFactura).Select((x)=>x.IdFactura).FirstOrDefaultAsync()+1;
                var validar= await _context.Ventas.Where((x) => x.NumFact.Equals(venta.NumFact)).AnyAsync();
                venta.IdFactura = id;
                venta.FechaHora=DateTime.Now;
                if(!validar)
                {                
                    _context.Ventas.Add(venta);
                    await _context.SaveChangesAsync();
                }
                result.cod = validar?"111":"000";
                result.mensaje =validar? $"Ya existe la factura con numero: '{venta.NumFact}'":"OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception:{ex.Message} ";
                log.LogErrorMetodos(this.GetType().Name, "PostVentas", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PutVentas(Venta venta)
        {
            var result = new Respuesta();
            try
            {
                //var exist=await _context.Ventas.Where((x)=>)
                bool validar=await _context.Ventas.Where((x)=>x.NumFact.Equals(venta.NumFact) && !(x.IdFactura==venta.IdFactura)).AnyAsync();
                if (validar)
                {
                    _context.Ventas.Update(venta);
                    await _context.SaveChangesAsync();
                }
                result.cod = validar?"000": "111";
                result.mensaje = validar?"OK": $"El numFactura:'{venta.NumFact} le pertenece a otra factura";
            }
            catch (Exception ex)
            {

                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message} ";
                log.LogErrorMetodos(this.GetType().Name, "PutVentas", ex.Message);

            }
            return result;
        }
    }
}
