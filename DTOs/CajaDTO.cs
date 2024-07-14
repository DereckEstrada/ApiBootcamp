using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;
using System.Net.Quic;

namespace Practica2.DTOs
{
    public class CajaDTO
    {
        public int CajaId { get; set; }
        public string? CajaDescripcion { get; set; }
        public int EstadoId { get; set; }
        public string? EstadoDescrip { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        //Devuelve las sentencias where para el LinQ de su clase 
        public static Expression<Func<CajaDTO, bool>> DictionaryCaja(string? opcion, string? data)
        {
            Dictionary<string, Expression<Func<CajaDTO, bool>>> QueryCaja = new Dictionary<string, Expression<Func<CajaDTO, bool>>>();
            int.TryParse(data, out int in1);
            double.TryParse(data, out double double1);
            bool validarOpcion = opcion.IsNullOrEmpty();
            bool validarData = data.IsNullOrEmpty();
            Expression<Func<CajaDTO, bool>> query;
            if (validarData && validarOpcion)
            {
                query = x => x.EstadoId == 1;
            }
            else
            {
                QueryCaja.Add("id", (x) => x.CajaId == in1 && x.EstadoId == 1);
                QueryCaja.Add("descripcion", (x) => x.CajaDescripcion.ToLower().Equals(data.ToLower()) && x.EstadoId == 1);
                query = !validarOpcion ? QueryCaja.ContainsKey(opcion.ToLower()) && !validarData ? QueryCaja[opcion.ToLower()] : null : null;

            }
            return query;
        }
    }
}
