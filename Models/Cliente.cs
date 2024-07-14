using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Cliente : Generic
{
    public string? ClienteNombre { get; set; }
    public double? Cedula { get; set; }
    public virtual Estado? Estado { get; set; }
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
