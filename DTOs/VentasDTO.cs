using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Practica2.DTOs
{
    public class VentasDTO
    {
        public double IdFactura { get; set; }
        public string? NumFact { get; set; }
        public DateTime? FechaHora { get; set; }
        public double? ClienteId { get; set; }
        public string? ClienteDetalle { get; set; }
        public double? ClienteCedulaDetalle { get; set; }
        public double? ProductoId { get; set; }
        public string? ProductoDetalle { get; set; }
        public double? ModeloId { get; set; }
        public string? ModeloDetalle { get; set; }
        public double? CategId { get; set; }
        public string? CategDetalle { get; set; }
        public double? MarcaId { get; set; }
        public string? MarcaDetalle { get; set; }
        public double? SucursalId { get; set; }
        public string? SucursalDetalle { get; set; }
        public int? CajaId { get; set; }
        public string? CajaDetalle { get; set; }
        public int? VendedorId { get; set; }
        public string? VendedorDetalle { get; set; }
        public double? Precio { get; set; }
        public double? Unidades { get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoDetalle { get; set; }
        //Devuelve las sentencias where para el LinQ de su clase 
        public static Expression<Func<VentasDTO, bool>> DictionaryVentas(string? opcion, string? data, string? data2)
        {

            bool validarOpcion = opcion.IsNullOrEmpty();
            bool validarData1 = data.IsNullOrEmpty();
            bool validarData2 = data2.IsNullOrEmpty();
            int.TryParse(data, out int in1);
            int.TryParse(data2, out int in2);
            double.TryParse(data, out double double1);
            double.TryParse(data2, out double double2);
            DateTime.TryParse(data, out DateTime date1);
            DateTime.TryParse(data2, out DateTime date2);
            Expression<Func<VentasDTO, bool>> query;
            if (validarOpcion && validarData1 && validarData2)
            {
                query = x => x.EstadoId == 3;
            }
            else
            {
                if (validarData2)
                {
                    Dictionary<string, Expression<Func<VentasDTO, bool>>> QueryVentas = new Dictionary<string, Expression<Func<VentasDTO, bool>>>();
                    QueryVentas.Add("idfactura", (x) => x.IdFactura == in1 && x.EstadoId == 3);
                    QueryVentas.Add("numfactura", (x) => x.NumFact.Equals(data) && x.EstadoId == 3);
                    QueryVentas.Add("precio", (x) => x.Precio == double1 && x.EstadoId == 3);
                    QueryVentas.Add("estado", (x) => x.EstadoId == in1);
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
                    query = !validarOpcion ? QueryVentas.ContainsKey(opcion.ToLower()) && !validarData1 ? QueryVentas[opcion.ToLower()] : null : null;
                }
                else
                {
                    Dictionary<string, Expression<Func<VentasDTO, bool>>> QueryVentasDoble = new Dictionary<string, Expression<Func<VentasDTO, bool>>>();
                    QueryVentasDoble.Add("precio", (x) => double1 <= x.Precio && x.Precio <= double2 && x.EstadoId == 3);
                    QueryVentasDoble.Add("unidades", (x) => in1 <= x.Unidades && x.Unidades <= in2 && x.EstadoId == 3);
                    QueryVentasDoble.Add("fecha", (x) => date1 <= x.FechaHora && x.FechaHora <= date2 && x.EstadoId == 3);
                    query = !validarOpcion ? QueryVentasDoble.ContainsKey(opcion.ToLower()) && !validarData1 && !validarData2 ? QueryVentasDoble[opcion.ToLower()] : null : null;

                }
            }


            return query;

        }
    }
}
