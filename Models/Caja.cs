using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Caja: Generic
{
    public string? CajaDescripcion { get; set; }
    public virtual Estado? Estado { get; set; } = null!;
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
