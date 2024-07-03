namespace Practica2.DTOs
{
    public class VentasDTO
    {
        public double IdFactura { get; set; }
        public string? NumFact { get; set; }
        public DateTime? FechaHora { get; set; }
        public double? ClienteId { get; set; }
        public string? ClienteDetalle { get; set; }
        public double? ClienteCedulaDetalle {  get; set; }
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
        public int? CajaId {  get; set; }
        public string? CajaDetalle { get; set; }
        public int? VendedorId { get; set; }
        public string? VendedorDetalle { get; set; }
        public double? Precio { get; set; }
        public double? Unidades { get; set; }
        public int? EstadoId { get; set; }
        public string? EstadoDetalle { get; set; }

    }
}
