using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Practica2.Interfaces;
using Practica2.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Practica2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VentasController : ControllerBase
    {
        private readonly IVentas _ventas;
        public VentasController(IVentas ventas)
        {
            this._ventas = ventas;
        }

        [HttpGet]
        [Route("GetVentas")]
        public async Task<Respuesta> GetVentas(string? opcion, string?data, string?data2)
        {
            var result=new Respuesta();
            try
            {
                result = await _ventas.GetVentas(opcion, data, data2);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
        [HttpPost]
        [Route("PostVentas")]
        public async Task<Respuesta> PostVentas([FromBody]Venta venta)
        {
            var result = new Respuesta();
            try
            {
                result = await _ventas.PostVentas(venta);
            }
            catch (Exception)
            {

                throw;
            }
            return result;
        }
    }
}
