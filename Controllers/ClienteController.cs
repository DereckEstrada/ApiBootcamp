using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Practica2.Interfaces;
using Practica2.Models;

namespace Practica2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _cliente;
        public ClienteController(ICliente cliente)
        {
            this._cliente = cliente;
        }

        [HttpGet]
        [Route("GetCliente")]
        public async Task<Respuesta> GetCliente(string? opcion, string? data)
        {
            
            var result=new Respuesta();
            try
            {
                result=await _cliente.GetCliente(opcion, data);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPost]
        [Route("PostCliente")]
        public async Task<Respuesta> PostCliente([FromBody]Cliente cliente)
        {

            var result = new Respuesta();
            try
            {
                result = await _cliente.PostCliente(cliente);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPut]
        [Route("PutCliente")]
        public async Task<Respuesta> PutCliente([FromBody]Cliente cliente)
        {

            var result = new Respuesta();
            try
            {
                result = await _cliente.PutCliente(cliente);
            }
            catch (Exception)
            {

                throw;
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
                result = await _cliente.DeleteCliente(id);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
