using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Practica2.DTOs
{
    public class ClienteDTO
    {
        public double ClienteId { get; set; }
        public string? ClienteNombre { get; set; }
        public double? Cedula { get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoDescrip { get; set; }
        public DateTime? FechaHoraReg { get; set; }
        //Devuelve las sentencias where para el LinQ de su clase 
        public static Expression<Func<ClienteDTO, bool>> DictionaryCliente(string? opcion, string? data)
        {
            Expression<Func<ClienteDTO, bool>> query;
            var validarData = data.IsNullOrEmpty();
            var validarOpcion = opcion.IsNullOrEmpty();
            int.TryParse(data, out int in1);
            var QueryCliente = new Dictionary<string, Expression<Func<ClienteDTO, bool>>>();
            if (validarData && validarOpcion)
            {
                query = x => x.EstadoId == 1;
            }
            else
            {
                QueryCliente.Add("id", (x) => x.ClienteId == in1 && x.EstadoId == 1);
                QueryCliente.Add("nombre", (x) => x.ClienteNombre.ToLower().Contains(data.ToLower()) && x.EstadoId == 1);
                QueryCliente.Add("cedula", (x) => x.Cedula == in1 && x.EstadoId == 1);
                query = !validarOpcion?QueryCliente.ContainsKey(opcion.ToLower()) && !validarData ? QueryCliente[opcion.ToLower()] : null:null;
            }
            return  query;
        }
    }
}
