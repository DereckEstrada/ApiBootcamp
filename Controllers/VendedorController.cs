using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;

namespace Practica2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VendedorController : ControllerBase
    {
        private readonly IVendedor _vendedor;
        private ControlError log = new ControlError();
        public VendedorController(IVendedor vendedor)
        {
            this._vendedor = vendedor;
        }
        [HttpGet]
        [Route("GetVendedor")]
        public async Task<Respuesta> GetVendedor(string? opcion, string? data)
        {
            var result = new Respuesta();
            try
            {
                result = await _vendedor.GetVendedor(opcion, data);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetVendedor", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostVendedor")]
        public async Task<Respuesta> PostVendedor([FromBody] Vendedor vendedor)
        {
            var result = new Respuesta();
            try
            {
                result = await _vendedor.Post(vendedor);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PostVendedor", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutVendedor")]
        public async Task<Respuesta> PutVendedor([FromBody] Vendedor vendedor)
        {
            var result = new Respuesta();
            try
            {
                result = await _vendedor.Put(vendedor);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PutVendedor", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteVendedor")]
        public async Task<Respuesta> DeleteVendedor(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _vendedor.Delete(id);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "DeleteVendedor", ex.Message);
            }
            return result;
        }
    }
}
