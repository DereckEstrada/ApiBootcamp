using Microsoft.EntityFrameworkCore;
using Practica2.DTOs;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Practica2.Services
{
    public class CatalogoService : ICatalogo, IRepository<Marca>, IRepository<Modelo>, IRepository<Categorium>, IRepository<Sucursal>
    {
        private VentaspruebaContext _context;
        private ControlError log=new ControlError();
        public CatalogoService(VentaspruebaContext context)
        {
            this._context = context;
        }
        public async Task<Respuesta> DeleteMarca(int id)
        {
            var result=new Respuesta();
            var marcaDelete=new Marca();
            bool validar = false;
            try
            {
                validar = await _context.Marcas.Where((x)=>x.MarcaId == id).AnyAsync();
                if (validar)
                {
                    marcaDelete=await _context.Marcas.Where((x)=>x.MarcaId==id).FirstOrDefaultAsync();
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
                result.mensaje = $"Exception: {ex.Message}";
                log.LogErrorMetodos(this.GetType().Name, "DeleteMarca", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> GetMarca()
        {
            var result=new Respuesta();
            try
            {
                result.cod = "000";
                result.data= await (from m in _context.Marcas
                                    join e in _context.Estados on m.EstadoId equals e.EstadoId
                                    where(m.EstadoId == 1)
                                    select new MarcaDTO
                                    {
                                        MarcaId = m.MarcaId,
                                        MarcaNombre=m.MarcaNombre,
                                        FechaHoraReg=m.FechaHoraReg,
                                        EstadoDescrip=e.EstadoDescripcion
                                    }).ToListAsync();
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
                log.LogErrorMetodos(this.GetType().Name, "GetMarca", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostMarca(Marca marca)
        {
            var result=new Respuesta();
            try
            {
                var query= await _context.Marcas.OrderByDescending((x)=>x.MarcaId).Select((x)=>x.MarcaId).FirstOrDefaultAsync()+1;
                marca.MarcaId = query;
                marca.FechaHoraReg=DateTime.Now;
                _context.Marcas.Add(marca);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje="OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
                log.LogErrorMetodos(this.GetType().Name, "PostMarca", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PutMarca(Marca marca)
        {
            var result= new Respuesta();
            bool validar=false;
            try
            {
                validar= await _context.Marcas.Where((x)=>x.MarcaId==marca.MarcaId).AnyAsync();
                if (validar)
                {
                    result.cod = "000";
                    result.mensaje="OK";
                    _context.Marcas.Update(marca);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje= $"Ninguna marca se encontro con la id: '{marca.MarcaId}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
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
                validar = await _context.Modelos.Where((x) => x.ModeloId== id).AnyAsync();
                if (validar)
                {
                    modeloDelete = await _context.Modelos.Where((x) => x.ModeloId== id).FirstOrDefaultAsync();
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
                result.mensaje = $"Exception: {ex.Message}";
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
                result.data = await (from m in _context.Modelos
                                     join e in _context.Estados on m.EstadoId equals e.EstadoId
                                     where (m.EstadoId == 1)
                                     select new ModeloDTO
                                     {
                                         ModeloId = m.ModeloId,
                                         ModeloDescripcion= m.ModeloDescripción,
                                         FechaHoraReg = m.FechaHoraReg,
                                         EstadoDescrip = e.EstadoDescripcion
                                     }).ToListAsync();
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
                log.LogErrorMetodos(this.GetType().Name, "GetModelo", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostModelo(Modelo modelo)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Modelos.OrderByDescending((x) => x.ModeloId).Select((x) => x.ModeloId).FirstOrDefaultAsync() + 1;
                modelo.ModeloId= query;
                modelo.FechaHoraReg = DateTime.Now;
                _context.Modelos.Add(modelo);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
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
                validar = await _context.Modelos.Where((x) => x.ModeloId== modelo.ModeloId).AnyAsync();
                if (validar)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Modelos.Update(modelo);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ningun modelo se encontro con la id: '{modelo.ModeloId}'";

                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
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
                validar = await _context.Categoria.Where((x) => x.CategId== id).AnyAsync();
                if (validar)
                {
                    categoriaDelete = await _context.Categoria.Where((x) => x.CategId== id).FirstOrDefaultAsync();
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
                result.mensaje = $"Exception: {ex.Message}";
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
                result.data = await (from c in _context.Categoria
                                     join e in _context.Estados on c.EstadoId equals e.EstadoId
                                     where (c.EstadoId == 1)
                                     select new CategoriaDTO
                                     {
                                         CategId= c.CategId,
                                         CategNombre= c.CategNombre,
                                         FechaHoraReg = c.FechaHoraReg,
                                         EstadoDescrip = e.EstadoDescripcion
                                     }).ToListAsync();
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
                log.LogErrorMetodos(this.GetType().Name, "GetCategoria", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostCategoria(Categorium categoria)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Categoria.OrderByDescending((x) => x.CategId).Select((x) => x.CategId).FirstOrDefaultAsync() + 1;
                categoria.CategId= query;
                categoria.FechaHoraReg = DateTime.Now;
                _context.Categoria.Add(categoria);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
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
                validar = await _context.Categoria.Where((x) => x.CategId== categoria.CategId).AnyAsync();
                if (validar)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Categoria.Update(categoria);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna categoria se encontro con la id: '{categoria.CategId}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
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
                validar = await _context.Sucursals.Where((x) => x.SucursalId== id).AnyAsync();
                if (validar)
                {
                    sucursalDelete = await _context.Sucursals.Where((x) => x.SucursalId== id).FirstOrDefaultAsync();
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
                result.mensaje = $"Exception: {ex.Message}";
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
                result.data = await (from s in _context.Sucursals
                                     join c in _context.Ciudads on s.CiudadId equals c.CiudadId
                                     join e in _context.Estados on s.EstadoId equals e.EstadoId
                                     where (s.EstadoId == 1)
                                     select new SucursalDTO
                                     {
                                         SucursalId= s.SucursalId,
                                         SucursalNombre = s.SucursalNombre,
                                         CiudadNombre=c.CiudadNombre,
                                         FechaHoraReg = s.FechaHoraReg,
                                         EstadoDescrip = e.EstadoDescripcion
                                     }).ToListAsync();
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
                log.LogErrorMetodos(this.GetType().Name, "GetSucursal", ex.Message);

            }
            return result;
        }

        public async Task<Respuesta> PostSucursal(Sucursal sucursal)
        {
            var result = new Respuesta();
            try
            {
                var query = await _context.Sucursals.OrderByDescending((x) => x.SucursalId).Select((x) => x.SucursalId).FirstOrDefaultAsync() + 1;
                sucursal.SucursalId= query;
                sucursal.FechaHoraReg = DateTime.Now;
                _context.Sucursals.Add(sucursal);
                await _context.SaveChangesAsync();
                result.cod = "000";
                result.mensaje = "OK";
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
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
                validar = await _context.Sucursals.Where((x) => x.SucursalId== sucursal.SucursalId).AnyAsync();
                if (validar)
                {
                    result.cod = "000";
                    result.mensaje = "OK";
                    _context.Sucursals.Update(sucursal);
                    await _context.SaveChangesAsync();
                }
                else
                {
                    result.cod = "111";
                    result.mensaje = $"Ninguna sucursal se encontro con la id: '{sucursal.SucursalId}'";
                }
            }
            catch (Exception ex)
            {
                result.cod = "999";
                result.mensaje = $"Exception: {ex.Message}";
                log.LogErrorMetodos(this.GetType().Name, "PutSucursal", ex.Message);

            }
            return result;
        }
    }
}
