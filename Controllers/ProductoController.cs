using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Practica2.Interfaces;
using Practica2.Models;
using Practica2.Utilitarios;

namespace Practica2.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IProducto _producto;
        private ControlError log=new ControlError();
        public ProductoController(IProducto producto)
        {
            this._producto = producto;
        }
        [HttpGet]
        [Route("GetProductos")]
        public async Task<Respuesta> GetProductos(string? opcion, string? data, string? data2)
        {
            var result=new Respuesta();
            try
            {
                result= await _producto.GetProductos(opcion, data, data2);
            }
            catch (Exception ex)
            {
                log.LogErrorMetodos(this.GetType().Name, "GetProductos", ex.Message);

            }
            return result;
        }
        [HttpPost]
        [Route("PostProducto")]
        public async Task<Respuesta> PostProducto([FromBody] Producto producto)
        {
            var result=new Respuesta();
            try
            {
                result= await _producto.PostProducto(producto);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos(this.GetType().Name, "PostProducto", ex.Message);
            }
            return result ;
        }
        [HttpPut]
        [Route("PutProducto")]
        public async Task<Respuesta> PuttProducto([FromBody] Producto producto)
        {
            var result = new Respuesta();
            try
            {
                result=await _producto.PutProducto(producto);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos(this.GetType().Name, "PutProducto", ex.Message);
            }
            return result;
        }
        [HttpPut]
        [Route("DeleteProducto")]
        public async Task<Respuesta> DeleteProducto(int id)
        {
            var result = new Respuesta();
            try
            {
                result=await _producto.DeleteProducto(id);
            }
            catch (Exception ex)
            {

                log.LogErrorMetodos(this.GetType().Name, "DeleteProducto", ex.Message);
            }
            return result;
        }
    }
}
