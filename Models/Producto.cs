using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Producto : Generic
{
    public string? ProductoDescrip { get; set; }
    public double? Precio { get; set; }
    public int? CategId { get; set; }
    public int? MarcaId { get; set; }
    public int? ModeloId { get; set; }
    public virtual Categorium? Categ { get; set; }
    public virtual Estado? Estado { get; set; }
    public virtual Marca? Marca { get; set; }
    public virtual Modelo? Modelo { get; set; }
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
