using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Sucursal: Generic
{
    public string? SucursalNombre { get; set; }
    public int? CiudadId { get; set; }
    public virtual Ciudad? Ciudad { get; set; }
    public virtual Estado? Estado { get; set; }
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
