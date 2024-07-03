using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Ciudad
{
    public double CiudadId { get; set; }

    public string? CiudadNombre { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
}
