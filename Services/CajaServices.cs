using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;
using System.Linq.Expressions;

namespace Practica2.Services
{
    public class CajaServices : GenericServices<Caja>, ICaja
    {
        private ControlError log=new ControlError();
        private DynamicEmpty dynamicEmpty=new DynamicEmpty();
        public CajaServices(VentaspruebaContext context) : base(context)
        {
        }
        public async Task<Respuesta> GetCaja(string? opcion, string? data)
        {
            var result = new Respuesta();
            Expression<Func<CajaDTO, bool>> nulls = CajaDTO.DictionaryCaja(opcion, data);
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                if (nulls != null)
                {
                    result.data = await (from c in _context.Cajas
                                         join e in _context.Estados on c.EstadoId equals e.Id
                                         select new CajaDTO
                                         {
                                             CajaId = c.Id,
                                             CajaDescripcion = c.CajaDescripcion,
                                             FechaHoraReg = c.FechaHoraReg,
                                             EstadoId = c.EstadoId,
                                             EstadoDescrip = e.EstadoDescripcion
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
                log.LogErrorMetodos(this.GetType().Name, "GetCaja", ex.Message);

            }
            return result;
        }
    }
}
