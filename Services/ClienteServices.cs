using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;
using System.Linq.Expressions;
using System.Reflection;

namespace Practica2.Services
{
    public class ClienteServices : GenericServices<Cliente>, ICliente
    {
        private ControlError log = new ControlError();
        private DynamicEmpty dynamicEmpty = new DynamicEmpty();
        public ClienteServices(VentaspruebaContext context) : base(context)
        {
        }
        public async Task<Respuesta> GetCliente(string? opcion, string? data)
        {
            var result = new Respuesta();
            try
            {
                var nulls = ClienteDTO.DictionaryCliente(opcion, data);
                if (nulls != null)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    result.data = await (from x in _context.Clientes
                                         join e in _context.Estados on x.EstadoId equals e.Id
                                         select new ClienteDTO
                                         {
                                             ClienteId = x.Id,
                                             ClienteNombre = x.ClienteNombre,
                                             Cedula = x.Cedula,
                                             EstadoId = x.EstadoId,
                                             EstadoDescrip = e.EstadoDescripcion,
                                             FechaHoraReg = x.FechaHoraReg
                                         }).Where(nulls).ToListAsync();

                }
                if (dynamicEmpty.IsDynamicEmpty(result.data))
                {
                    result.cod = "111";
                    result.mensaje = $"No se encontro registro de '{opcion}' con similitud a '{data}'";
                }

            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetCliente", ex.Message);
            }
            return result;
        }       
    }
}
