﻿using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Caja
{
    public int CajaId { get; set; }

    public string? CajaDescripcion { get; set; }

    public int EstadoId { get; set; }

    public virtual Estado Estado { get; set; } = null!;

    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
