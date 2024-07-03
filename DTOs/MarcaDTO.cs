using Practica2.Models;

namespace Practica2.DTOs
{
    public class MarcaDTO
    {
        public double MarcaId { get; set; }

        public string? MarcaNombre { get; set; }

        public string? EstadoDescrip { get; set; }

        public DateTime? FechaHoraReg { get; set; }
    }
}
