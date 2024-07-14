using System;
using System.Collections.Generic;

namespace Practica2.Models;

public partial class Estado
{
    public int Id { get; set; }
    public string? EstadoDescripcion { get; set; }
    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();
    public virtual ICollection<Categorium> Categoria { get; set; } = new List<Categorium>();
    public virtual ICollection<Ciudad> Ciudads { get; set; } = new List<Ciudad>();
    public virtual ICollection<Cliente> Clientes { get; set; } = new List<Cliente>();
    public virtual ICollection<Marca> Marcas { get; set; } = new List<Marca>();
    public virtual ICollection<Modelo> Modelos { get; set; } = new List<Modelo>();
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
    public virtual ICollection<Sucursal> Sucursals { get; set; } = new List<Sucursal>();
    public virtual ICollection<Vendedor> Vendedors { get; set; } = new List<Vendedor>();
    public virtual ICollection<Venta> Venta { get; set; } = new List<Venta>();
}
