
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using System.Linq.Expressions;

namespace Practica2.Services
{
    public class ClienteService : ICliente, IRepository<Cliente>
    {
        private VentaspruebaContext _context;
        public ClienteService(VentaspruebaContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> DeleteCliente(int id)
        {
            var clienteDelete = new Cliente();
            bool validar = false;
            var result = new Respuesta();
            try
            {
                validar = await _context.Clientes.Where((x) => x.ClienteId == id).AnyAsync();
                if (validar)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    clienteDelete = await _context.Clientes.Where((x) => x.ClienteId == id).FirstOrDefaultAsync();
                    clienteDelete.EstadoId = 2;
                    _context.Clientes.Update(clienteDelete);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ningun clinete se encontro con la id: '{id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
            }
            return result;
        }

        public async Task<Respuesta> GetCliente(string? opcion, string? data)
        {
            bool select = false;
            Expression<Func<ClienteDTO, bool>> nulls;

            IQueryable<ClienteDTO> query = (from c in _context.Clientes
                         join e in _context.Estados on c.EstadoId equals e.EstadoId
                         select new ClienteDTO
                         {
                             ClienteId = c.ClienteId,
                             ClienteNombre = c.ClienteNombre,
                             Cedula = c.Cedula,
                             EstadoId = c.EstadoId,
                             EstadoDescrip = e.EstadoDescripcion,
                             FechaHoraReg = c.FechaHoraReg
                         });
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                if (!(opcion.IsNullOrEmpty() && data.IsNullOrEmpty()))
                {
                    nulls = QuerysServices.DictionaryCliente(opcion, data);
                    if (nulls != null)
                    {
                        result.data = await query.Where(nulls).ToListAsync();
                    }
                }
                else
                {
                    select = true;
                    result.data= await query.Where((x) => x.EstadoId == 1).ToListAsync();
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
                result.mensaje = $"Exception: {ex.Message}";
            }
            return result;
        }

        public async Task<Respuesta> PostCliente(Cliente cliente)
        {
            bool validar = false;
            var result = new Respuesta();
            try
            {
                validar = await _context.Clientes.Where((x) => x.Cedula == cliente.Cedula).AnyAsync();
                if (validar)
                {
                    result.cod = "222";
                    result.mensaje = $"Se ha encontrado un registro con cedula: '{cliente.Cedula}'";
                } else
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    var query = await _context.Clientes.OrderByDescending((x) => x.ClienteId).Select((x) => x.ClienteId).FirstOrDefaultAsync() + 1;
                    cliente.ClienteId = query;
                    cliente.FechaHoraReg = DateTime.Now;
                    _context.Clientes.Add(cliente);
                    await _context.SaveChangesAsync();
                }

            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
            }
            return result;
        }

        public async Task<Respuesta> PutCliente(Cliente cliente)
        {
            bool validar = false;
            bool cedula = false;
            var result = new Respuesta();
            try
            {
                validar = await _context.Clientes.Where((x) => x.ClienteId == cliente.ClienteId).AnyAsync();
                cedula = !await _context.Clientes.Where(x => x.Cedula == cliente.Cedula || x.ClienteId != cliente.ClienteId).AnyAsync();

                if (validar)
                {
                    cedula = true;
                    if(cedula){
                    result.cod = "000";
                    result.mensaje= "OK";
                    _context.Clientes.Update(cliente);
                        await _context.SaveChangesAsync();
                    }
                    else
                    {
                        result.cod="222";
                        result.mensaje=$"Error en actualizacion ya existe otro cliente con cedula: '{cliente.Cedula}";
                    }
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ningun cliente se encontro con la id: '{cliente.ClienteId}'";
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
