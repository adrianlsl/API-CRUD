using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BackendApi.Models;

public partial class DbApiContext : DbContext
{
    public DbApiContext()
    {
    }

    public DbApiContext(DbContextOptions<DbApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Departamento> Departamentos { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Pai> Pais { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Departamento>(entity =>
        {
            entity.HasKey(e => e.IdDepartamento).HasName("PK__DEPARTAM__787A433D16C539B4");

            entity.ToTable("DEPARTAMENTO");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Departamentos)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK_PAIS");
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdEmpleado).HasName("PK__EMPLEADO__CE6D8B9E62781CAF");

            entity.ToTable("EMPLEADO");

            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FechaContrato).HasColumnType("datetime");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombres)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Sueldo).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdDepartamentoNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdDepartamento)
                .HasConstraintName("FK_DEPA");

            entity.HasOne(d => d.IdPaisNavigation).WithMany(p => p.Empleados)
                .HasForeignKey(d => d.IdPais)
                .HasConstraintName("FK_PAIS_EMP");
        });

        modelBuilder.Entity<Pai>(entity =>
        {
            entity.HasKey(e => e.IdPais).HasName("PK__PAIS__FC850A7B23C54AA6");

            entity.ToTable("PAIS");

            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
