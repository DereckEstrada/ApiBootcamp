using Microsoft.EntityFrameworkCore;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Practica2.Services
{
    public class CatalogoService : ICatalogo, IAssembly<Marca>, IAssembly<Modelo>, IAssembly<Categorium>, IAssembly<Sucursal>, IAssembly<Ciudad>, IAssembly<Estado>
    {
        private VentaspruebaContext _context;
        private ControlError log = new ControlError();
        public CatalogoService(VentaspruebaContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> DeleteMarca(int id)
        {
            var result = new Respuesta();
            var marcaDelete = new Marca();
            bool validar = false;
            try
            {
                validar = await _context.Marcas.Where((x) => x.Id == id).AnyAsync();
                if (validar)
                {
                    marcaDelete = await _context.Marcas.Where((x) => x.Id == id).FirstOrDefaultAsync();
                    marcaDelete.EstadoId = 2;
                    _context.Marcas.Update(marcaDelete);
                    await _context.SaveChangesAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna marca se encontro con la id: '{id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "DeleteMarca", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> GetMarca()
        {
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                result.data = await (from m in _context.Marcas
                                     join e in _context.Estados on m.EstadoId equals e.Id
                                     where m.EstadoId == 1
                                     select new
                                     {
                                         Id = m.Id,
                                         Nombre = m.MarcaNombre,
                                         EstadoDescrip = e.EstadoDescripcion,
                                         FechaHoraReg = m.FechaHoraReg
                                     }
                                     ).ToListAsync();
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetMarca", ex.Message);
            }
            return result;
        }
        public async Task<Respuesta> PostMarca(Marca marca)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Marcas.OrderByDescending((x) => x.Id).Select((x) => x.Id).FirstOrDefaultAsync() + 1;
                marca.Id = query;
                marca.FechaHoraReg = DateTime.Now;
                _context.Marcas.Add(marca);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PostMarca", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> PutMarca(Marca marca)
        {
            var result = new Respuesta();
            bool validar = false;
            try
            {
                validar = await _context.Marcas.Where((x) => x.Id == marca.Id).AnyAsync();
                if (validar)
                {
                    marca.FechaHoraReg = await _context.Marcas.Where(x => x.Id == marca.Id).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Marcas.Update(marca);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna marca se encontro con la id: '{marca.Id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PutMarca", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> DeleteModelo(int id)
        {
            var result = new Respuesta();
            var modeloDelete = new Modelo();
            bool validar = false;
            try
            {
                validar = await _context.Modelos.Where((x) => x.Id == id).AnyAsync();
                if (validar)
                {
                    modeloDelete = await _context.Modelos.Where((x) => x.Id == id).FirstOrDefaultAsync();
                    modeloDelete.EstadoId = 2;
                    _context.Modelos.Update(modeloDelete);
                    await _context.SaveChangesAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ningun modelo se encontro con la id: '{id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "DeleteModelo", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> GetModelo()
        {
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                result.data = await (from m in _context.Modelos
                                     join e in _context.Estados on m.EstadoId equals e.Id
                                     where m.EstadoId == 1
                                     select new
                                     {
                                         Id = m.Id,
                                         Nombre = m.ModeloDescripción,
                                         EstadoDescrip = e.EstadoDescripcion,
                                         FechaHoraReg = m.FechaHoraReg
                                     }
                                     ).ToListAsync();
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetModelo", ex.Message);
            }
            return result;
        }
        public async Task<Respuesta> PostModelo(Modelo modelo)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Modelos.OrderByDescending((x) => x.Id).Select((x) => x.Id).FirstOrDefaultAsync() + 1;
                modelo.Id = query;
                modelo.FechaHoraReg = DateTime.Now;
                _context.Modelos.Add(modelo);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PostModelo", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> PutModelo(Modelo modelo)
        {
            var result = new Respuesta();
            bool validar = false;
            try
            {
                validar = await _context.Modelos.Where((x) => x.Id == modelo.Id).AnyAsync();
                if (validar)
                {
                    modelo.FechaHoraReg = await _context.Modelos.Where(x => x.Id == modelo.Id).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Modelos.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ningun modelo se encontro con la id: '{modelo.Id}'";

                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PutModelo", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> DeleteCategoria(int id)
        {
            var result = new Respuesta();
            var categoriaDelete = new Categorium();
            bool validar = false;
            try
            {
                validar = await _context.Categoria.Where((x) => x.Id == id).AnyAsync();
                if (validar)
                {
                    categoriaDelete = await _context.Categoria.Where((x) => x.Id == id).FirstOrDefaultAsync();
                    categoriaDelete.EstadoId = 2;
                    _context.Categoria.Update(categoriaDelete);
                    await _context.SaveChangesAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna categoria se encontro con la id: '{id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "DeleteCategoria", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> GetCategoria()
        {
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                result.data = await (from c in _context.Categoria
                                     join e in _context.Estados on c.EstadoId equals e.Id
                                     where c.EstadoId == 1
                                     select new
                                     {
                                         Id = c.Id,
                                         Nombre = c.CategNombre,
                                         EstadoDescrip = e.EstadoDescripcion,
                                         FechaHoraReg = c.FechaHoraReg
                                     }
                               ).ToListAsync();
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetCategoria", ex.Message);
            }
            return result;
        }
        public async Task<Respuesta> PostCategoria(Categorium categoria)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Categoria.OrderByDescending((x) => x.Id).Select((x) => x.Id).FirstOrDefaultAsync() + 1;
                categoria.Id = query;
                categoria.FechaHoraReg = DateTime.Now;
                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PostCategoria", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> PutCategoria(Categorium categoria)
        {
            var result = new Respuesta();
            bool validar = false;
            try
            {
                validar = await _context.Categoria.Where((x) => x.Id == categoria.Id).AnyAsync();
                if (validar)
                {
                    categoria.FechaHoraReg = await _context.Categoria.Where(x => x.Id == categoria.Id).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Categoria.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna categoria se encontro con la id: '{categoria.Id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PutCategoria", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> DeleteSucursal(int id)
        {
            var result = new Respuesta();
            var sucursalDelete = new Sucursal();
            bool validar = false;
            try
            {
                validar = await _context.Sucursals.Where((x) => x.Id == id).AnyAsync();
                if (validar)
                {
                    sucursalDelete = await _context.Sucursals.Where((x) => x.Id == id).FirstOrDefaultAsync();
                    sucursalDelete.EstadoId = 2;
                    _context.Sucursals.Update(sucursalDelete);
                    await _context.SaveChangesAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna sucursal se encontro con la id: '{id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "DeleteSucursal", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> GetSucursal()
        {
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                result.data = await (from s in _context.Sucursals
                                     join e in _context.Estados on s.EstadoId equals e.Id
                                     join c in _context.Ciudads on s.CiudadId equals c.Id
                                     where s.EstadoId == 1
                                     select new
                                     {
                                         Id = s.Id,
                                         Nombre = s.SucursalNombre,
                                         CiudadNombre = c.CiudadNombre,
                                         EstadoDescrip = e.EstadoDescripcion,
                                         FechaHoraReg = c.FechaHoraReg
                                     }
                               ).ToListAsync();
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetSucursal", ex.Message);
            }
            return result;
        }
        public async Task<Respuesta> PostSucursal(Sucursal sucursal)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Sucursals.OrderByDescending((x) => x.Id).Select((x) => x.Id).FirstOrDefaultAsync() + 1;
                sucursal.Id = query;
                sucursal.FechaHoraReg = DateTime.Now;
                _context.Sucursals.Add(sucursal);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PostSucursal", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> PutSucursal(Sucursal sucursal)
        {
            var result = new Respuesta();
            bool validar = false;

            try
            {
                validar = await _context.Sucursals.Where((x) => x.Id == sucursal.Id).AnyAsync();
                if (validar)
                {
                    sucursal.FechaHoraReg = await _context.Sucursals.Where(x => x.Id == sucursal.Id).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Sucursals.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna sucursal se encontro con la id: '{sucursal.Id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PutSucursal", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> GetCiudad()
        {
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.mensaje = "OK";
                result.data = await (from c in _context.Ciudads
                                     join e in _context.Estados on c.EstadoId equals e.Id
                                     where c.EstadoId == 1
                                     select new
                                     {
                                         Id = c.Id,
                                         Nombre = c.CiudadNombre,
                                         EstadoDescrip = e.EstadoDescripcion,
                                         FechaHoraReg = c.FechaHoraReg
                                     }
               ).ToListAsync();
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetCiudad", ex.Message);
            }
            return result;
        }
        public async Task<Respuesta> PostCiudad(Ciudad ciudad)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Ciudads.OrderByDescending((x) => x.Id).Select((x) => x.Id).FirstOrDefaultAsync() + 1;
                ciudad.Id = query;
                ciudad.FechaHoraReg = DateTime.Now;
                _context.Ciudads.Add(ciudad);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PostCiudad", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> PutCiudad(Ciudad ciudad)
        {
            var result = new Respuesta();
            bool validar = false;

            try
            {
                validar = await _context.Ciudads.Where((x) => x.Id == ciudad.Id).AnyAsync();
                if (validar)
                {
                    ciudad.FechaHoraReg = await _context.Ciudads.Where(x => x.Id == ciudad.Id).Select(x => x.FechaHoraReg).FirstOrDefaultAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Ciudads.Update(ciudad);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna ciudad se encontro con la id: '{ciudad.Id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PutCiudad", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> DeleteCiudad(int id)
        {
            var result = new Respuesta();
            var ciudadDelete = new Ciudad();
            bool validar = false;
            try
            {
                validar = await _context.Ciudads.Where((x) => x.Id == id).AnyAsync();
                if (validar)
                {
                    ciudadDelete = await _context.Ciudads.Where((x) => x.Id == id).FirstOrDefaultAsync();
                    ciudadDelete.EstadoId = 2;
                    _context.Ciudads.Update(ciudadDelete);
                    await _context.SaveChangesAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna ciudad se encontro con la id: '{id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "DeleteCiudad", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> GetEstado()
        {
            var result = new Respuesta();
            try
            {
                result.cod = "000";
                result.data = await (from e in _context.Estados
                                     select new
                                     {
                                         Id = e.Id,
                                         EstadoDescrip = e.EstadoDescripcion
                                     }).ToListAsync();
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "GetEstado", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> PostEstado(Estado estado)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Estados.OrderByDescending((x) => x.Id).Select((x) => x.Id).FirstOrDefaultAsync() + 1;
                estado.Id = query;
                _context.Estados.Add(estado);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PostEstado", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> PutEstado(Estado estado)
        {
            var result = new Respuesta();
            bool validar = false;

            try
            {
                validar = await _context.Estados.Where((x) => x.Id == estado.Id).AnyAsync();
                if (validar)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Estados.Update(estado);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna estado se encontro con la id: '{estado.Id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "PutEstado", ex.Message);

            }
            return result;
        }
        public async Task<Respuesta> DeleteEstado(int id)
        {
            var result = new Respuesta();
            var estadoDelete = new Estado();
            bool validar = false;
            try
            {
                validar = await _context.Estados.Where((x) => x.Id == id).AnyAsync();
                if (validar)
                {
                    estadoDelete = await _context.Estados.Where((x) => x.Id == id).FirstOrDefaultAsync();
                    _context.Estados.Remove(estadoDelete);
                    await _context.SaveChangesAsync();
                    result.cod = "000";
                    result.mensaje = "OK";
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna estado se encontro con la id: '{id}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Se ha encontrado un error, por favor comuniquese con el area de sistemas";
                log.LogErrorMetodos(this.GetType().Name, "DeleteEstado", ex.Message);

            }
            return result;
        }
    }
}

