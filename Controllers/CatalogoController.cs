using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Practica2.Interfaces;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogo _catalogo;
        public CatalogoController(ICatalogo catalogo)
        {
            this._catalogo = catalogo;
        }
        [HttpGet]
        [Route("GetMarca")]
        public async Task<Respuesta> GetMarca()
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.GetMarca();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPost]
        [Route("PostMarca")]
        public async Task<Respuesta> PostMarca([FromBody] Marca marca)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PostMarca(marca);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("PutMarca")]
        public async Task<Respuesta> PutMarca([FromBody] Marca marca)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PutMarca(marca);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteMarca")]
        public async Task<Respuesta> DeleteMarca(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.DeleteMarca(id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpGet]
        [Route("GetModelo")]
        public async Task<Respuesta> GetModelo()
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.GetModelo();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPost]
        [Route("PostModelo")]
        public async Task<Respuesta> PostModelo([FromBody] Modelo modelo)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PostModelo(modelo);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("PutModelo")]
        public async Task<Respuesta> PutModelo([FromBody]Modelo modelo)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PutModelo(modelo);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteModelo")]
        public async Task<Respuesta> DeleteModelo(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.DeleteModelo(id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpGet]
        [Route("GetCategoria")]
        public async Task<Respuesta> GetCategoria()
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.GetCategoria();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPost]
        [Route("PostCategoria")]
        public async Task<Respuesta> PostCategoria([FromBody] Categorium categoria)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PostCategoria(categoria);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("PutCategoria")]
        public async Task<Respuesta> PutCategoria([FromBody] Categorium categoria)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PutCategoria(categoria);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteCategoria")]
        public async Task<Respuesta> DeleteCategoria(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.DeleteCategoria(id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpGet]
        [Route("GetSucursal")]
        public async Task<Respuesta> GetSucursal()
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.GetSucursal();
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPost]
        [Route("PostSucursal")]
        public async Task<Respuesta> PostSucursal([FromBody] Sucursal sucursal)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PostSucursal(sucursal);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("PutSucursal")]
        public async Task<Respuesta> PutSucursal([FromBody] Sucursal sucursal)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PutSucursal(sucursal);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteSucursal")]
        public async Task<Respuesta> DeleteSucursal(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.DeleteSucursal(id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
