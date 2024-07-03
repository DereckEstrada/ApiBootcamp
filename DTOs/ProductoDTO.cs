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
    }
}
