using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Ciudad: Generic
{
    public string? CiudadNombre { get; set; }
    public virtual Estado? Estado { get; set; }
    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
