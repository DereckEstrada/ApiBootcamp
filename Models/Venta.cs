using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Venta
{
    public double IdFactura { get; set; }
    public string? NumFact { get; set; }
    public DateTime? FechaHora { get; set; }
    public int? ClienteId { get; set; }
    public int? ProductoId { get; set; }
    public int? ModeloId { get; set; }
    public int? CategId { get; set; }
    public int? MarcaId { get; set; }
    public int? SucursalId { get; set; }
    public int? CajaId { get; set; }
    public int? VendedorId { get; set; }
    public double? Precio { get; set; }
    public int? Unidades { get; set; }
    public int? EstadoId { get; set; }
    public virtual Caja? Caja { get; set; }
    public virtual Categorium? Categ { get; set; }
    public virtual Cliente? Cliente { get; set; }
    public virtual Estado? Estado { get; set; }
    public virtual Marca? Marca { get; set; }
    public virtual Modelo? Modelo { get; set; }
    public virtual Producto? Producto { get; set; }
    public virtual Sucursal? Sucursal { get; set; }
    public virtual Vendedor? Vendedor { get; set; }
}
