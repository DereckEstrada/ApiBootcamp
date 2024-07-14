using Microsoft.EntityFrameworkCore;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;
using System.Linq.Dynamic.Core;



namespace Practica2.Services
{
    //Creacion de metodos genericos lo cuales solo permiten las clases heredadas de Generic
    public class GenericServices<T> : IGeneric<T>, IAssembly<T> where T : Generic
    {
        protected VentaspruebaContext _context;
        private ControlError log = new ControlError();
        public GenericServices(VentaspruebaContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> Delete(int id)
        {
            var result = new Respuesta();
            try
            {
                var delete = _context.Set<T>().FirstOrDefault(x => x.Id == id);
                result.cod = "111";
                result.mensaje = $" No se encontro registro con id: '{id}'";
                if (delete != null)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    delete.EstadoId = 2;
                    _context.Set<T>().Update(delete);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "Delete", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> Post(T value)
        {
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                var query = await _context.Set<T>().OrderByDescending(x => x.Id).Select(x => x.Id).FirstOrDefaultAsync() + 1;
                value.Id = query;
                value.FechaHoraReg = DateTime.Now;
                await _context.Set<T>().AddAsync(value);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "Post", ex.Message);
            }
            return result;
        }
        public async Task<Respuesta> Put(T value)
        {
            var result = new Respuesta();
            try
            {
                bool validar = await _context.Set<T>().AnyAsync(x => x.Id == value.Id);
                result.cod = "111";
                result.mensaje = $"No se encontro registro con id: '{value.Id}'";
                if (validar)
                {
                    value.FechaHoraReg = await _context.Set<T>().Where(x => x.Id == value.Id).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Set<T>().Update(value);
                    await _context.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "Put", ex.Message);
            }
            return result;

        }
    }
}
