using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Sucursal
{
    public double SucursalId { get; set; }

    public string? SucursalNombre { get; set; }

    public int? EstadoId { get; set; }

    public DateTime? FechaHoraReg { get; set; }

    public double? CiudadId { get; set; }

    public virtual Ciudad? Ciudad { get; set; }

    public virtual Estado? Estado { get; set; }

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
