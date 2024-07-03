using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Categorium
{
    public double CategId { get; set; }

    public string? CategNombre { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
