using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppApiAlmacenn.Models;

public partial class AlmacenDbContext : DbContext
{
    public AlmacenDbContext()
    {
    }

    public AlmacenDbContext(DbContextOptions<AlmacenDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ClienteVendedor> ClienteVendedors { get; set; }

    public virtual DbSet<Tipousuario> Tipousuarios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Visita> Visitas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbAlmacen;Integrated Security=True;Encrypt=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ClienteVendedor>(entity =>
        {
            entity.HasKey(e => e.IdAsignacion).HasName("PK__cliente___E171447806099B47");

            entity.ToTable("cliente_vendedor");

            entity.HasIndex(e => e.IdCliente, "UQ_Cliente").IsUnique();

            entity.Property(e => e.IdAsignacion).HasColumnName("idAsignacion");
            entity.Property(e => e.FechaAsignacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaAsignacion");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");

            entity.HasOne(d => d.IdClienteNavigation).WithOne(p => p.ClienteVendedorIdClienteNavigation)
                .HasForeignKey<ClienteVendedor>(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Cliente");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.ClienteVendedorIdVendedorNavigations)
                .HasForeignKey(d => d.IdVendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Vendedor");
        });

        modelBuilder.Entity<Tipousuario>(entity =>
        {
            entity.HasKey(e => e.IdTipo).HasName("PK__tipousua__BDD0DFE15C820E09");

            entity.ToTable("tipousuario");

            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipoUsuario");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__645723A6D784D8C3");

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Documento, "UQ__usuario__A25B3E613A110136").IsUnique();

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("apellidos");
            entity.Property(e => e.Celular)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("celular");
            entity.Property(e => e.Clave)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("clave");
            entity.Property(e => e.Direccion)
                .HasMaxLength(150)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Documento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("documento");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado)
                .HasDefaultValue(true)
                .HasColumnName("estado");
            entity.Property(e => e.Foto)
                .HasColumnType("text")
                .HasColumnName("foto");
            entity.Property(e => e.IdTipo).HasColumnName("idTipo");
            entity.Property(e => e.Nombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("nombres");
            entity.Property(e => e.TelefonoFijo)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefonoFijo");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("ubicacion");

            entity.HasOne(d => d.IdTipoNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdTipo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__usuario__idTipo__3B75D760");
        });

        modelBuilder.Entity<Visita>(entity =>
        {
            entity.HasKey(e => e.IdVisita).HasName("PK__visitas__0F55DBEC1FB30EDE");

            entity.ToTable("visitas");

            entity.Property(e => e.IdVisita).HasColumnName("idVisita");
            entity.Property(e => e.FechaVisita)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fechaVisita");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdVendedor).HasColumnName("idVendedor");
            entity.Property(e => e.Observaciones)
                .HasColumnType("text")
                .HasColumnName("observaciones");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.VisitaIdClienteNavigations)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__visitas__idClien__45F365D3");

            entity.HasOne(d => d.IdVendedorNavigation).WithMany(p => p.VisitaIdVendedorNavigations)
                .HasForeignKey(d => d.IdVendedor)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__visitas__idVende__44FF419A");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
