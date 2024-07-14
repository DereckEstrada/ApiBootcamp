﻿using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Modelo: Generic
{
    public string? ModeloDescripción { get; set; }
    public virtual Estado? Estado { get; set; }
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
