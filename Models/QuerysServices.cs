using Microsoft.IdentityModel.Tokens;
using Practica2.DTOs;
using Practica2.Interfaces;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Practica2.Models
{
    public class QuerysServices : IRepository<QuerysServices>
    {

        public static Expression<Func<VentasDTO, bool>> DictionaryVentas(string opcion, string data)
        {
            Dictionary<string, Expression<Func<VentasDTO, bool>>> QueryVentas = new Dictionary<string, Expression<Func<VentasDTO, bool>>>();
            bool validar = data.IsNullOrEmpty();
            int.TryParse(data, out int in1);
            double.TryParse(data, out double double1);
            DateTime.TryParse(data, out DateTime date1);
            QueryVentas.Add("idfactura", (x) => x.IdFactura == in1 && x.EstadoId == 3);
            QueryVentas.Add("numfactura", (x) => x.NumFact.Equals(data) && x.EstadoId == 3);
            QueryVentas.Add("precio", (x) => x.Precio == double1 && x.EstadoId == 3);
            QueryVentas.Add("estado", (x) => x.EstadoId == in1 && x.EstadoId == 3);
            QueryVentas.Add("vendedor", (x) => x.VendedorId == in1 && x.EstadoId == 3);
            QueryVentas.Add("clienteid", (x) => x.ClienteId == in1 && x.EstadoId == 3);
            QueryVentas.Add("producto", (x) => x.ProductoId == in1 && x.EstadoId == 3);
            QueryVentas.Add("categoria", (x) => x.CategId == in1 && x.EstadoId == 3);
            QueryVentas.Add("caja", (x) => x.CajaId == in1 && x.EstadoId == 3);
            QueryVentas.Add("marca", (x) => x.MarcaId == in1 && x.EstadoId == 3);
            QueryVentas.Add("unidades", (x) => x.Unidades == in1 && x.EstadoId == 3);
            QueryVentas.Add("sucursal", (x) => x.SucursalId == in1 && x.EstadoId == 3);
            QueryVentas.Add("modelo", (x) => x.ModeloId == in1 && x.EstadoId == 3);
            QueryVentas.Add("fecha", (x) => x.FechaHora == date1 && x.EstadoId == 3);
            QueryVentas.Add("clientecedula", (x) => x.ClienteCedulaDetalle == double1);
            return QueryVentas.ContainsKey(opcion.ToLower()) && !validar ? QueryVentas[opcion.ToLower()] : null;
        }
        public static Expression<Func<VentasDTO, bool>> DictionaryVentasDoble(string opcion, string data, string data2)
        {
            Dictionary<string, Expression<Func<VentasDTO, bool>>> QueryVentasDoble = new Dictionary<string, Expression<Func<VentasDTO, bool>>>();
            int.TryParse(data, out int in1);
            int.TryParse(data2, out int in2);
            double.TryParse(data, out double double1);
            double.TryParse(data2, out double double2);
            DateTime.TryParse(data, out DateTime date1);
            DateTime.TryParse(data2, out DateTime date2);
            QueryVentasDoble.Add("precio", (x) => double1 <= x.Precio && x.Precio <= double2 && x.EstadoId == 3);
            QueryVentasDoble.Add("unidades", (x) => in1 <= x.Unidades && x.Unidades <= in2 && x.EstadoId == 3);
            QueryVentasDoble.Add("fecha", (x) => date1 <= x.FechaHora && x.FechaHora <= date2 && x.EstadoId == 3);
            return QueryVentasDoble.ContainsKey(opcion.ToLower()) ? QueryVentasDoble[opcion.ToLower()] : null;
        }
        public static Expression<Func<ProductoDTO, bool>> DictionaryProducto(string opcion, string data)
        {
            int.TryParse(data, out int in1);
            double.TryParse(data, out double double1);
            var validar = data.IsNullOrEmpty();
            var QueryProducto = new Dictionary<string, Expression<Func<ProductoDTO, bool>>>();
            QueryProducto.Add("descripcion", (x) => x.ProductoDescrip.ToLower().Equals(data.ToLower()) && x.EstadoId == 1);
            QueryProducto.Add("id", (x) => x.ProductoId == in1 && x.EstadoId == 1);
            QueryProducto.Add("marca", (x) => x.MarcaId == in1 && x.EstadoId == 1);
            QueryProducto.Add("modelo", (x) => x.ModeloId == in1 && x.EstadoId == 1);
            QueryProducto.Add("precio", (x) => x.Precio == double1 && x.EstadoId == 1);
            return QueryProducto.ContainsKey(opcion.ToLower()) && !validar ? QueryProducto[opcion.ToLower()] : null;

        }
        public static Expression<Func<ProductoDTO, bool>> DictionaryProductoDoble(string opcion, string data, string data2)
        {
            int.TryParse(data, out int in1);
            double.TryParse(data, out double double1);
            double.TryParse(data2, out double double2);
            var QueryProductoDoble = new Dictionary<string, Expression<Func<ProductoDTO, bool>>>();
            QueryProductoDoble.Add("precio", (x) => double1 <= x.Precio && x.Precio <= double2 && x.EstadoId == 1);
            return QueryProductoDoble.ContainsKey(opcion.ToLower()) ? QueryProductoDoble[opcion.ToLower()] : null;
        }
        public static Expression<Func<ClienteDTO, bool>> DictionaryCliente(string opcion, string data)
        {
            var validar = data.IsNullOrEmpty();
            int.TryParse(data, out int in1);
            var QueryCliente = new Dictionary<string, Expression<Func<ClienteDTO, bool>>>();
            QueryCliente.Add("id", (x) => x.ClienteId == in1 && x.EstadoId == 1);
            QueryCliente.Add("nombre", (x) => x.ClienteNombre.ToLower().Contains(data.ToLower()) && x.EstadoId == 1);
            QueryCliente.Add("cedula", (x) => x.Cedula == in1 && x.EstadoId == 1);


            return QueryCliente.ContainsKey(opcion.ToLower()) && !validar ? QueryCliente[opcion.ToLower()] : null;

        }


    }
}
