using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Producto
{
    public double ProductoId { get; set; }

    public string? ProductoDescrip { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public double? Precio { get; set; }

    public double? CategId { get; set; }

    public double? MarcaId { get; set; }

    public double? ModeloId { get; set; }

    public virtual Categorium? Categ { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual Marca? Marca { get; set; }

    public virtual Modelo? Modelo { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
