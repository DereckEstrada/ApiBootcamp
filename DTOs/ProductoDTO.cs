using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Practica2.DTOs
{
    public class ProductoDTO
    {
        public double ProductoId { get; set; }
        public string? ProductoDescrip { get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoDescrip { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        public double? Precio { get; set; }
        public double? CategId { get; set; }
        public string? CategNombre { get; set; }
        public double? MarcaId { get; set; }
        public string? MarcaNombre { get; set; }
        public double? ModeloId { get; set; }  
        public string? ModeloNombre { get; set; }
        //Devuelve las sentencias where para el LinQ de su clase 
        public static Expression<Func<ProductoDTO, bool>> DictionaryProducto(string opcion, string data, string data2)
        {
            int.TryParse(data, out int in1);
            double.TryParse(data, out double double1);
            double.TryParse(data2, out double double2);
            var validarOpcion = opcion.IsNullOrEmpty();
            var validarData1 = data.IsNullOrEmpty();
            var validarData2 = data2.IsNullOrEmpty();
            var QueryProductoDoble = new Dictionary<string, Expression<Func<ProductoDTO, bool>>>();
            var QueryProducto = new Dictionary<string, Expression<Func<ProductoDTO, bool>>>();
            Expression<Func<ProductoDTO, bool>> query;
            if (validarOpcion)
            {
                query = x => x.EstadoId == 1;
            }
            else
            {
                if (validarData2)
                {
                    QueryProducto.Add("descripcion", (x) => x.ProductoDescrip.ToLower().Equals(data.ToLower()) && x.EstadoId == 1);
                    QueryProducto.Add("id", (x) => x.ProductoId == in1 && x.EstadoId == 1);
                    QueryProducto.Add("marca", (x) => x.MarcaId == in1 && x.EstadoId == 1);
                    QueryProducto.Add("modelo", (x) => x.ModeloId == in1 && x.EstadoId == 1);
                    QueryProducto.Add("precio", (x) => x.Precio == double1 && x.EstadoId == 1);
                    query = !validarOpcion ? QueryProducto.ContainsKey(opcion.ToLower()) && !validarData1 ? QueryProducto[opcion.ToLower()] : null : null;

                }
                else
                {
                    QueryProductoDoble.Add("precio", (x) => double1 <= x.Precio && x.Precio <= double2 && x.EstadoId == 1);
                    query = !validarOpcion ? QueryProductoDoble.ContainsKey(opcion.ToLower()) && !validarData1 && !validarData2 ? QueryProductoDoble[opcion.ToLower()] : null : null;

                }
            }
                return query;
        }
    }
}
