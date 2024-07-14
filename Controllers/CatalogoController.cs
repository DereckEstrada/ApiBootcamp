using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;

namespace Practica2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        private readonly ICatalogo _catalogo;
        private ControlError log = new ControlError();
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetMarca", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PosttMarca", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PutMarca", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "DeleteMarca", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetModelo", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PostModelo", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutModelo")]
        public async Task<Respuesta> PutModelo([FromBody] Modelo modelo)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PutModelo(modelo);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PutModelo", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "DeleteModelo", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetCategoria", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PostCategoria", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PutCategoria", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "DeleteCategoria", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetSucursal", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PostSucursal", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PutSucursal", ex.Message);
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
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "DeleteSucursal", ex.Message);
            }
            return result;
        }
        [HttpGet]
        [Route("GetCiudad")]
        public async Task<Respuesta> GetCiudad()
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.GetCiudad();
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetCiudad", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostCiudad")]
        public async Task<Respuesta> PostCiudad([FromBody] Ciudad ciudad)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PostCiudad(ciudad);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PostCiudad", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutCiudad")]
        public async Task<Respuesta> PutCiudad([FromBody] Ciudad ciudad)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PutCiudad(ciudad);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PutCiudad", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteCiudad")]
        public async Task<Respuesta> DeleteCiudad(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.DeleteCiudad(id);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "DeleteCiudad", ex.Message);
            }
            return result;
        }
        [HttpGet]
        [Route("GetEstado")]
        public async Task<Respuesta> GetEstado()
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.GetEstado();
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetEstado", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostEstado")]
        public async Task<Respuesta> PostEstado([FromBody] Estado estado)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PostEstado(estado);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PostEstado", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutEstado")]
        public async Task<Respuesta> PutEstado([FromBody] Estado estado)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.PutEstado(estado);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PutEstado", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteEstado")]
        public async Task<Respuesta> DeleteEstado(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _catalogo.DeleteEstado(id);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "DeleteEstado", ex.Message);
            }
            return result;
        }
    }
}
