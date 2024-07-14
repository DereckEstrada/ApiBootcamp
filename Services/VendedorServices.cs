using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Practica2.Services
{
    public class VendedorServices : GenericServices<Vendedor>, IVendedor
    {
        private ControlError log = new ControlError();
        private DynamicEmpty dynamicEmpty = new DynamicEmpty();
        public VendedorServices(VentaspruebaContext context) : base(context)
        {
        }
        public async Task<Respuesta> GetVendedor(string? opcion, string? data)
        {
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                Expression<Func<VendedorDTO, bool>> nulls = VendedorDTO.DictionaryVendedor(opcion, data);
                if (nulls != null)
                {
                    result.data = await (from v in _context.Vendedors
                                         join e in _context.Estados on v.EstadoId equals e.Id
                                         select new VendedorDTO
                                         {
                                             VendedorId = v.Id,
                                             VendedorDescripcion = v.VendedorDescripcion,
                                             FechaHoraReg = v.FechaHoraReg,
                                             EstadoId = v.EstadoId,
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
                log.LogErrorMetodos(this.GetType().Name, "GetVendedor", ex.Message);

            }
            return result;
        }
    }
}
