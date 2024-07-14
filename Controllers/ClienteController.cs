using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;

namespace Practica2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;
        private ControlError log = new ControlError();
        public ClienteController(ICliente cliente)
        {
            this._cliente = cliente;
        }
        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(string? opcion, string? data)
        {
            var result = new Respuesta();
            try
            {
                result = await _cliente.GetCliente(opcion, data);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetCliente", ex.Message);
            }
            return result;
        }
        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody] Cliente cliente)
        {
            var result = new Respuesta();
            try
            {
                result = await _cliente.Post(cliente);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PostCliente", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("PutCliente")]
        public async Task<Respuesta> PutCliente([FromBody] Cliente cliente)
        {
            var result = new Respuesta();
            try
            {
                result = await _cliente.Put(cliente);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "PutCliente", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteCliente")]
        public async Task<Respuesta> DeleteCliente(int id)
        {
            var result = new Respuesta();
            try
            {
                result = await _cliente.Delete(id);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "DeleteCliente", ex.Message);
            }
            return result;
        }
    }
}
