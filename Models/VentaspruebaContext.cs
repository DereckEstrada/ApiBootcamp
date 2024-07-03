using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Practica2.Models;

public partial class VentaspruebaContext : DbContext
{
    public VentaspruebaContext()
    {
    }

    public VentaspruebaContext(DbContextOptions<VentaspruebaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<Vendedor> Vendedors { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.CajaId).HasName("PK_CAJA_ID");

            entity.ToTable("CAJA");

            entity.Property(e => e.CajaId).HasColumnName("CAJA_ID");
            entity.Property(e => e.CajaDescripcion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("CAJA_DESCRIPCION");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");

            entity.HasOne(d => d.Estado).WithMany(p => p.Cajas)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CAJA_ESTADO");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategId).HasName("PK_CATEG_ID");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.CategId).HasColumnName("CATEG_ID");
            entity.Property(e => e.CategNombre)
                .HasMaxLength(255)
                .HasColumnName("CATEG_NOMBRE");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");

            entity.HasOne(d => d.Estado).WithMany(p => p.Categoria)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_CATEGORIA_ESTADO");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.HasKey(e => e.CiudadId).HasName("PK_CIUDAD_ID");

            entity.ToTable("CIUDAD");

            entity.Property(e => e.CiudadId).HasColumnName("CIUDAD_ID");
            entity.Property(e => e.CiudadNombre)
                .HasMaxLength(255)
                .HasColumnName("CIUDAD_NOMBRE");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");

            entity.HasOne(d => d.Estado).WithMany(p => p.Ciudads)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_CIUDAD_ESTADO");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteId).HasName("PK_CLIENTE_ID");

            entity.ToTable("CLIENTE");

            entity.Property(e => e.ClienteId).HasColumnName("CLIENTE_ID");
            entity.Property(e => e.Cedula).HasColumnName("CEDULA");
            entity.Property(e => e.ClienteNombre)
                .HasMaxLength(255)
                .HasColumnName("CLIENTE_NOMBRE");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");

            entity.HasOne(d => d.Estado).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_CLIENTE_ESTADO");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.EstadoId).HasName("PK_ESTADO_ID");

            entity.ToTable("ESTADO");

            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.EstadoDescripcion)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("ESTADO_DESCRIPCION");
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.HasKey(e => e.MarcaId).HasName("PK_MARCA_ID");

            entity.ToTable("MARCA");

            entity.Property(e => e.MarcaId).HasColumnName("MARCA_ID");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
            entity.Property(e => e.MarcaNombre)
                .HasMaxLength(255)
                .HasColumnName("MARCA_NOMBRE");

            entity.HasOne(d => d.Estado).WithMany(p => p.Marcas)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_MARCA_ESTADO");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.HasKey(e => e.ModeloId).HasName("PK_MODELO_ID");

            entity.ToTable("MODELO");

            entity.Property(e => e.ModeloId).HasColumnName("MODELO_ID");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
            entity.Property(e => e.ModeloDescripción)
                .HasMaxLength(255)
                .HasColumnName("MODELO_DESCRIPCIÓN");

            entity.HasOne(d => d.Estado).WithMany(p => p.Modelos)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_MODELO_ESTADO");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK_PRODUCTO_ID");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.ProductoId).HasColumnName("PRODUCTO_ID");
            entity.Property(e => e.CategId).HasColumnName("CATEG_ID");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
            entity.Property(e => e.MarcaId).HasColumnName("MARCA_ID");
            entity.Property(e => e.ModeloId).HasColumnName("MODELO_ID");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
            entity.Property(e => e.ProductoDescrip)
                .HasMaxLength(255)
                .HasColumnName("PRODUCTO_DESCRIP");

            entity.HasOne(d => d.Categ).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PRODUCTO_CATEGORIA");

            entity.HasOne(d => d.Estado).WithMany(p => p.Productos)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_PRODUCTO_ESTADO");

            entity.HasOne(d => d.Marca).WithMany(p => p.Productos)
                .HasForeignKey(d => d.MarcaId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PRODUCTO_MARCA");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Productos)
                .HasForeignKey(d => d.ModeloId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PRODUCTO_MODELO");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.SucursalId).HasName("PK_SUCURSAL_ID");

            entity.ToTable("SUCURSAL");

            entity.Property(e => e.SucursalId).HasColumnName("SUCURSAL_ID");
            entity.Property(e => e.CiudadId).HasColumnName("CIUDAD_ID");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
            entity.Property(e => e.SucursalNombre)
                .HasMaxLength(255)
                .HasColumnName("SUCURSAL_NOMBRE");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.CiudadId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_SUCURSAL_CIUDAD");

            entity.HasOne(d => d.Estado).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_SUCURSAL_ESTADO");
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.HasKey(e => e.VendedorId).HasName("PK_VENDEDOR_ID");

            entity.ToTable("VENDEDOR");

            entity.Property(e => e.VendedorId).HasColumnName("VENDEDOR_ID");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.VendedorDescripcion)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("VENDEDOR_DESCRIPCION");

            entity.HasOne(d => d.Estado).WithMany(p => p.Vendedors)
                .HasForeignKey(d => d.EstadoId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VENDEDOR_ESTADO");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK_FACTURA_ID");

            entity.ToTable("VENTAS");

            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
            entity.Property(e => e.CajaId).HasColumnName("CAJA_ID");
            entity.Property(e => e.CategId).HasColumnName("CATEG_ID");
            entity.Property(e => e.ClienteId).HasColumnName("CLIENTE_ID");
            entity.Property(e => e.EstadoId).HasColumnName("ESTADO_ID");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA");
            entity.Property(e => e.MarcaId).HasColumnName("MARCA_ID");
            entity.Property(e => e.ModeloId).HasColumnName("MODELO_ID");
            entity.Property(e => e.NumFact)
                .HasMaxLength(255)
                .HasColumnName("NUM_FACT");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
            entity.Property(e => e.ProductoId).HasColumnName("PRODUCTO_ID");
            entity.Property(e => e.SucursalId).HasColumnName("SUCURSAL_ID");
            entity.Property(e => e.Unidades).HasColumnName("UNIDADES");
            entity.Property(e => e.VendedorId).HasColumnName("VENDEDOR_ID");

            entity.HasOne(d => d.Caja).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CajaId)
                .HasConstraintName("FK_VENTAS_CAJA");

            entity.HasOne(d => d.Categ).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CategId)
                .HasConstraintName("FK_VENTAS_CATEGORIA");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_VENTAS_CLIENTE");

            entity.HasOne(d => d.Estado).WithMany(p => p.Venta)
                .HasForeignKey(d => d.EstadoId)
                .HasConstraintName("FK_VENTAS_ESTADO");

            entity.HasOne(d => d.Marca).WithMany(p => p.Venta)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK_VENTAS_MARCA");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ModeloId)
                .HasConstraintName("FK_VENTAS_MODELO");

            entity.HasOne(d => d.Producto).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_VENTAS_PRODUCTO");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Venta)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK_VENTAS_SURCURSAL");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Venta)
                .HasForeignKey(d => d.VendedorId)
                .HasConstraintName("FK_VENTAS_VENDEDOR");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
