using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;

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
            var query = (from c in _context.Clientes
                         join e in _context.Estados on c.EstadoId equals e.EstadoId
                         select new
                         {
                             Cliente = c,
                             Estado = e
                         });
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                if (!(opcion.IsNullOrEmpty() && data.IsNullOrEmpty()))
                {
                    switch (opcion.ToLower())
                    {
                        case "id":
                            if (int.TryParse(data, out int id))
                            {
                                query = query.Where((x) => x.Cliente.ClienteId == id && x.Cliente.EstadoId == 1);
                                select = true;
                            }
                            else
                            {
                                result.cod = "999";
                                result.mensaje = $"Error en data: '{data}' en es compatible para ID";
                            }
                            break;
                        case "nombre":
                            if (string.IsNullOrEmpty(data))
                            {
                                result.cod = "999";
                                result.mensaje = "La data se encuentra vacia";
                            }
                            else
                            {
                                query = query.Where((x) => x.Cliente.ClienteNombre.ToLower().Contains(data.ToLower()) && x.Cliente.EstadoId == 1);
                                select = true;
                            }
                            break;
                        case "cedula":
                            if (int.TryParse(data, out int cedula))
                            {
                                query = query.Where((x) => x.Cliente.Cedula == cedula && x.Cliente.EstadoId == 1);
                                select = true;
                            }
                            else
                            {
                                result.mensaje = $"Error en data: '{data}' en es compatible para Cedula";
                            }
                            break;
                    }
                }
                else
                {
                    select = true;
                    query = query.Where((x) => x.Cliente.EstadoId == 1);
                }
                if (select) {
                    result.data = await query.Select((x) => new ClienteDTO
                    {
                        ClienteId = x.Cliente.ClienteId,
                        ClienteNombre = x.Cliente.ClienteNombre,
                        Cedula = x.Cliente.Cedula,
                        EstadoDescrip = x.Estado.EstadoDescripcion,
                        FechaHoraReg = x.Cliente.FechaHoraReg
                    }).ToListAsync();
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
