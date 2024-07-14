using Microsoft.IdentityModel.Tokens;
using System.Linq.Expressions;

namespace Practica2.DTOs
{
    public class VendedorDTO
    {
        public int VendedorId { get; set; }
        public string? VendedorDescripcion { get; set; }
        public int EstadoId { get; set; }
        public string ?EstadoDescrip{ get; set; }
        public DateTime? FechaHoraReg { get; set; }
        //Devuelve las sentencias where para el LinQ de su clase 
        public static Expression<Func<VendedorDTO, bool>> DictionaryVendedor(string? opcion, string? data)
        {
            Dictionary<string, Expression<Func<VendedorDTO, bool>>> QueryVendedor = new Dictionary<string, Expression<Func<VendedorDTO, bool>>>();
            int.TryParse(data, out int in1);
            double.TryParse(data, out double double1);
            bool validarOpcion = opcion.IsNullOrEmpty();
            bool validarData = data.IsNullOrEmpty();
            Expression<Func<VendedorDTO, bool>> query;
            if(validarOpcion && validarData)
            {
                query = x => x.EstadoId == 1;
            }
            else
            {
                QueryVendedor.Add("id", (x) => x.VendedorId == in1 && x.EstadoId == 1);
                QueryVendedor.Add("descripcion", (x) => x.VendedorDescripcion.ToLower().Equals(data.ToLower()) && x.EstadoId == 1);
                query= !validarOpcion ? QueryVendedor.ContainsKey(opcion.ToLower()) && !validarData ? QueryVendedor[opcion.ToLower()] : null : null;
            }

            return query;
        }

    }
}
